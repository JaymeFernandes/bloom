using Bloom.Controller;
using Bloom.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloom.Services
{
    public partial class Tokenizer
    {
        #region Helper Methods

        private char CurrentChar()
        {
            char c = _input[_positionX];

            return c;
        }

        private string GetNextTwoChars()
        {
            return _positionX + 1 < _input.Length ? _input.Substring(_positionX, 2) : string.Empty;
        }

        private Token CreateToken(TokenTypes type, string value)
        {
            return new Token(type, value);
        }

        private bool IsKeyWord(string value)
        {
            return KeyToken.Keywords.Contains(value);
        }

        private bool IsSeparators(char value)
        {
            return KeyToken.Separators.Contains(value.ToString());
        }

        private bool IsPunctuations(char value)
        {
            return KeyToken.Punctuations.Contains(value.ToString());
        }

        private bool IsOperatorOrLogic(char currentChar, string twoChars)
        {
            return KeyToken.Operators.Contains(currentChar.ToString()) || KeyToken.OperatorLogics.Contains(twoChars) || KeyToken.OperatorLogics.Contains(currentChar.ToString());
        }

        #endregion
    }
}
