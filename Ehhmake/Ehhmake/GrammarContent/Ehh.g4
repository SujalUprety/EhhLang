grammar Ehh;

start : 'ehh' LB
            'width:' widthValue
            'height:' heightValue
            'background:' colorValue
            'output:' outputValue
        RB;
        
widthValue : INT;
heightValue : INT;
colorValue : INT ',' INT ',' INT;
outputValue : FILENAME;

LB : [{];
RB : [}];
INT : [0-9]+;
ID : [a-zA-Z]+;
FILENAME : [a-zA-Z0-9.]+;
WS : [ \t\r\n]+ -> skip;
