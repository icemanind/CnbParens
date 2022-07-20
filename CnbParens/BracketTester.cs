using System;
using System.Collections.Generic;

namespace CnbParens
{
    public class BracketTester
    {
        private string InputString { get; set; }

        private readonly Dictionary<char, char> _acceptableChars;
        private readonly Stack<char> _parenStack;
        private int _index;

        public BracketTester(string parens)
        {
            if (String.IsNullOrWhiteSpace(parens) || parens.Length == 0 || parens.Length % 2 != 0)
            {
                throw new Exception(
                    "Test parens are invalid. You must include both an opening and closing set. Like \"()[]{}\".");
            }

            _acceptableChars = new Dictionary<char, char>();
            _parenStack = new Stack<char>();

            for (int i = 0; i < parens.Length; i += 2)
            {
                _acceptableChars.Add(parens[i], parens[i + 1]);
            }
        }

        public bool IsValid(string inputString)
        {
            if (String.IsNullOrWhiteSpace(inputString)) return true;

            _index = 0;
            InputString = inputString;

            try
            {
                Parens();
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }

        private void Parens()
        {
            if (!_acceptableChars.ContainsKey(InputString[_index]))
            {
                throw new FormatException($"{InputString[_index]} is not a valid character.");
            }

            _parenStack.Push(InputString[_index++]);

            if (IsAtEnd())
            {
                throw new FormatException("Mismatch");
            }

            if (_acceptableChars.ContainsKey(InputString[_index])) Parens();

            if (InputString[_index] != _acceptableChars[_parenStack.Pop()])
            {
                throw new FormatException("Mismatch");
            }
            else
            {
                _index++;
            }

            if (IsAtEnd() && _parenStack.Count > 0)
            {
                throw new FormatException("Mismatch");
            }
        }

        private bool IsAtEnd()
        {
            return _index >= InputString.Length;
        }
    }
}
