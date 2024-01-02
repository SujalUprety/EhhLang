grammar Ehh;

program: (object (NEWLINE)?)* EOF;
        
object: objectIdentifier LB
            (attribPair)*
        RB;
        
objectIdentifier: preObjectName ( (' ')? symbol (' ')? objectName)?;
    
symbol: '::';
preObjectName: ID;
objectName: ID;
        
attribPair : ID (' ' INT)? ':' attribValue (NEWLINE)?;
attribValue : INT | FILENAME | INT ',' INT ',' INT | ID | STRING;

LB : [{];
RB : [}];

INT : [0-9]+;
ID : [a-zA-Z] [a-zA-Z0-9]*;

STRING: '"' .*? '"';
NEWLINE : [\r\n]+;
FILENAME : [a-zA-Z0-9.]+;

WS : [ \t\r\n]+ -> skip;