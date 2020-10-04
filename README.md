# SQLGrip
Lets get grip on your SQL: SQLFirst Coding with a SQL parser & builder!

Note: Work in Progress => Help Wanted!

Idea's what this library can become:
- Add-on for C# Dapper Micro ORM: Don't rebuild the SQL Generation for every C# Project...
- Validate your SQL files
- Compare SQL Statements
- Safe Filtering and Paging support added to your SQL Select Statements
- ...

Parse Example (From UnitTests):

    var stmnt = Parser.Parse("select hello AS h, by As b, seeya as s from greetings g, people p");
    
    var node = stmnt.FirstOrDefault(x => x.IsNodeType<ISqlColumnExpressionListNode>(), true); // true is deep searching into node tree
    ...

Thanks to:
- Dapper.SqlBuilder idea which this SQLGrip libray is based on: https://github.com/StackExchange/Dapper/blob/master/Dapper.SqlBuilder
- Superpower: A parser combinator library which makes the SQL Parsing possible: https://github.com/datalust/superpower

