grammar Ehh;

start : 'ehh' LB
            (attribPair)*
        RB;
        
attribPair : ID ':' attribValue NEWLINE;
attribValue : INT | FILENAME | INT ',' INT ',' INT;

LB : [{];
RB : [}];
INT : [0-9]+;
ID : [a-zA-Z]+;
NEWLINE : [\r\n]+;
FILENAME : [a-zA-Z0-9.]+;
WS : [ \t\r\n]+ -> skip;
