grammar Ehh;

program: (function)* EOF;
        
function: ID LB
            (attribPair)*
        RB;
        
attribPair : ID ':' attribValue NEWLINE;
attribValue : INT | FILENAME | INT ',' INT ',' INT | ID | STRING;

LB : [{];
RB : [}];

INT : [0-9]+;
ID : [a-zA-Z]+;
STRING: '"' .*? '"';
NEWLINE : [\r\n]+;
FILENAME : [a-zA-Z0-9.]+;
WS : [ \t\r\n]+ -> skip;
