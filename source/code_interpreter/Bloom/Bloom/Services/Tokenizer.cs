using Bloom.Controller;
using Bloom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloom.Services
{
    public class Tokenizer
    {
        private string _input;
        private int _positionX;
        private int _positionY;

        public Tokenizer(string input)
        {
            _input = input;
            _positionX = 0;
            _positionY = 0;
        }

        public List<Token> Run()
        {
            List<Token> tokens = new List<Token>();
            string value1 = "", value2 = "";

            while (_positionX < _input.Length)
            {
                // Test de Erro para ver aonde pode ter travado
               
                if (value1 == CurrentChar().ToString())
                {
                    Console.WriteLine($"Erro: {CurrentChar()} \n position: (X:{_positionX} - Y:{_positionY})\n ");
                    Console.ReadLine();
                }

                value1 = CurrentChar().ToString();
                value2 = _input.Substring(_positionX, 2);


                if (char.IsWhiteSpace(CurrentChar()))
                {
                    _positionX++;
                    continue;
                }
                else if (char.IsDigit(CurrentChar()))
                {
                    tokens.Add(ReadNumber());
                    continue;
                }
                else if (KeyToken.Separators.Contains(value1))
                {
                    tokens.Add(new Token(TokenTypes.Separator, value1));
                    _positionX++;
                    continue;
                }
                else if (KeyToken.Punctuations.Contains(value1))
                {
                    tokens.Add(new Token(TokenTypes.Punctuations, value1));
                    _positionX++;
                    continue;
                }
                else if (char.IsLetter(CurrentChar()))
                {
                    tokens.Add(ReadIdentifierOrKeyword());
                    continue;
                }
                else if (CurrentChar() == '"')
                {
                    tokens.Add(ReadString());
                    continue;
                }
                else if (KeyToken.Operators.Contains(value1) || KeyToken.OperatorLogics.Contains(value2) || KeyToken.OperatorLogics.Contains(value1))
                {
                    tokens.Add(ReadOperationLogicOrOperators());
                    continue;
                }
                else
                {
                    tokens.Add(new Token (TokenTypes.Unknown, value1));
                    continue;
                }

            }

            return tokens;
        }

        private char CurrentChar()
        {
            char c = _input[_positionX];

            if(c == '\n') _positionY++;

            return c;
        }

        #region Reads types

        private Token ReadIdentifierOrKeyword()
        {
            var start = _positionX;

            while(_positionX < _input.Length && char.IsLetter(CurrentChar()))
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
            var value2 = _input.Substring(_positionX, 2);

            if (KeyToken.OperatorLogics.Contains(value1))
            {
                _positionX++;
                return new Token(TokenTypes.OperatorLogic, value1);
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

            while(_positionX < _input.Length && CurrentChar() != '"')
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

            while(_positionX < _input.Length && char.IsDigit(CurrentChar()))
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

        private bool IsKeyWord(string value)
        {
            return KeyToken.Keywords.Contains(value);
        }

       
    }
}
