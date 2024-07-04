using Bloom.Controller;
using Bloom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloom.Services
{
    public partial class Tokenizer
    {
        #region Token Readers

        private Token ReadIdentifierOrKeyword()
        {
            var start = _positionX;

            while (_positionX < _input.Length && char.IsLetter(CurrentChar()))
            {
                _positionX++;
            }

            var value = _input.Substring(start, _positionX - start);
            var type = IsKeyWord(value) ? TokenTypes.Keyword : TokenTypes.Identifier;

            return new Token(type, value);
        }

        private Token ReadOperationLogicOrOperators()
        {
            var value1 = CurrentChar().ToString();
            var value2 = GetNextTwoChars();

            if (KeyToken.OperatorLogics.Contains(value1))
            {
                _positionX++;
                return CreateToken(TokenTypes.OperatorLogic, value1);
            }
            else if (KeyToken.OperatorLogics.Contains(value2))
            {
                _positionX += 2;
                return new Token(TokenTypes.OperatorLogic, value2);
            }
            else if (KeyToken.Operators.Contains(value1))
            {
                _positionX++;
                return new Token(TokenTypes.Operator, value1);
            }
            else
            {
                Logs.LogError("Estrutura", "Incorreta", true);
                return new Token(TokenTypes.Unknown, value1);
            }
        }

        private Token ReadString()
        {
            _positionX++;

            var start = _positionX;

            while (_positionX < _input.Length && CurrentChar() != '"')
            {
                if (CurrentChar() == '\n' || CurrentChar() == ';') Logs.LogError("rjeklew", _input.Substring(start, _positionX - start), true);
                _positionX++;
            }

            var value = _input.Substring(start, _positionX - start);

            _positionX++;

            return new Token(TokenTypes.String, value);
        }

        private Token ReadNumber()
        {
            var start = _positionX;

            while (_positionX < _input.Length && char.IsDigit(CurrentChar()))
            {
                _positionX++;
            }

            var value = _input.Substring(start, _positionX - start);

            return new Token(TokenTypes.Number, value);
        }

        /* Ainda em desenvolvimento
        private Token ReadComment()
        {
            var start = _positionX;

            while(_positionX < _input.Length)
            {
                if (CurrentChar() == '\n' || KeyToken.Comments.Contains(CurrentChar().ToString())) break;

                _positionX++;
            }
        }
        */
        #endregion
    }
}
