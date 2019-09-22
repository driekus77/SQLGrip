using SQLGrip.Keyword;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLGrip.Database.ANSI
{
    public class Sql92KeywordTable : BaseSqlKeywordTable
    {

        public Sql92KeywordTable()
        {
            // A
            Add("ABSOLUTE", "", "ABSOLUTE");
            Add("ACTION", "", "ACTION");
            Add("ADA", "", "ADA");
            Add("ADD", "", "ADD");
            Add("ALL", "", "ALL");
            Add("ALLOCATE", "", "ALLOCATE");
            Add("ALTER", "", "ALTER");
            Add("AND", "", "AND");
            Add("ANY", "", "ANY");
            Add("ARE", "", "ARE");
            Add("AS", "", "AS");
            Add("ASC", "", "ASC");
            Add("ANY", "", "ANY");
            Add("ASSERTION", "", "ASSERTION");
            Add("AT", "", "AT");
            Add("AUTHORIZATION", "", "AUTHORIZATION");
            Add("AVG", "", "AVG");

            // B
            Add("BEGIN", "", "BEGIN");
            Add("BETWEEN", "", "BETWEEN");
            Add("BIT", "", "BIT");
            Add("BIT_LENGTH", "", "BIT_LENGTH");
            Add("BOTH", "", "BOTH");
            Add("BY", "", "BY");

            // C
            Add("CASCADE", "", "CASCADE");
            Add("CASCADED", "", "CASCADED");
            Add("CASE", "", "CASE");
            Add("CAST", "", "CAST");
            Add("CATALOG", "", "CATALOG");
            Add("CATALOG_NAME", "", "CATALOG_NAME");
            Add("CHAR", "", "CHAR");
            Add("CHARACTER", "", "CHARACTER");
            Add("CHARACTER_LENGTH", "", "CHARACTER_LENGTH");
            Add("CHARACTER_SET_CATALOG", "", "CHARACTER_SET_CATALOG");
            Add("CHARACTER_SET_NAME", "", "CHARACTER_SET_NAME");
            Add("CHARACTER_SET_SCHEMA", "", "CHARACTER_SET_SCHEMA");
            Add("CHAR_LENGTH", "", "CHAR_LENGTH");
            Add("CHECK", "", "CHECK");
            Add("CLASS_ORIGIN", "", "CLASS_ORIGIN");
            Add("CLOSE", "", "CLOSE");
            Add("COALESCE", "", "COALESCE");
            Add("COLLATE", "", "COLLATE");
            Add("COLLATION", "", "COLLATION");
            Add("COLLATION_CATALOG", "", "COLLATION_CATALOG");
            Add("COLLATION_NAME", "", "COLLATION_NAME");
            Add("COLLATION_SCHEMA", "", "COLLATION_SCHEMA");
            Add("COLUMN", "", "COLUMN");
            Add("COLUMN_NAME", "", "COLUMN_NAME");
            Add("COMMAND_FUNCTION", "", "COMMAND_FUNCTION");
            Add("COMMIT", "", "COMMIT");
            Add("COMMITTED", "", "COMMITTED");
            Add("CONDITION_NUMBER", "", "CONDITION_NUMBER");
            Add("CONNECT", "", "CONNECT");
            Add("CONNECTION", "", "CONNECTION");
            Add("CONNECTION_NAME", "", "CONNECTION_NAME");
            Add("CONSTRAINT", "", "CONSTRAINT");
            Add("CONSTRAINTS", "", "CONSTRAINTS");
            Add("CONSTRAINT_CATALOG", "", "CONSTRAINT_CATALOG");
            Add("CONSTRAINT_NAME", "", "CONSTRAINT_NAME");
            Add("CONSTRAINT_SCHEMA", "", "CONSTRAINT_SCHEMA");
            Add("CONSTRATIN_CATALOG", "", "CONSTRATIN_CATALOG");
            Add("CONTINUE", "", "CONTINUE");
            Add("CONVERT", "", "CONVERT");
            Add("CORRESPONDING", "", "CORRESPONDING");
            Add("COUNT", "", "COUNT");
            Add("CREATE", "", "CREATE");
            Add("CROSS", "", "CROSS");
            Add("CURRENT", "", "CURRENT");
            Add("CURRENT_DATE", "", "CURRENT_DATE");
            Add("CURRENT_TIME", "", "CURRENT_TIME");
            Add("CURRENT_TIMESTAMP", "", "CURRENT_TIMESTAMP");
            Add("CURRENT_USER", "", "CURRENT_USER");
            Add("CURSOR", "", "CURSOR");
            Add("CURSOR_NAME", "", "CURSOR_NAME");

            // D
            Add("DATA", "", "DATA");
            Add("DATE", "", "DATE");
            Add("DATETIME_INTERVAL_CODE", "", "DATETIME_INTERVAL_CODE");
            Add("DATETIME_INTERVAL_PRECISION", "", "DATETIME_INTERVAL_PRECISION");
            Add("DAY", "", "DAY");
            Add("DEALLOCATE", "", "DEALLOCATE");
            Add("DEC", "", "DEC");
            Add("DECIMAL", "", "DECIMAL");
            Add("DECLARE", "", "DECLARE");
            Add("DEFAULT", "", "DEFAULT");
            Add("DEFERRABLE", "", "DEFERRABLE");
            Add("DEFERRED", "", "DEFERRED");
            Add("DELETE", "", "DELETE");
            Add("DESC", "", "DESC");
            Add("DESCRIBE", "", "DESCRIBE");
            Add("DESCRIPTOR", "", "DESCRIPTOR");
            Add("DIAGNOSTICS", "", "DIAGNOSTICS");
            Add("DISCONNECT", "", "DISCONNECT");
            Add("DISTINCT", "", "DISTINCT");
            Add("DOMAIN", "", "DOMAIN");
            Add("DOUBLE", "", "DOUBLE");
            Add("DOUBLE_PRECISION", "", "DOUBLE_PRECISION");
            Add("DROP", "", "DROP");
            Add("DYNAMIC_FUNCTION", "", "DYNAMIC_FUNCTION");
            Add("ELSE", "", "ELSE");
            Add("END", "", "END");
            Add("END-EXEC", "", "END-EXEC");
            Add("ESCAPE", "", "ESCAPE");
            Add("EXCEPT", "", "EXCEPT");
            Add("EXCEPTION", "", "EXCEPTION");
            Add("EXEC", "", "EXEC");
            Add("EXECUTE", "", "EXECUTE");
            Add("EXISTS", "", "EXISTS");
            Add("EXTERNAL", "", "EXTERNAL");
            Add("EXTRACT", "", "EXTRACT");

            // F
            Add("FALSE", "", "FALSE");
            Add("FETCH", "", "FETCH");
            Add("FIRST", "", "FIRST");
            Add("FLOAT", "", "FLOAT");
            Add("FOR", "", "FOR");
            Add("FOREIGN", "", "FOREIGN");
            Add("FORTRAN", "", "FORTRAN");
            Add("FOUND", "", "FOUND");
            Add("FROM", "", "FROM");
            Add("FULL", "", "FULL");

            // G
            Add("GET", "", "GET");
            Add("GLOBAL", "", "GLOBAL");
            Add("GO", "", "GO");
            Add("GOTO", "", "GOTO");
            Add("GRANT", "", "GRANT");
            Add("GROUP", "", "GROUP");

            // H
            Add("HAVING", "", "HAVING");
            Add("HOUR", "", "HOUR");

            // I
            Add("IDENTITY", "", "IDENTITY");
            Add("IMMEDIATE", "", "IMMEDIATE");
            Add("IN", "", "IN");
            Add("INDICATOR", "", "INDICATOR");
            Add("INDICATOR_TYPE", "", "INDICATOR_TYPE");
            Add("INITIALLY", "", "INITIALLY");
            Add("INNER", "", "INNER");
            Add("INPUT", "", "INPUT");
            Add("INSENSITIVE", "", "INSENSITIVE");
            Add("INSERT", "", "INSERT");
            Add("INT", "", "INT");
            Add("INTEGER", "", "INTEGER");
            Add("INTERSECT", "", "INTERSECT");
            Add("INTERVAL", "", "INTERVAL");
            Add("INTO", "", "INTO");
            Add("IS", "", "IS");
            Add("ISOLATION", "", "ISOLATION");

            // J
            Add("JOIN", "", "JOIN");

            // K
            Add("KEY", "", "KEY");

            // L
            Add("LANGUAGE", "", "LANGUAGE");
            Add("LAST", "", "LAST");
            Add("LEADING", "", "LEADING");
            Add("LEFT", "", "LEFT");
            Add("LENGTH", "", "LENGTH");
            Add("LEVEL", "", "LEVEL");
            Add("LIKE", "", "LIKE");
            Add("LOCAL", "", "LOCAL");
            Add("LOWER", "", "LOWER");

            // M
            Add("MATCH", "", "MATCH");
            Add("MAX", "", "MAX");
            Add("MESSAGE_LENGTH", "", "MESSAGE_LENGTH");
            Add("MESSAGE_OCTET_LENGTH", "", "MESSAGE_OCTET_LENGTH");
            Add("MESSAGE_TEXT", "", "MESSAGE_TEXT");
            Add("MIN", "", "MIN");
            Add("MINUTE", "", "MINUTE");
            Add("MODULE", "", "MODULE");
            Add("MONTH", "", "MONTH");
            Add("MORE", "", "MORE");
            Add("MUMPS", "", "MUMPS");

            // N
            Add("NAME", "", "NAME");
            Add("NAMES", "", "NAMES");
            Add("NATIONAL", "", "NATIONAL");
            Add("NATURAL", "", "NATURAL");
            Add("NCHAR", "", "NCHAR");
            Add("NEXT", "", "NEXT");
            Add("NO", "", "NO");
            Add("NOT", "", "NOT");
            Add("NULL", "", "NULL");
            Add("NULLABLE", "", "NULLABLE");
            Add("NULLIF", "", "NULLIF");
            Add("NUMBER", "", "NUMBER");
            Add("NUMERIC", "", "NUMERIC");

            // O
            Add("OCTET_LENGTH", "", "OCTET_LENGTH");
            Add("OF", "", "OF");
            Add("ON", "", "ON");
            Add("ONLY", "", "ONLY");
            Add("OPEN", "", "OPEN");
            Add("OPTION", "", "OPTION");
            Add("OR", "", "OR");
            Add("ORDER", "", "ORDER");
            Add("OUTER", "", "OUTER");
            Add("OUTPUT", "", "OUTPUT");
            Add("OVERLAPS", "", "OVERLAPS");

            // P
            Add("PAD", "", "PAD");
            Add("PARTIAL", "", "PARTIAL");
            Add("PASCAL", "", "PASCAL");
            Add("PLI", "", "PLI");
            Add("POSITION", "", "POSITION");
            Add("PRECISION", "", "PRECISION");
            Add("PREPARE", "", "PREPARE");
            Add("PRESERVE", "", "PRESERVE");
            Add("PRIMARY", "", "PRIMARY");
            Add("PRIOR", "", "PRIOR");
            Add("PRIVILEGES", "", "PRIVILEGES");
            Add("PROCEDURE", "", "PROCEDURE");
            Add("PUBLIC", "", "PUBLIC");

            // R
            Add("READ", "", "READ");
            Add("REAL", "", "REAL");
            Add("REFERENCES", "", "REFERENCES");
            Add("RELATIVE", "", "RELATIVE");
            Add("REPEATABLE", "", "REPEATABLE");
            Add("RESTRICT", "", "RESTRICT");
            Add("RETURNED_LENGTH", "", "RETURNED_LENGTH");
            Add("RETURNED_OCTET_LENGTH", "", "RETURNED_OCTET_LENGTH");
            Add("RETURNED_SQLSTATE", "", "RETURNED_SQLSTATE");
            Add("REVOKE", "", "REVOKE");
            Add("RIGHT", "", "RIGHT");
            Add("ROLLBACK", "", "ROLLBACK");
            Add("ROWS", "", "ROWS");
            Add("ROW_COUNT", "", "ROW_COUNT");

            // S
            Add("SCALE", "", "SCALE");
            Add("SCHEMA", "", "SCHEMA");
            Add("SCHEMA_NAME", "", "SCHEMA_NAME");
            Add("SCROLL", "", "SCROLL");
            Add("SECOND", "", "SECOND");
            Add("SECTION", "", "SECTION");
            Add("SELECT", "", "SELECT");
            Add("SERIALIZABLE", "", "SERIALIZABLE");
            Add("SERVER_NAME", "", "SERVER_NAME");
            Add("SESSION", "", "SESSION");
            Add("SESSION_USER", "", "SESSION_USER");
            Add("SET", "", "SET");
            Add("SIZE", "", "SIZE");
            Add("SMALLINT", "", "SMALLINT");
            Add("SOME", "", "SOME");
            Add("SPACE", "", "SPACE");
            Add("SQL", "", "SQL");
            Add("SQLCODE", "", "SQLCODE");
            Add("SQLCODE_TYPE", "", "SQLCODE_TYPE");
            Add("SQLERROR", "", "SQLERROR");
            Add("SQLSTATE", "", "SQLSTATE");
            Add("SQLSTATE_TYPE", "", "SQLSTATE_TYPE");
            Add("SQL_STANDARD", "", "SQL_STANDARD");
            Add("SUBCLASS_ORIGIN", "", "SUBCLASS_ORIGIN");
            Add("SUBSTRING", "", "SUBSTRING");
            Add("SUM", "", "SUM");
            Add("SYSTEM_USER", "", "SYSTEM_USER");

            // T
            Add("TABLE", "", "TABLE");
            Add("TABLE_NAME", "", "TABLE_NAME");
            Add("TEMPORARY", "", "TEMPORARY");
            Add("THEN", "", "THEN");
            Add("TIME", "", "TIME");
            Add("TIMESTAMP", "", "TIMESTAMP");
            Add("TIMEZONE_HOUR", "", "TIMEZONE_HOUR");
            Add("TIMEZONE_MINUTE", "", "TIMEZONE_MINUTE");
            Add("TO", "", "TO");
            Add("TRAILING", "", "TRAILING");
            Add("TRANSACTION", "", "TRANSACTION");
            Add("TRANSLATE", "", "TRANSLATE");
            Add("TRANSLATION", "", "TRANSLATION");
            Add("TRIM", "", "TRIM");
            Add("TRUE", "", "TRUE");
            Add("TYPE", "", "TYPE");

            // U
            Add("UNCOMMITTED", "", "UNCOMMITTED");
            Add("UNION", "", "UNION");
            Add("UNIQUE", "", "UNIQUE");
            Add("UNKNOWN", "", "UNKNOWN");
            Add("UNNAMED", "", "UNNAMED");
            Add("UPDATE", "", "UPDATE");
            Add("UPPER", "", "UPPER");
            Add("USAGE", "", "USAGE");
            Add("USER", "", "USER");
            Add("USING", "", "USING");

            // V
            Add("VALUE", "", "VALUE");
            Add("VALUES", "", "VALUES");
            Add("VARCHAR", "", "VARCHAR");
            Add("VARYING", "", "VARYING");
            Add("VIEW", "", "VIEW");

            // W
            Add("WHEN", "", "WHEN");
            Add("WHENEVER", "", "WHENEVER");
            Add("WHERE", "", "WHERE");
            Add("WITH", "", "WITH");
            Add("WORK", "", "WORK");
            Add("WRITE", "", "WRITE");

            // Y
            Add("YEAR", "", "YEAR");

            // Z
            Add("ZONE", "", "ZONE");
        }


    }
}
