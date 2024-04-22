grammar PLC_Lab8_expr;

/** The start rule; begin parsing here. */
program: statement+ ;

statement
    : '{' statement* '}'                             # parens1
    | primitiveType IDENTIFIER (',' IDENTIFIER)* ';' # declaration
    | expr ';'                                       # printExpr
    | WRITE expr (',' expr)* ';'                     # writeExpr
    | READ IDENTIFIER (',' IDENTIFIER)* ';'          # readExpr
    | IF expr statement (ELSE statement)?            # ifExpr
    | WHILE expr statement                           # whileExpr
    | FOR '(' expr ';' expr ';' expr ')' statement   # forExpr
    | ';'                                            # empty
    ;

expr: expr op=(MUL|DIV|MOD) expr            # mulDivMod
    | expr op=(ADD|SUB|DOT) expr            # addSubDot
    | expr op=(GT|LT|EQUAL|NOTEQUAL) expr   # gtLtEquNotEqu
    | expr op=(AND|OR) expr                 # andOr
    | INT                                   # int
    | BOOL                                  # bool
    | FLOAT                                 # float
    | STRING                                # string
    | IDENTIFIER                            # id
    | BANG expr                             # bang
    | SUB expr                              # unarySub
    | '(' expr ')'                          # parens
    | <assoc=right> IDENTIFIER '=' expr     # assignment
    ;

primitiveType
    : type=INT_KEYWORD
    | type=FLOAT_KEYWORD
    | type=STRING_KEYWORD
    | type=BOOL_KEYWORD
    ;


WRITE : 'write' ;
READ : 'read' ;

FOR : 'for' ;

IF : 'if' ;
ELSE : 'else' ;
WHILE : 'while' ;

INT_KEYWORD : 'int';
FLOAT_KEYWORD : 'float';
STRING_KEYWORD : 'string';
BOOL_KEYWORD : 'bool';
SEMI:               ';';
COMMA:              ',';
MUL : '*' ; 
DIV : '/' ;
ADD : '+' ;
SUB : '-' ;
MOD : '%' ;
DOT : '.' ;
GT : '>' ;
LT : '<' ;
EQUAL : '==';
NOTEQUAL : '!=';
AND : '&&';
OR : '||';
BANG : '!';

FLOAT : [0-9]+'.'[0-9]+ ;
INT : [0-9]+ ;
BOOL : 'true' | 'false' ;
STRING: '"' (~["\r\n] | '""')* '"';
IDENTIFIER : [a-zA-Z]+ ; 

WS : [ \t\r\n]+ -> skip ; // toss out whitespace
LINE_COMMENT: '//' ~[\r\n]* -> channel(HIDDEN) ;