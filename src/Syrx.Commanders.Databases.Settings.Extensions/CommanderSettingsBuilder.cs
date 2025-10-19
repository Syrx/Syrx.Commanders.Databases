namespace Syrx.Commanders.Databases.Settings.Extensions
{
    public class CommanderSettingsBuilder
    {
        private ConcurrentDictionary<string, ConnectionStringSetting> _connectionStrings;
        private ConcurrentDictionary<string, NamespaceSetting> _settings;

        public CommanderSettingsBuilder()
        {
            _connectionStrings = new ConcurrentDictionary<string, ConnectionStringSetting>();
            _settings = new ConcurrentDictionary<string, NamespaceSetting>();
        }

        public CommanderSettingsBuilder AddConnectionString(string alias, string connectionString)
        {
            Throw<ArgumentNullException>(!string.IsNullOrWhiteSpace(alias), nameof(alias));
            Throw<ArgumentNullException>(!string.IsNullOrWhiteSpace(connectionString), nameof(connectionString));
            Action<ConnectionStringSettingsBuilder> builder = (a) => a.UseAlias(alias).UseConnectionString(connectionString);
            return AddConnectionString(builder);
        }

        public CommanderSettingsBuilder AddConnectionString(Action<ConnectionStringSettingsBuilder> builder)
        {
            var settings = ConnectionStringBuilderExtensions.Build(builder);

            var existing = _connectionStrings.GetOrAdd(settings.Alias, settings);
            if (existing.ConnectionString != settings.ConnectionString)
            {
                Throw<ArgumentException>(existing.ConnectionString == settings.ConnectionString, $"The alias '{settings.Alias}' is already assigned to a different connection string. \r\nCurrent connection string: {existing.ConnectionString}\r\nNew connection string: {settings.ConnectionString}");
            }

            return this;
        }

        public CommanderSettingsBuilder AddCommand(Action<NamespaceSettingBuilder> builder)
        {
            var options = NamespaceSettingBuilderExtensions.Build(builder);
            return AddCommand(options);
        }

        public CommanderSettingsBuilder AddCommand(NamespaceSetting options)
        {
            Throw<ArgumentNullException>(options != null, nameof(options));
            Evaluate(options!);
            return this;
        }

        private void Evaluate(NamespaceSetting option)
        {
            // pretty sure this can be done more elegantly. 
            if (_settings.TryGetValue(option.Namespace, out var ns))
            {
                // for this namespace, we need to check that the 
                // types collection doesn't already contain the 
                // type being passed by 'option'. 

                // for the current approach we need to 
                // evaluate each of the types in 'option.Types'
                // to see if they should be assigned to that type. 

                foreach (var type in option.Types)
                {
                    // evaluate whether we are already hosting this type. 
                    var entry = ns.Types.SingleOrDefault(x => x.Name == type.Name);

                    // if that's true, add these type.Commands to that that type. 
                    if (entry != null)
                    {
                        foreach (var (method, command) in type.Commands)
                        {
                            entry.Commands.TryAdd(method, command);
                        }
                        return;
                    }

                    // as we're already in the same namespace, add
                    // to that one instead. 
                    ns.Types.AddRange(option.Types);
                    return;
                }
            }

            _settings.TryAdd(option.Namespace, option);
        }

        private IEnumerable<NamespaceSetting> ValidateNamespaceCollections(IEnumerable<NamespaceSetting> collection)
        {
            Throw<ArgumentException>(collection.Any(), "Collection should have at least 1 namespace setting. Use the AddCommand method to add a new entry to the collection.");
            return collection;
        }

        protected internal CommanderSettings Build()
        {
            // the connections collections can be empty as we 
            // might want tp pull these from a different source/secrets. 
            var connections = _connectionStrings.Values.ToList();
            var namespaces = ValidateNamespaceCollections(_settings.Values);


            return new CommanderSettings { Namespaces = namespaces.ToList(), Connections = connections };
        }
    }

}
