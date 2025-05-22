/*
 * Created by SharpDevelop.
 * User: AL_HRAMAIN
 * Date: 5/22/2025
 * Time: 4:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 /*
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    public enum TokenType
    {
        Identifier,
        Number,
        String,
        Comment,
        CondOp,
        Operator,
        LeftParen,
        RightParen,
        Colon,
        Comma,
        ReservedWord,
        Unknown,
        EOF
    }

    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }
        
        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
        
        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }

    public class MyLexer
    {
        private string input;
        private int pos;
        private int length;

        private static HashSet<string> reservedWords = new HashSet<string> {
            "def", "if", "elif", "else", "return", "print", "input", 
            "for", "in", "list", "set", "tuple", "map", "string", "range"
        };

        private static HashSet<string> condOps = new HashSet<string> {
            "==", "!=", ">=", "<=", ">", "<"
        };

        private static HashSet<char> operators = new HashSet<char> {
            '+', '-', '*', '/', '%', '^', '='
        };

        public MyLexer()
        {
        }

        public List<Token> Tokenize(string text)
        {
            input = text;
            pos = 0;
            length = input.Length;

            var tokens = new List<Token>();

            while (pos < length)
            {
                char current = Peek();

                // تجاهل الفراغات البيضاء
                if (char.IsWhiteSpace(current))
                {
                    Advance();
                    continue;
                }

                // التعليقات (تبدأ بـ #)
                if (current == '#')
                {
                    tokens.Add(ReadComment());
                    continue;
                }

                // النصوص (Strings) بين علامات تنصيص "
                if (current == '"')
                {
                    tokens.Add(ReadString());
                    continue;
                }

                // الأرقام
                if (char.IsDigit(current))
                {
                    tokens.Add(ReadNumber());
                    continue;
                }

                // المعرفات أو الكلمات المحجوزة (identifiers or reserved words)
                if (char.IsLetter(current))
                {
                    tokens.Add(ReadIdentifierOrReserved());
                    continue;
                }

                // العمليات الشرطية ثنائية الحرف مثل >=, <=, ==, !=
                if (IsCondOpStart(current))
                {
                    tokens.Add(ReadCondOp());
                    continue;
                }

                // العمليات الأحادية مثل + - * / = ^
                if (operators.Contains(current))
                {
                    tokens.Add(new Token(TokenType.Operator, current.ToString()));
                    Advance();
                    continue;
                }

                // الأقواس والفواصل والنقطتين
                switch (current)
                {
                    case '(':
                        tokens.Add(new Token(TokenType.LeftParen, "("));
                        Advance();
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RightParen, ")"));
                        Advance();
                        break;
                    case ':':
                        tokens.Add(new Token(TokenType.Colon, ":"));
                        Advance();
                        break;
                    case ',':
                        tokens.Add(new Token(TokenType.Comma, ","));
                        Advance();
                        break;
                    default:
                        tokens.Add(new Token(TokenType.Unknown, current.ToString()));
                        Advance();
                        break;
                }
            }

            tokens.Add(new Token(TokenType.EOF, "<EOF>"));
            return tokens;
        }

        private char Peek(int offset = 0)
        {
            if (pos + offset >= length)
                return '\0';
            return input[pos + offset];
        }

        private void Advance(int step = 1)
        {
            pos += step;
        }

        private Token ReadComment()
        {
            int start = pos;
            while (pos < length && input[pos] != '\n')
            {
                Advance();
            }
            string comment = input.Substring(start, pos - start);
            return new Token(TokenType.Comment, comment);
        }

        private Token ReadString()
        {
            StringBuilder sb = new StringBuilder();
            Advance(); // تخطي علامة التنصيص الأولى "

            while (pos < length && Peek() != '"')
            {
                sb.Append(Peek());
                Advance();
            }

            Advance(); // تخطي علامة التنصيص الأخيرة "
            return new Token(TokenType.String, sb.ToString());
        }

        private Token ReadNumber()
        {
            int start = pos;
            while (pos < length && char.IsDigit(Peek()))
            {
                Advance();
            }
            string number = input.Substring(start, pos - start);
            return new Token(TokenType.Number, number);
        }

        private Token ReadIdentifierOrReserved()
        {
            int start = pos;
            while (pos < length && (char.IsLetterOrDigit(Peek())))
            {
                Advance();
            }
            string word = input.Substring(start, pos - start);
            if (reservedWords.Contains(word))
                return new Token(TokenType.ReservedWord, word);
            else
                return new Token(TokenType.Identifier, word);
        }

        private bool IsCondOpStart(char c)
        {
            return c == '=' || c == '!' || c == '<' || c == '>';
        }

        private Token ReadCondOp()
        {
            char first = Peek();
            char second = Peek(1);

            if ((first == '=' && second == '=') ||
                (first == '!' && second == '=') ||
                (first == '<' && second == '=') ||
                (first == '>' && second == '='))
            {
                Advance(2);
                return new Token(TokenType.CondOp, $"{first}{second}");
            }
            else
            {
                Advance(1);
                return new Token(TokenType.CondOp, first.ToString());
            }
        }
    }
}
*/