using Bloom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloom.Controller
{
    public class Token
    {
        public TokenTypes Type {  get; set; }
        public string Value { get; set; }

        public Token(TokenTypes type, string value) 
        {
            this.Type = type;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Type} : \"{Value}\"";
        }
    }
}
