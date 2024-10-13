grammar Ehh;

program: (object (NEWLINE)?)* EOF;
        
object: objectIdentifier LB
            (attribPair)*
        RB;
        
objectIdentifier: preObjectName ( symbol objectName)?;
    
symbol: '::';
preObjectName: ID (ID | INT)*;
objectName: ID (ID | INT)*;
        
attribPair : attribName ':' attribValue (NEWLINE)?;
attribValue : INT | INT ',' INT ',' INT | ID | STRING;

attribName: ID ('[' INT ']')?;

LB : [{];
RB : [}];

INT : [0-9]+;
ID : [a-zA-Z]+;
STRING: '"' .*? '"';
NEWLINE : [\r\n]+;
WS : [ \t\r\n]+ -> skip;