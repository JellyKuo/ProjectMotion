#include "SoftwareSerial.h"
#include "ArduinoJson.h"

SoftwareSerial btSerial(10, 11);

void setup()
{
    Serial.begin(38400);
    Serial.println("ProjectMotion");
    btSerial.begin(38400);
}

void loop()
{
    if (!btSerial.available())
        return;
    StaticJsonBuffer<200> jsonBuffer;
    JsonObject& json = jsonBuffer.parseObject(btSerial);
    int id = json["id"];
    Serial.println("id: " + String(id));
    switch(id){
      case 0x1001:
      int intensity = json["intensity"];
      vibrate(intensity);
      break;
    }
}

void vibrate(int intensity)
{
    Serial.println("Vibrate with " + String(intensity) + " intensity");
}
