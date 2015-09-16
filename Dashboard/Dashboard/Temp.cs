//#include <Wire.h>  
//#define SLAVE_ADDRESS 0x40   // Define the i2c address

//char tempera[5];
//void setup()
//{
//    pinMode(13, OUTPUT);

//    Serial.begin(9600);
//    Wire.begin(SLAVE_ADDRESS);
//    Wire.onRequest(sendData);
//    Wire.onReceive(receiveData);

//    tempera[0] = 0;
//    tempera[1] = 0;
//    tempera[2] = 0;
//    tempera[3] = 0;
//    tempera[4] = 0;
//}

//void loop()
//{
//    tempera[0] += 1;
//    tempera[1] += 2;
//    tempera[2] += 3;
//    tempera[3] += 4;
//    tempera[4] += 5;
//    delay(500);
//}

//byte state = 0;

//// callback for received data
//void receiveData(int byteCount)
//{
//    byte Mode;
//    byte Pin;
//    byte SetValue;
//    Mode = Wire.read();
//    Pin = Wire.read();
//    SetValue = Wire.read();

//    Serial.print(Mode]);
//    Serial.print(" ");
//    Serial.print(Pin);
//    Serial.print(" ");
//    Serial.println(SetValue);
//}

//void sendData()
//{
//    Wire.write(tempera);
//}