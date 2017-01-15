char incomingByte = 0;  
int relayValues[6] = {LOW,LOW,LOW,LOW,LOW,LOW};

void setup() 
{
   Serial.begin(9600);
   pinMode(2,OUTPUT);
   pinMode(3,OUTPUT);
   pinMode(4,OUTPUT);
   pinMode(5,OUTPUT);
   pinMode(6,OUTPUT);
   pinMode(7,OUTPUT);
   
   pinMode(8,OUTPUT);
   pinMode(9,OUTPUT);
   pinMode(10,OUTPUT);
   pinMode(11,OUTPUT);
   pinMode(12,OUTPUT);
   pinMode(13,OUTPUT);

   digitalWrite(8,LOW);
   digitalWrite(9,LOW);
   digitalWrite(10,LOW);
   digitalWrite(11,LOW);
   digitalWrite(12,LOW);
   digitalWrite(13,LOW);
}

void loop() 
{
   if (Serial.available() > 0)
   {
      incomingByte = ((char)Serial.read());
      if(incomingByte == '1')
        relayValues[0] = relayValues[0]==HIGH? LOW : HIGH;
      if(incomingByte == '2')
        relayValues[1] = relayValues[1]==HIGH? LOW : HIGH;
      if(incomingByte == '3')
        relayValues[2] = relayValues[2]==HIGH? LOW : HIGH;
      if(incomingByte == '4')
        relayValues[3] = relayValues[3]==HIGH? LOW : HIGH;
      if(incomingByte == '5')
        relayValues[4] = relayValues[4]==HIGH? LOW : HIGH;
      if(incomingByte == '6')
        relayValues[5] = relayValues[5]==HIGH? LOW : HIGH;

   }
   digitalWrite(2,relayValues[0]);
   digitalWrite(3,relayValues[1]);
   digitalWrite(4,relayValues[2]);
   digitalWrite(5,relayValues[3]);
   digitalWrite(6,relayValues[4]);
   digitalWrite(7,relayValues[5]);
   
}
