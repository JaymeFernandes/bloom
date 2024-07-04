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
            char currentChar = ' ';
            string twoChars = "";

            int temp = -1;

            while (_positionX < _input.Length)
            {
                Logs.LogLoading(_input.Length - 1 ,_positionX);

                // Test de Erro para ver aonde pode ter travado
                if (temp == _positionX)
                {
                    Console.Clear();
                    Logs.LogError("Erro de sintexe", $"Token passado invalido {currentChar} or {twoChars} \nposition: (X:{_positionX} - Y:{_positionY})\n ", true);
                }

                temp = _positionX;

                currentChar = CurrentChar();
                twoChars = GetNextTwoChars();

                if (char.IsWhiteSpace(currentChar) || currentChar == '\n')
                {
                    if (currentChar == '\n') _positionY++;
                    _positionX++;
                }
                else if (char.IsDigit(currentChar))
                {
                    tokens.Add(ReadNumber());
                }
                else if (IsSeparators(currentChar))
                {
                    tokens.Add(CreateToken(TokenTypes.Separator, currentChar.ToString()));
                    _positionX++;
                }
                else if (IsPunctuations(currentChar))
                {
                    tokens.Add(CreateToken(TokenTypes.Punctuations, currentChar.ToString()));
                    _positionX++;
                }
                else if (char.IsLetter(currentChar))
                {
                    tokens.Add(ReadIdentifierOrKeyword());
                }
                else if (currentChar == '"')
                {
                    tokens.Add(ReadString());
                } 
                else if (IsOperatorOrLogic(currentChar, twoChars))
                {
                    tokens.Add(ReadOperationLogicOrOperators());
                }
                else
                {
                    tokens.Add(CreateToken(TokenTypes.Unknown, currentChar.ToString()));
                }
            }

            return tokens;
        }     
    }
}
