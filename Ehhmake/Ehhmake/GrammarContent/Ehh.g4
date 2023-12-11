grammar Ehh;

start : 'ehh' '{'
            'width:' widthValue
            'height:' heightValue
            'background:' colorValue
            'output:' outputValue
        '}';
        
widthValue : INT;
heightValue : INT;
colorValue : INT ',' INT ',' INT;
outputValue : FILENAME;

INT : [0-9]+ ;
ID : [a-zA-Z]+;
FILENAME : [a-zA-Z0-9.]+;
WS : [ \t\r\n]+ -> skip;
