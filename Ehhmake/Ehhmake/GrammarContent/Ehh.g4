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
outputValue : ID;

INT : [0-9]+ ;
ID : [a-zA-Z]+ ;
WS : [ \t\r\n]+ -> skip ;
