
namespace Syrx.Commanders.Databases.Settings.Extensions.Json
{
    public static class UseFileExtensions
    {
        public static SyrxBuilder UseFile(this SyrxBuilder factory, string fileName, IConfigurationBuilder builder)
        {
            Throw<ArgumentNullException>(builder != null, $"ConfigurationBuilder is null! Check bootstrap.");
            Throw<ArgumentNullException>(!string.IsNullOrWhiteSpace(fileName), nameof(fileName));
            Throw<ArgumentException>(IsTrustedJsonSettingsFileName(fileName),
                $"The filename '{fileName}' is not an approved JSON settings file name.");

            builder?.AddJsonFile(fileName);

            return factory;
        }

        private static bool IsTrustedJsonSettingsFileName(string fileName)
        {
            var isLeafFileName = Path.GetFileName(fileName) == fileName;
            var hasJsonExtension = string.Equals(Path.GetExtension(fileName), ".json", StringComparison.OrdinalIgnoreCase);

            return isLeafFileName && hasJsonExtension;
        }
    }
}
