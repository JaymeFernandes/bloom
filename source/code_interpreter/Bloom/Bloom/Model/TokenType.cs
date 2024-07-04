namespace Bloom.Model
{
    public enum TokenTypes
    {
        Punctuations,   // Pontuações como ;, :, ?
        Identifier,     // Variáveis, nomes de funções, etc. (int, double, string, char, etc...)
        Keyword,        // Palavras-chave como if, else, while, return, etc.
        Number,         // Números inteiros ou decimais
        String,         // Sequências de caracteres entre aspas
        Operator,       // Operadores como +, -, *, /, =, etc.
        OperatorLogic,  // Operadores Lógicos como ==, !=, >=, <=
        Separator,      // Caracteres especiais como (, ), {, }, etc.
        Whitespace,     // Espaços em branco 
        Comment,        // Comentários no código
        Unknown         // Qualquer coisa que não se encaixe nas categorias acima
    }

    /// <summary>
    /// Chaves dos tokens
    /// </summary>
    public static class KeyToken
    {
        public static readonly HashSet<string> Punctuations = new HashSet<string>()
        {
            ";", ":", ",", ".", "?", "!", "$"
        };

        public static readonly HashSet<string> Identifiers = new HashSet<string>
        {
            "var" ,"int", "double", "string", "char", "bool", "arr"
        };

        public static readonly HashSet<string> Keywords = new HashSet<string>
        {
            "if", "else", "elsif", "while", "for", "foreach", "return"
        };

        public static readonly HashSet<string> Operators = new HashSet<string>
        {
            "+", "-", "*", "/", "%", "="
        };

        public static readonly HashSet<string> OperatorLogics = new HashSet<string>
        {
            "<", ">", "==", "!=", ">=", "<=", "&&", "||"
        };

        public static readonly HashSet<string> Separators = new HashSet<string>
        {
            "{", "}", "(", ")", "[", "]"
        };

        public static readonly HashSet<string> Comments = new HashSet<string>
        {
            "//", "/*", "*/", "#"
        };
    }
}
