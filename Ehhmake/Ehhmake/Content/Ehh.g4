grammar Ehh;

program: (function (NEWLINE)?)* EOF;
        
function: functionIdentifier LB
            (attribPair)*
        RB;
        
functionIdentifier: preFunctionName (symbol functionName)?;
    
symbol: '::';
preFunctionName: ID;
functionName: ID;
        
attribPair : ID ':' attribValue (NEWLINE)?;
attribValue : INT | FILENAME | INT ',' INT ',' INT | ID | STRING;

LB : [{];
RB : [}];

INT : [0-9]+;
ID : [a-zA-Z]+;

STRING: '"' .*? '"';
NEWLINE : [\r\n]+;
FILENAME : [a-zA-Z0-9.]+;

WS : [ \t\r\n]+ -> skip;