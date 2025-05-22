
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF         =  0, // (EOF)
        SYMBOL_ERROR       =  1, // (Error)
        SYMBOL_WHITESPACE  =  2, // Whitespace
        SYMBOL_MINUS       =  3, // '-'
        SYMBOL_EXCLAMEQ    =  4, // '!='
        SYMBOL_PERCENT     =  5, // '%'
        SYMBOL_LPAREN      =  6, // '('
        SYMBOL_RPAREN      =  7, // ')'
        SYMBOL_TIMES       =  8, // '*'
        SYMBOL_COMMA       =  9, // ','
        SYMBOL_DIV         = 10, // '/'
        SYMBOL_COLON       = 11, // ':'
        SYMBOL_CARET       = 12, // '^'
        SYMBOL_PLUS        = 13, // '+'
        SYMBOL_LT          = 14, // '<'
        SYMBOL_LTEQ        = 15, // '<='
        SYMBOL_EQ          = 16, // '='
        SYMBOL_EQEQ        = 17, // '=='
        SYMBOL_GT          = 18, // '>'
        SYMBOL_GTEQ        = 19, // '>='
        SYMBOL_DEF         = 20, // def
        SYMBOL_DIGIT       = 21, // Digit
        SYMBOL_ELIF        = 22, // elif
        SYMBOL_ELSE        = 23, // else
        SYMBOL_FOR         = 24, // for
        SYMBOL_ID          = 25, // ID
        SYMBOL_IF          = 26, // if
        SYMBOL_IN          = 27, // in
        SYMBOL_INPUT       = 28, // input
        SYMBOL_LIST        = 29, // list
        SYMBOL_MAP         = 30, // map
        SYMBOL_PRINT       = 31, // print
        SYMBOL_RANGE       = 32, // range
        SYMBOL_RETURN      = 33, // return
        SYMBOL_SET         = 34, // set
        SYMBOL_STRING      = 35, // string
        SYMBOL_TUPLE       = 36, // tuple
        SYMBOL_ASSIGN      = 37, // <assign>
        SYMBOL_COLLECTION  = 38, // <collection>
        SYMBOL_COND        = 39, // <cond>
        SYMBOL_COND_OP     = 40, // <cond_op>
        SYMBOL_DIGIT2      = 41, // <digit>
        SYMBOL_ELIF2       = 42, // <elif>
        SYMBOL_ELSE2       = 43, // <else>
        SYMBOL_EMPTY       = 44, // <empty>
        SYMBOL_EXP         = 45, // <exp>
        SYMBOL_FOR_BODY    = 46, // <for_body>
        SYMBOL_FOR_LOOP    = 47, // <for_loop>
        SYMBOL_FUNC_BODY   = 48, // <func_body>
        SYMBOL_FUNC_DEF    = 49, // <func_def>
        SYMBOL_ID2         = 50, // <id>
        SYMBOL_IF_BODY     = 51, // <if_body>
        SYMBOL_IF_STMT     = 52, // <if_stmt>
        SYMBOL_INPUT_STMT  = 53, // <input_stmt>
        SYMBOL_OP          = 54, // <op>
        SYMBOL_PARAMS      = 55, // <params>
        SYMBOL_PRINT_STMT  = 56, // <print_stmt>
        SYMBOL_PROGRAM     = 57, // <program>
        SYMBOL_RANGES      = 58, // <ranges>
        SYMBOL_RETURN_STMT = 59, // <return_stmt>
        SYMBOL_STM         = 60, // <stm>
        SYMBOL_STM_LIST    = 61  // <stm_list>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                   =  0, // <program> ::= <stm_list>
        RULE_STM_LIST                                  =  1, // <stm_list> ::= <stm> <stm_list>
        RULE_STM_LIST2                                 =  2, // <stm_list> ::= <empty>
        RULE_STM                                       =  3, // <stm> ::= <assign>
        RULE_STM2                                      =  4, // <stm> ::= <for_loop>
        RULE_STM3                                      =  5, // <stm> ::= <if_stmt>
        RULE_STM4                                      =  6, // <stm> ::= <return_stmt>
        RULE_STM5                                      =  7, // <stm> ::= <print_stmt>
        RULE_STM6                                      =  8, // <stm> ::= <input_stmt>
        RULE_STM7                                      =  9, // <stm> ::= <func_def>
        RULE_ASSIGN_EQ                                 = 10, // <assign> ::= <id> '=' <exp>
        RULE_ID_ID                                     = 11, // <id> ::= ID
        RULE_DIGIT_DIGIT                               = 12, // <digit> ::= Digit
        RULE_EXP                                       = 13, // <exp> ::= <id>
        RULE_EXP2                                      = 14, // <exp> ::= <digit>
        RULE_EXP3                                      = 15, // <exp> ::= <id> <op> <exp>
        RULE_EXP4                                      = 16, // <exp> ::= <digit> <op> <exp>
        RULE_EXP_LPAREN_RPAREN                         = 17, // <exp> ::= '(' <exp> ')'
        RULE_OP_PLUS                                   = 18, // <op> ::= '+'
        RULE_OP_MINUS                                  = 19, // <op> ::= '-'
        RULE_OP_TIMES                                  = 20, // <op> ::= '*'
        RULE_OP_DIV                                    = 21, // <op> ::= '/'
        RULE_OP_PERCENT                                = 22, // <op> ::= '%'
        RULE_OP_CARET                                  = 23, // <op> ::= '^'
        RULE_OP_EQ                                     = 24, // <op> ::= '='
        RULE_PRINT_STMT_PRINT_LPAREN_RPAREN            = 25, // <print_stmt> ::= print '(' <exp> ')'
        RULE_INPUT_STMT_EQ_INPUT_LPAREN_RPAREN         = 26, // <input_stmt> ::= <id> '=' input '(' ')'
        RULE_RETURN_STMT_RETURN                        = 27, // <return_stmt> ::= return <exp>
        RULE_IF_STMT_IF_COLON                          = 28, // <if_stmt> ::= if <cond> ':' <if_body>
        RULE_COND                                      = 29, // <cond> ::= <exp> <cond_op> <exp>
        RULE_COND_OP_GT                                = 30, // <cond_op> ::= '>'
        RULE_COND_OP_GTEQ                              = 31, // <cond_op> ::= '>='
        RULE_COND_OP_LT                                = 32, // <cond_op> ::= '<'
        RULE_COND_OP_LTEQ                              = 33, // <cond_op> ::= '<='
        RULE_COND_OP_EQEQ                              = 34, // <cond_op> ::= '=='
        RULE_COND_OP_EXCLAMEQ                          = 35, // <cond_op> ::= '!='
        RULE_IF_BODY                                   = 36, // <if_body> ::= <stm>
        RULE_IF_BODY2                                  = 37, // <if_body> ::= <elif>
        RULE_IF_BODY3                                  = 38, // <if_body> ::= <else>
        RULE_ELIF_ELIF_COLON                           = 39, // <elif> ::= elif <cond> ':' <if_body>
        RULE_ELSE_ELSE_COLON                           = 40, // <else> ::= else ':' <stm>
        RULE_FOR_LOOP_FOR_IN_COLON                     = 41, // <for_loop> ::= for <id> in <collection> ':' <for_body>
        RULE_FOR_LOOP_FOR_IN_RANGE_LPAREN_RPAREN_COLON = 42, // <for_loop> ::= for <id> in range '(' <ranges> ')' ':' <for_body>
        RULE_COLLECTION_LIST                           = 43, // <collection> ::= list
        RULE_COLLECTION_SET                            = 44, // <collection> ::= set
        RULE_COLLECTION_TUPLE                          = 45, // <collection> ::= tuple
        RULE_COLLECTION_MAP                            = 46, // <collection> ::= map
        RULE_COLLECTION_STRING                         = 47, // <collection> ::= string
        RULE_RANGES                                    = 48, // <ranges> ::= <exp>
        RULE_RANGES_COMMA                              = 49, // <ranges> ::= <exp> ',' <ranges>
        RULE_FOR_BODY                                  = 50, // <for_body> ::= <stm>
        RULE_FOR_BODY2                                 = 51, // <for_body> ::= <stm> <for_body>
        RULE_FUNC_DEF_DEF_LPAREN_RPAREN_COLON          = 52, // <func_def> ::= def <id> '(' <params> ')' ':' <func_body>
        RULE_PARAMS                                    = 53, // <params> ::= <exp>
        RULE_PARAMS_COMMA                              = 54, // <params> ::= <exp> ',' <params>
        RULE_PARAMS2                                   = 55, // <params> ::= <empty>
        RULE_FUNC_BODY                                 = 56, // <func_body> ::= <stm>
        RULE_FUNC_BODY2                                = 57, // <func_body> ::= <stm> <func_body>
        RULE_EMPTY                                     = 58  // <empty> ::= 
    };

    public class MyParser
    {
        ListBox l;
        private LALRParser parser;

        public MyParser(string filename , ListBox l)
        {
            this.l = l;
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEF :
                //def
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF :
                //elif
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //ID
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INPUT :
                //input
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LIST :
                //list
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MAP :
                //map
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANGE :
                //range
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SET :
                //set
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TUPLE :
                //tuple
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLLECTION :
                //<collection>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND_OP :
                //<cond_op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF2 :
                //<elif>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE2 :
                //<else>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EMPTY :
                //<empty>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_BODY :
                //<for_body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_LOOP :
                //<for_loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC_BODY :
                //<func_body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC_DEF :
                //<func_def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_BODY :
                //<if_body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INPUT_STMT :
                //<input_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS :
                //<params>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STMT :
                //<print_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANGES :
                //<ranges>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_STMT :
                //<return_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STM :
                //<stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STM_LIST :
                //<stm_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<program> ::= <stm_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM_LIST :
                //<stm_list> ::= <stm> <stm_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM_LIST2 :
                //<stm_list> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM :
                //<stm> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM2 :
                //<stm> ::= <for_loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM3 :
                //<stm> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM4 :
                //<stm> ::= <return_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM5 :
                //<stm> ::= <print_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM6 :
                //<stm> ::= <input_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STM7 :
                //<stm> ::= <func_def>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= ID
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP3 :
                //<exp> ::= <id> <op> <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP4 :
                //<exp> ::= <digit> <op> <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <exp> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_PLUS :
                //<op> ::= '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_MINUS :
                //<op> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_TIMES :
                //<op> ::= '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_DIV :
                //<op> ::= '/'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_PERCENT :
                //<op> ::= '%'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_CARET :
                //<op> ::= '^'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQ :
                //<op> ::= '='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STMT_PRINT_LPAREN_RPAREN :
                //<print_stmt> ::= print '(' <exp> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INPUT_STMT_EQ_INPUT_LPAREN_RPAREN :
                //<input_stmt> ::= <id> '=' input '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_STMT_RETURN :
                //<return_stmt> ::= return <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_COLON :
                //<if_stmt> ::= if <cond> ':' <if_body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <exp> <cond_op> <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_OP_GT :
                //<cond_op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_OP_GTEQ :
                //<cond_op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_OP_LT :
                //<cond_op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_OP_LTEQ :
                //<cond_op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_OP_EQEQ :
                //<cond_op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_OP_EXCLAMEQ :
                //<cond_op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_BODY :
                //<if_body> ::= <stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_BODY2 :
                //<if_body> ::= <elif>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_BODY3 :
                //<if_body> ::= <else>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_ELIF_COLON :
                //<elif> ::= elif <cond> ':' <if_body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSE_ELSE_COLON :
                //<else> ::= else ':' <stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_LOOP_FOR_IN_COLON :
                //<for_loop> ::= for <id> in <collection> ':' <for_body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_LOOP_FOR_IN_RANGE_LPAREN_RPAREN_COLON :
                //<for_loop> ::= for <id> in range '(' <ranges> ')' ':' <for_body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COLLECTION_LIST :
                //<collection> ::= list
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COLLECTION_SET :
                //<collection> ::= set
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COLLECTION_TUPLE :
                //<collection> ::= tuple
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COLLECTION_MAP :
                //<collection> ::= map
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COLLECTION_STRING :
                //<collection> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANGES :
                //<ranges> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANGES_COMMA :
                //<ranges> ::= <exp> ',' <ranges>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_BODY :
                //<for_body> ::= <stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_BODY2 :
                //<for_body> ::= <stm> <for_body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_DEF_DEF_LPAREN_RPAREN_COLON :
                //<func_def> ::= def <id> '(' <params> ')' ':' <func_body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS :
                //<params> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS_COMMA :
                //<params> ::= <exp> ',' <params>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS2 :
                //<params> ::= <empty>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_BODY :
                //<func_body> ::= <stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_BODY2 :
                //<func_body> ::= <stm> <func_body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EMPTY :
                //<empty> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            ShowMessage(message);
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "' in line: " + args.UnexpectedToken.Location.LineNr;
            ShowMessage(message);

            string m2 = "Expected token is: " + string.Join(", ", args.ExpectedTokens);
            ShowMessage(m2);
            //todo: Report message to UI?
        }

        private void ShowMessage(string msg)
        {
            if (l.InvokeRequired)
            {
                l.Invoke(new System.Action(() => l.Items.Add(msg)));
            }
            else
            {
                l.Items.Add(msg);
            }
        }

    }
}
