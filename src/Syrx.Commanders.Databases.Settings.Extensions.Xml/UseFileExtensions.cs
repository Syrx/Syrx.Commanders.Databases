
namespace Syrx.Commanders.Databases.Settings.Extensions.Xml
{
    public static class UseFileExtensions
    {
        public static SyrxBuilder UseFile(this SyrxBuilder factory, string fileName, IConfigurationBuilder builder)
        {
            Throw<ArgumentNullException>(builder != null, $"ConfigurationBuilder is null! Check bootstrap.");
            Throw<ArgumentNullException>(!string.IsNullOrWhiteSpace(fileName), nameof(fileName));
            Throw<ArgumentException>(IsTrustedXmlSettingsFileName(fileName),
                $"The filename '{fileName}' is not an approved XML settings file name.");

            builder?.AddXmlFile(fileName);

            return factory;
        }

        private static bool IsTrustedXmlSettingsFileName(string fileName)
        {
            var isLeafFileName = Path.GetFileName(fileName) == fileName;
            var hasXmlExtension = string.Equals(Path.GetExtension(fileName), ".xml", StringComparison.OrdinalIgnoreCase);

            return isLeafFileName && hasXmlExtension;
        }
    }
}
