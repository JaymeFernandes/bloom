using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bloom.Resources
{
    public static class AppSettings
    {
        private const string PathLanguage = $"/Resources/Language.json";

        private readonly static string[] Options = { "pt-BR", "en", "es" };

        private static JObject? Messages { get; set; }
        private static string Lenguage { get; set; } = "en";

        static AppSettings()
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + PathLanguage;
            try
            {
                string json = File.ReadAllText(pathFile);
                Messages = JObject.Parse(json);

                CultureInfo currentCulture = CultureInfo.InstalledUICulture;
                Lenguage = Options.Contains(currentCulture.Name) ? currentCulture.Name : "en";
            }
            catch (FileNotFoundException)
            {
                Logs.LogError("FileLanguageDoesNotExist", "Language file does not exist. File required for operation.", true);
            }
            catch (JsonException)
            {
                Logs.LogError("FileLanguageCorrupted", "Language file is corrupt. File required for operation.", true);
            }
            catch (Exception ex)
            {
                Logs.LogError("UnknownError", $"An unknown error occurred: {ex.Message}", true);
            }
        }

        public static string GetHelpMessage()
        {
            try
            {

                return Messages?[Lenguage]?["Help"]?["MainMessage"]?.ToString()
                    ?? "The specified error message is not available in the current language.";
            }
            catch (Exception ex)
            {
                Logs.LogError("GetHelpErrorMessageFailed", $"Failed to get Help message: {ex.Message}", false);
                return "We currently do not have this error code as the language is under development. We are sorry.";
            }
        }
        
        public static string GetErrorMessage(string errorKey)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(errorKey))
                {
                    Logs.LogError($"ErroKeyParameterPassedIsNull", "Error key cannot be null or whitespace.", true);
                }

                return Messages?[Lenguage]?["Errors"]?[errorKey]?.ToString()
                    ?? "The specified error message is not available in the current language.";
            }
            catch (Exception ex)
            {
                Logs.LogError("GetErrorMessageFailed", $"Failed to get error message: {ex.Message}", false);
                return "We currently do not have this error code as the language is under development. We are sorry.";
            }
        }
    }
}
