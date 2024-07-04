using Bloom.Controller;
using Bloom.Services;

namespace Bloom
{
    public class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0) Logs.LogError("InitialParameterNullDirectoryPath", true);

            switch (args[0].ToLower())
            {
                case "run":
                    if (args.Length > 1 && File.Exists(args[1]))
                    {
                        try
                        {
                            string file = File.ReadAllText(args[1]);
                            Tokenizer tokenizer = new Tokenizer(file);
                            List<Token> tokens = tokenizer.Run();

                            // Exibe os tokens encontrados
                            foreach (Token token in tokens)
                            {
                                Console.WriteLine(token.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Logs.LogError("FileConnotBeRead", true, new Dictionary<string, string> { { "@message" , $"{ex.Message}" } } );
                        }
                    }
                    else
                    {
                        Logs.LogError("FileInitialNotFound", true, new Dictionary<string, string> { { "@path", args[1] } });
                    }
                    break;

                case "--help":
                    if (args.Length == 1) Help.HelpMe();
                    else Logs.LogError("InvalidInitialParameter", true);
                    break;

                default:
                    Logs.LogError("InvalidInitialParameter", true);
                    break;
            }
        }
    }
}
