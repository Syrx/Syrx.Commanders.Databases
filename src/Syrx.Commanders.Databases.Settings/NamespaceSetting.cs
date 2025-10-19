namespace Syrx.Commanders.Databases.Settings
{
    public sealed record NamespaceSetting : INamespaceSetting<CommandSetting>
    {
        public required string Namespace { get; init; }
        public required List<TypeSetting> Types { get; init; }
        
        // Explicit interface implementation with both get and init
        IEnumerable<ITypeSetting<CommandSetting>> INamespaceSetting<CommandSetting>.Types 
        { 
            get => Types; 
            init => Types = value.OfType<TypeSetting>().ToList(); 
        }
    }
}
