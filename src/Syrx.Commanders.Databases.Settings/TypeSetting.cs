namespace Syrx.Commanders.Databases.Settings
{
    public sealed record TypeSetting : ITypeSetting<CommandSetting>
    {
        public required string Name { get; init; }
        public required ConcurrentDictionary<string, CommandSetting> Commands { get; init; }
        
        // Explicit interface implementation with both get and init
        IDictionary<string, CommandSetting> ITypeSetting<CommandSetting>.Commands 
        { 
            get => Commands; 
            init => Commands = value as ConcurrentDictionary<string, CommandSetting> ?? new ConcurrentDictionary<string, CommandSetting>(value); 
        }
    }
}
