using SQLGrip;

namespace SQLGrip.ParserTree.ANSI.Version92
{

    [Language(name: "SQL", dialect: "ANSI", version: "92", subject: "Tokens")]
    public enum SqlToken
    {

        [Token(Category = "", Description = "When none of the Tokens match.", Example = "null")]
        None = 0,


        [Token(Text = " ", Category = "characters", Description = "Matched whitespaces.")]
        WhiteSpace,
        [Token(Text = "[\\s]", Category = "characters", Description = "Matched text.")]
        String,

        [Token(Text = "[\\s]", Category = "characters", Description = "Matched Identifier.")]
        Identifier,
        [Token(Text = "[\\s]", Category = "characters", Description = "Matched built-in identifier.")]
        BuiltInIdentifier,
        [Token(Text = "[\\s]", Category = "characters", Description = "Matched RegularExpression.")]
        RegularExpression,


        [Token(Text = "[0-9]", Category = "numeric", Description = "Matched decimal number.")]
        Number,
        [Token(Text = "[0-9A-Fa-f]", Category = "numeric", Description = "Matched hexadecimal number.")]
        HexNumber,

        [Token(Text = "'", Category = "characters", Description = "Matched single quote.")]
        Quote,
        [Token(Text = "\"", Category = "characters", Description = "Matched double quote.")]
        DoubleQuote,
        [Token(Text = ",", Category = "characters", Description = "Matches comma.")]
        Comma,
        [Token(Text = ".", Category = "last_resort", Description = "Matches Period.")]
        Period,
        [Token(Text = "[", Category = "last_resort", Description = "Matches LeftBracket.")]
        LeftBracket,
        [Token(Text = "]", Category = "last_resort", Description = "Matches RightBracket.")]
        RightBracket,
        [Token(Text = "(", Category = "last_resort", Description = "Matches LeftParen.")]
        LeftParen,
        [Token(Text = ")", Category = "last_resort", Description = "Matches RightParen.")]
        RightParen,
        [Token(Text = "?", Category = "last_resort", Description = "Matches QuestionMark.")]
        QuestionMark,
        [Token(Text = "|", Category = "last_resort", Description = "Matches VerticalBar.")]
        VerticalBar,
        [Token(Text = "_", Category = "last_resort", Description = "Matches Underscore.")]
        Underscore,
        [Token(Text = ":", Category = "last_resort", Description = "Matches Colon.")]
        Colon,
        [Token(Text = ";", Category = "last_resort", Description = "Matches Semicolon.")]
        Semicolon,

        [Token(Text = "+", Category = "operator", Description = "Matches Plus.")]
        Plus,
        [Token(Text = "-", Category = "operator", Description = "Matches Minus.")]
        Minus,
        [Token(Text = "*", Category = "operator", Description = "Matches Asterisk.")]
        Asterisk,
        [Token(Text = "/", Category = "operator", Description = "Matches ForwardSlash.")]
        ForwardSlash,
        [Token(Text = "%", Category = "operator", Description = "Matches Percent.")]
        Percent,
        [Token(Text = "^", Category = "operator", Description = "Matches Caret.")]
        Caret,
        [Token(Text = "<", Category = "operator", Description = "Matches LessThan.")]
        LessThan,
        [Token(Text = "<=", Category = "operator", Description = "Matches LessThanOrEqual.")]
        LessThanOrEqual,
        [Token(Text = ">", Category = "operator", Description = "Matches GreaterThan.")]
        GreaterThan,
        [Token(Text = ">=", Category = "operator", Description = "Matches GreaterThanOrEqual.")]
        GreaterThanOrEqual,
        [Token(Text = "=", Category = "operator", Description = "Matches Equal.")]
        Equal,
        [Token(Text = "<>", Category = "operator", Description = "Matches NotEqual.")]
        NotEqual,


        // A
        [Token(Text = "ABSOLUTE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ABSOLUTE,
        [Token(Text = "ACTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ACTION,
        [Token(Text = "ADA", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ADA,
        [Token(Text = "ADD", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ADD,
        [Token(Text = "ALL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ALL,
        [Token(Text = "ALLOCATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ALLOCATE,
        [Token(Text = "ALTER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ALTER,
        [Token(Text = "AND", Category = "operand", Description = "When keyword matches.", Example = "")]
        AND,
        [Token(Text = "ANY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ANY,
        [Token(Text = "ARE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ARE,
        [Token(Text = "AS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        AS,
        [Token(Text = "ASC", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ASC,
        [Token(Text = "ASSERTION", Category = "function", Description = "When keyword matches.", Example = "")]
        ASSERTION,
        [Token(Text = "AT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        AT,
        [Token(Text = "AUTHORIZATION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        AUTHORIZATION,
        [Token(Text = "AVG", Category = "function", Description = "When keyword matches.", Example = "")]
        AVG,


        // B
        [Token(Text = "BEGIN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        BEGIN,
        [Token(Text = "AVG", Category = "function", Description = "When keyword matches.", Example = "")]
        BETWEEN,
        [Token(Text = "BIT", Category = "datatype", Description = "When keyword matches.", Example = "")]
        BIT,
        [Token(Text = "BIT_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        BIT_LENGTH,
        [Token(Text = "BOTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        BOTH,
        [Token(Text = "BY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        BY,

        // C
        [Token(Text = "CASCADE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CASCADE,
        [Token(Text = "CASCADED", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CASCADED,
        [Token(Text = "CASE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CASE,
        [Token(Text = "CAST", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CAST,
        [Token(Text = "CATALOG", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CATALOG,
        [Token(Text = "CATALOG_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CATALOG_NAME,
        [Token(Text = "CHAR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHAR,
        [Token(Text = "CHARACTER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHARACTER,
        [Token(Text = "CHARACTER_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHARACTER_LENGTH,
        [Token(Text = "CHARACTER_SET_CATALOG", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHARACTER_SET_CATALOG,
        [Token(Text = "CHARACTER_SET_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHARACTER_SET_NAME,
        [Token(Text = "CHARACTER_SET_SCHEMA", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHARACTER_SET_SCHEMA,
        [Token(Text = "CHAR_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHAR_LENGTH,
        [Token(Text = "CHECK", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CHECK,
        [Token(Text = "CLASS_ORIGIN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CLASS_ORIGIN,
        [Token(Text = "CLOSE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CLOSE,
        [Token(Text = "COALESCE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COALESCE,
        [Token(Text = "COLLATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COLLATE,
        [Token(Text = "COLLATION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COLLATION,
        [Token(Text = "COLLATION_CATALOG", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COLLATION_CATALOG,
        [Token(Text = "COLLATION_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COLLATION_NAME,
        [Token(Text = "COLLATION_SCHEMA", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COLLATION_SCHEMA,
        [Token(Text = "COLUMN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COLUMN,
        [Token(Text = "COLUMN_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COLUMN_NAME,
        [Token(Text = "COMMAND_FUNCTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COMMAND_FUNCTION,
        [Token(Text = "COMMIT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COMMIT,
        [Token(Text = "COMMITTED", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COMMITTED,
        [Token(Text = "CONDITION_NUMBER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONDITION_NUMBER,
        [Token(Text = "CONNECT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONNECT,
        [Token(Text = "CONNECTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONNECTION,
        [Token(Text = "CONNECTION_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONNECTION_NAME,
        [Token(Text = "CONSTRAINT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONSTRAINT,
        [Token(Text = "CONSTRAINTS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONSTRAINTS,
        [Token(Text = "CONSTRAINT_CATALOG", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONSTRAINT_CATALOG,
        [Token(Text = "CONSTRAINT_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONSTRAINT_NAME,
        [Token(Text = "CONSTRAINT_SCHEMA", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONSTRAINT_SCHEMA,
        [Token(Text = "CONSTRATIN_CATALOG", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONSTRATIN_CATALOG,
        [Token(Text = "CONTINUE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONTINUE,
        [Token(Text = "CONVERT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CONVERT,
        [Token(Text = "CORRESPONDING", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CORRESPONDING,
        [Token(Text = "COUNT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        COUNT,
        [Token(Text = "CREATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CREATE,
        [Token(Text = "CROSS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CROSS,
        [Token(Text = "CURRENT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CURRENT,
        [Token(Text = "CURRENT_DATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CURRENT_DATE,
        [Token(Text = "CURRENT_TIME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CURRENT_TIME,
        [Token(Text = "CURRENT_TIMESTAMP", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CURRENT_TIMESTAMP,
        [Token(Text = "CURRENT_USER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CURRENT_USER,
        [Token(Text = "CURSOR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CURSOR,
        [Token(Text = "CURSOR_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        CURSOR_NAME,


        // D
        [Token(Text = "DATA", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DATA,
        [Token(Text = "DATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DATE,
        [Token(Text = "DATETIME_INTERVAL_CODE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DATETIME_INTERVAL_CODE,
        [Token(Text = "DATETIME_INTERVAL_PRECISION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DATETIME_INTERVAL_PRECISION,
        [Token(Text = "DAY", Category = "function", Description = "When keyword matches.", Example = "")]
        DAY,
        [Token(Text = "DEALLOCATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DEALLOCATE,
        [Token(Text = "DEC", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DEC,
        [Token(Text = "DECIMAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DECIMAL,
        [Token(Text = "DECLARE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DECLARE,
        [Token(Text = "DEFAULT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DEFAULT,
        [Token(Text = "DEFERRABLE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DEFERRABLE,
        [Token(Text = "DEFERRED", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DEFERRED,
        [Token(Text = "DELETE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DELETE,
        [Token(Text = "DESC", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DESC,
        [Token(Text = "DESCRIBE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DESCRIBE,
        [Token(Text = "DESCRIPTOR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DESCRIPTOR,
        [Token(Text = "DIAGNOSTICS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DIAGNOSTICS,
        [Token(Text = "DISCONNECT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DISCONNECT,
        [Token(Text = "DISTINCT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DISTINCT,
        [Token(Text = "DOMAIN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DOMAIN,
        [Token(Text = "DOUBLE", Category = "datatype", Description = "When keyword matches.", Example = "")]
        DOUBLE,
        [Token(Text = "DOUBLE_PRECISION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DOUBLE_PRECISION,
        [Token(Text = "DROP", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DROP,
        [Token(Text = "DYNAMIC_FUNCTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        DYNAMIC_FUNCTION,


        // E
        [Token(Text = "ELSE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ELSE,
        [Token(Text = "END", Category = "keyword", Description = "When keyword matches.", Example = "")]
        END,
        [Token(Text = "END-EXEC", Category = "keyword", Description = "When keyword matches.", Example = "")]
        END_EXEC,
        [Token(Text = "ESCAPE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ESCAPE,
        [Token(Text = "EXCEPT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        EXCEPT,
        [Token(Text = "EXCEPTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        EXCEPTION,
        [Token(Text = "EXEC", Category = "keyword", Description = "When keyword matches.", Example = "")]
        EXEC,
        [Token(Text = "EXECUTE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        EXECUTE,
        [Token(Text = "EXISTS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        EXISTS,
        [Token(Text = "EXTERNAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        EXTERNAL,
        [Token(Text = "EXTRACT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        EXTRACT,

        // F
        [Token(Text = "FALSE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FALSE,
        [Token(Text = "FETCH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FETCH,
        [Token(Text = "FIRST", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FIRST,
        [Token(Text = "FLOAT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FLOAT,
        [Token(Text = "FOR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FOR,
        [Token(Text = "FOREIGN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FOREIGN,
        [Token(Text = "FORTRAN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FORTRAN,
        [Token(Text = "FOUND", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FOUND,
        [Token(Text = "FROM", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FROM,
        [Token(Text = "FULL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        FULL,

        // G
        [Token(Text = "GET", Category = "keyword", Description = "When keyword matches.", Example = "")]
        GET,
        [Token(Text = "GLOBAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        GLOBAL,
        [Token(Text = "GO", Category = "keyword", Description = "When keyword matches.", Example = "")]
        GO,
        [Token(Text = "GOTO", Category = "keyword", Description = "When keyword matches.", Example = "")]
        GOTO,
        [Token(Text = "GRANT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        GRANT,
        [Token(Text = "GROUP", Category = "keyword", Description = "When keyword matches.", Example = "")]
        GROUP,

        // H
        [Token(Text = "HAVING", Category = "keyword", Description = "When keyword matches.", Example = "")]
        HAVING,
        [Token(Text = "HOUR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        HOUR,

        // I
        [Token(Text = "IDENTITY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        IDENTITY,
        [Token(Text = "IMMEDIATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        IMMEDIATE,
        [Token(Text = "IN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        IN,
        [Token(Text = "INDICATOR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INDICATOR,
        [Token(Text = "INDICATOR_TYPE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INDICATOR_TYPE,
        [Token(Text = "INITIALLY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INITIALLY,
        [Token(Text = "INNER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INNER,
        [Token(Text = "INPUT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INPUT,
        [Token(Text = "INSENSITIVE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INSENSITIVE,
        [Token(Text = "INSERT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INSERT,
        [Token(Text = "INT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INT,
        [Token(Text = "INTEGER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INTEGER,
        [Token(Text = "INTERSECT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INTERSECT,
        [Token(Text = "INTERVAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INTERVAL,
        [Token(Text = "INTO", Category = "keyword", Description = "When keyword matches.", Example = "")]
        INTO,
        [Token(Text = "IS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        IS,
        [Token(Text = "ISOLATION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ISOLATION,

        // J
        [Token(Text = "JOIN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        JOIN,

        // K
        [Token(Text = "KEY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        KEY,

        // L
        [Token(Text = "LANGUAGE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        LANGUAGE,
        [Token(Text = "LAST", Category = "keyword", Description = "When keyword matches.", Example = "")]
        LAST,
        [Token(Text = "LEADING", Category = "keyword", Description = "When keyword matches.", Example = "")]
        LEADING,
        [Token(Text = "LEFT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        LEFT,
        [Token(Text = "LENGTH", Category = "function", Description = "When keyword matches.", Example = "")]
        LENGTH,
        [Token(Text = "LEVEL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        LEVEL,
        [Token(Text = "LIKE", Category = "operator", Description = "When keyword matches.", Example = "")]
        LIKE,
        [Token(Text = "LOCAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        LOCAL,
        [Token(Text = "LOWER", Category = "function", Description = "When keyword matches.", Example = "")]
        LOWER,

        // M
        [Token(Text = "MATCH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MATCH,
        [Token(Text = "MAX", Category = "function", Description = "When keyword matches.", Example = "")]
        MAX,
        [Token(Text = "MESSAGE_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MESSAGE_LENGTH,
        [Token(Text = "MESSAGE_OCTET_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MESSAGE_OCTET_LENGTH,
        [Token(Text = "MESSAGE_TEXT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MESSAGE_TEXT,
        [Token(Text = "MIN", Category = "function", Description = "When keyword matches.", Example = "")]
        MIN,
        [Token(Text = "MINUTE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MINUTE,
        [Token(Text = "MODULE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MODULE,
        [Token(Text = "MONTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MONTH,
        [Token(Text = "MORE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MORE,
        [Token(Text = "MUMPS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        MUMPS,

        // N
        [Token(Text = "NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NAME,
        [Token(Text = "NAMES", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NAMES,
        [Token(Text = "NATIONAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NATIONAL,
        [Token(Text = "NATURAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NATURAL,
        [Token(Text = "NCHAR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NCHAR,
        [Token(Text = "NEXT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NEXT,
        [Token(Text = "NO", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NO,
        [Token(Text = "NOT", Category = "function", Description = "When keyword matches.", Example = "")]
        NOT,
        [Token(Text = "NULL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NULL,
        [Token(Text = "NULLABLE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        NULLABLE,
        [Token(Text = "NULLIF", Category = "function", Description = "When keyword matches.", Example = "")]
        NULLIF,
        [Token(Text = "NUMBER", Category = "datatype", Description = "When keyword matches.", Example = "")]
        NUMBER,
        [Token(Text = "NUMERIC", Category = "datatype", Description = "When keyword matches.", Example = "")]
        NUMERIC,

        // O
        [Token(Text = "OCTET_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OCTET_LENGTH,
        [Token(Text = "OF", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OF,
        [Token(Text = "ON", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ON,
        [Token(Text = "ONLY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ONLY,
        [Token(Text = "OPEN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OPEN,
        [Token(Text = "OPTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OPTION,
        [Token(Text = "OR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OR,
        [Token(Text = "ORDER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ORDER,
        [Token(Text = "OUTER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OUTER,
        [Token(Text = "OUTPUT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OUTPUT,
        [Token(Text = "OVERLAPS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        OVERLAPS,

        // P
        [Token(Text = "PAD", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PAD,
        [Token(Text = "PARTIAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PARTIAL,
        [Token(Text = "PASCAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PASCAL,
        [Token(Text = "PLI", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PLI,
        [Token(Text = "POSITION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        POSITION,
        [Token(Text = "PRECISION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PRECISION,
        [Token(Text = "PREPARE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PREPARE,
        [Token(Text = "PRESERVE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PRESERVE,
        [Token(Text = "PRIMARY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PRIMARY,
        [Token(Text = "PRIOR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PRIOR,
        [Token(Text = "PRIVILEGES", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PRIVILEGES,
        [Token(Text = "PROCEDURE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PROCEDURE,
        [Token(Text = "PUBLIC", Category = "keyword", Description = "When keyword matches.", Example = "")]
        PUBLIC,

        // R
        [Token(Text = "READ", Category = "keyword", Description = "When keyword matches.", Example = "")]
        READ,
        [Token(Text = "REAL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        REAL,
        [Token(Text = "REFERENCES", Category = "keyword", Description = "When keyword matches.", Example = "")]
        REFERENCES,
        [Token(Text = "RELATIVE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        RELATIVE,
        [Token(Text = "REPEATABLE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        REPEATABLE,
        [Token(Text = "RESTRICT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        RESTRICT,
        [Token(Text = "RETURNED_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        RETURNED_LENGTH,
        [Token(Text = "RETURNED_OCTET_LENGTH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        RETURNED_OCTET_LENGTH,
        [Token(Text = "RETURNED_SQLSTATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        RETURNED_SQLSTATE,
        [Token(Text = "REVOKE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        REVOKE,
        [Token(Text = "RIGHT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        RIGHT,
        [Token(Text = "ROLLBACK", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ROLLBACK,
        [Token(Text = "ROWS", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ROWS,
        [Token(Text = "ROW_COUNT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ROW_COUNT,

        // S
        [Token(Text = "SCALE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SCALE,
        [Token(Text = "SCHEMA", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SCHEMA,
        [Token(Text = "SCHEMA_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SCHEMA_NAME,
        [Token(Text = "SCROLL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SCROLL,
        [Token(Text = "SECOND", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SECOND,
        [Token(Text = "SECTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SECTION,
        [Token(Text = "SELECT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SELECT,
        [Token(Text = "SERIALIZABLE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SERIALIZABLE,
        [Token(Text = "SERVER_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SERVER_NAME,
        [Token(Text = "SESSION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SESSION,
        [Token(Text = "SESSION_USER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SESSION_USER,
        [Token(Text = "SET", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SET,
        [Token(Text = "SIZE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SIZE,
        [Token(Text = "SMALLINT", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SMALLINT,
        [Token(Text = "SOME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SOME,
        [Token(Text = " ", Category = "keyword", Description = "When keyword matches.", Example = " ")]
        SPACE,
        [Token(Text = "SQL", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SQL,
        [Token(Text = "SQLCODE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SQLCODE,
        [Token(Text = "SQLCODE_TYPE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SQLCODE_TYPE,
        [Token(Text = "SQLERROR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SQLERROR,
        [Token(Text = "SQLSTATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SQLSTATE,
        [Token(Text = "SQLSTATE_TYPE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SQLSTATE_TYPE,
        [Token(Text = "SQL_STANDARD", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SQL_STANDARD,
        [Token(Text = "SUBCLASS_ORIGIN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SUBCLASS_ORIGIN,
        [Token(Text = "SUBSTRING", Category = "function", Description = "When keyword matches.", Example = "")]
        SUBSTRING,
        [Token(Text = "SUM", Category = "function", Description = "When keyword matches.", Example = "")]
        SUM,
        [Token(Text = "SYSTEM_USER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        SYSTEM_USER,

        // T
        [Token(Text = "TABLE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TABLE,
        [Token(Text = "TABLE_NAME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TABLE_NAME,
        [Token(Text = "TEMPORARY", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TEMPORARY,
        [Token(Text = "THEN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        THEN,
        [Token(Text = "TIME", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TIME,
        [Token(Text = "TIMESTAMP", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TIMESTAMP,
        [Token(Text = "TIMEZONE_HOUR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TIMEZONE_HOUR,
        [Token(Text = "TIMEZONE_MINUTE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TIMEZONE_MINUTE,
        [Token(Text = "TO", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TO,
        [Token(Text = "TRAILING", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TRAILING,
        [Token(Text = "TRANSACTION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TRANSACTION,
        [Token(Text = "TRANSLATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TRANSLATE,
        [Token(Text = "TRANSLATION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TRANSLATION,
        [Token(Text = "TRIM", Category = "function", Description = "When keyword matches.", Example = "")]
        TRIM,
        [Token(Text = "TRUE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TRUE,
        [Token(Text = "TYPE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        TYPE,

        // U
        [Token(Text = "UNCOMMITTED", Category = "keyword", Description = "When keyword matches.", Example = "")]
        UNCOMMITTED,
        [Token(Text = "UNION", Category = "keyword", Description = "When keyword matches.", Example = "")]
        UNION,
        [Token(Text = "UNIQUE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        UNIQUE,
        [Token(Text = "UNKNOWN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        UNKNOWN,
        [Token(Text = "UNNAMED", Category = "keyword", Description = "When keyword matches.", Example = "")]
        UNNAMED,
        [Token(Text = "UPDATE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        UPDATE,
        [Token(Text = "UPPER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        UPPER,
        [Token(Text = "USAGE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        USAGE,
        [Token(Text = "USER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        USER,
        [Token(Text = "USING", Category = "keyword", Description = "When keyword matches.", Example = "")]
        USING,

        // V
        [Token(Text = "VALUE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        VALUE,
        [Token(Text = "VALUES", Category = "keyword", Description = "When keyword matches.", Example = "")]
        VALUES,
        [Token(Text = "VARCHAR", Category = "keyword", Description = "When keyword matches.", Example = "")]
        VARCHAR,
        [Token(Text = "VARYING", Category = "keyword", Description = "When keyword matches.", Example = "")]
        VARYING,
        [Token(Text = "VIEW", Category = "keyword", Description = "When keyword matches.", Example = "")]
        VIEW,

        // W
        [Token(Text = "WHEN", Category = "keyword", Description = "When keyword matches.", Example = "")]
        WHEN,
        [Token(Text = "WHENEVER", Category = "keyword", Description = "When keyword matches.", Example = "")]
        WHENEVER,
        [Token(Text = "WHERE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        WHERE,
        [Token(Text = "WITH", Category = "keyword", Description = "When keyword matches.", Example = "")]
        WITH,
        [Token(Text = "WORK", Category = "keyword", Description = "When keyword matches.", Example = "")]
        WORK,
        [Token(Text = "WRITE", Category = "function", Description = "When keyword matches.", Example = "")]
        WRITE,

        // Y
        [Token(Text = "YEAR", Category = "function", Description = "When keyword matches.", Example = "")]
        YEAR,

        // Z
        [Token(Text = "ZONE", Category = "keyword", Description = "When keyword matches.", Example = "")]
        ZONE

    }

}