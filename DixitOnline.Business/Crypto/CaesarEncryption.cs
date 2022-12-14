using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DixitOnline.Business.Crypto
{
    public class CaesarEncryption
    {
        private readonly List<int> _caesarOffsets = new List<int>();
        private readonly Random _random = new Random();

        private readonly char[] _alphabet = new[]
        { 
          'A', 'a',
          'B', 'b',
          'C', 'c',
          'D', 'd',
          'E', 'e',
          'F', 'f',
          'G', 'g',
          'H', 'h',
          'I', 'i',
          'J', 'j',
          'K', 'k',
          'L', 'l',
          'M', 'm',
          'N', 'n',
          'O', 'o',
          'P', 'p',
          'Q', 'q',
          'R', 'r',
          'S', 's',
          'T', 't',
          'U', 'u',
          'V', 'v',
          'W', 'w',
          'X', 'x',
          'Y', 'y',
          'Z', 'z'
        };
            
        public string Encrypt(string data)
        {
            GenerateOffsets(10);
            var stringBuilder = new StringBuilder();

            foreach (var item in data)
            {
                var offsetIndex = _random.Next(_caesarOffsets.Count());
                var num = (int)char.GetNumericValue(item) + _caesarOffsets[offsetIndex];

                if(num < 0)
                {
                    num += _alphabet.Count();
                }

                if(num > _alphabet.Count())
                {
                    var multipler = num / _alphabet.Count();
                    num -= _alphabet.Count() * multipler;
                }

                stringBuilder.Append(_alphabet[num]);
            }

            return $"{stringBuilder}=";
        }

        private void GenerateOffsets(int count)
        {
            while(_caesarOffsets.Count() != count)
            {
                var offset = _random.Next(-20, 30);

                if(_caesarOffsets.Contains(offset))
                {
                    continue;
                }

                _caesarOffsets.Add(offset);
            }
        }
    }
}
