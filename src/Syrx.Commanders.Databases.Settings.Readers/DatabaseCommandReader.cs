//  ============================================================================================================================= 
//  author       : david sexton (@sextondjc | sextondjc.com)
//  date         : 2017.10.15 (17:58)
//  licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  =============================================================================================================================

namespace Syrx.Commanders.Databases.Settings.Readers
{
    public class DatabaseCommandReader : IDatabaseCommandReader
    {
        private readonly Dictionary<string, CommandSetting> _commandLookup = new(StringComparer.Ordinal);
                
        public DatabaseCommandReader(ICommanderSettings settings)
        {
            Throw<ArgumentNullException>(settings != null, "{0}. No settings were passed to DatabaseCommandReader.", nameof(settings));

            foreach (var @namespace in settings!.Namespaces ?? Enumerable.Empty<NamespaceSetting>())
            {
                foreach (var type in @namespace.Types ?? Enumerable.Empty<TypeSetting>())
                {
                    foreach (var command in type.Commands ?? Enumerable.Empty<KeyValuePair<string, CommandSetting>>())
                    {
                        var fullKey = $"{type.Name}.{command.Key}";
                        Throw<ArgumentException>(
                            _commandLookup.TryAdd(fullKey, command.Value),
                            $"Duplicate command setting key '{fullKey}' was found while indexing command settings.");
                    }
                }
            }
        }
                
        public CommandSetting GetCommand(Type type, string key)
        {
            Throw<ArgumentNullException>(type != null, nameof(type));
            Throw<ArgumentNullException>(!string.IsNullOrWhiteSpace(key), nameof(key));

            var lookupKey = $"{type!.FullName}.{key}";
            _commandLookup.TryGetValue(lookupKey, out var result);

            Throw<NullReferenceException>(result != null, ErrorMessages.NoCommandSetting, key, type!.FullName!);

            return result!;
        }

        private static class ErrorMessages
        {
            internal const string NoCommandSetting =
                    @"The command setting '{0}' has no entry for the type setting '{1}'. Please add a command setting entry to the type setting.";
        }
    }
}