grammar PLC_Lab8_expr;

/** The start rule; begin parsing here. */
program: statement+ ;

statement
    : '{' statement* '}'                             # parens1
    | primitiveType IDENTIFIER (',' IDENTIFIER)* ';' # declaration
    | expr ';'                                       # printExpr
    | WRITE expr (',' expr)* ';'                     # writeExpr
    | READ expr (',' expr)* ';'                      # readExpr
    | IF expr statement                              # ifExpr
    | ELSE statement                                 # elseExpr
    | WHILE expr statement                           # whileExpr
    | ';'                                            # empty
    ;

expr: expr op=(MUL|DIV|MOD) expr            # mulDivMod
    | expr op=(ADD|SUB|DOT) expr            # addSubDot
    | expr op=(GT|LT|EQUAL|NOTEQUAL) expr   # gtLtEquNotEqu
    | expr op=(AND|OR) expr                 # andOr
    | INT                                   # int
    | IDENTIFIER                            # id
    | FLOAT                                 # float
    | STRING                                # string
    | BOOL                                  # bool
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

IDENTIFIER : [a-zA-Z]+ ; 
FLOAT : [0-9]+'.'[0-9]+ ;
INT : [0-9]+ ;
BOOL : 'true' | 'false' ;
STRING : '"' ~["]* '"';

WS : [ \t\r\n]+ -> skip ; // toss out whitespace
LINE_COMMENT: '//' ~[\r\n]* -> channel(HIDDEN) ;