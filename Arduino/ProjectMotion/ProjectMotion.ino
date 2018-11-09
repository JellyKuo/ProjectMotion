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
    String data = btSerial.readString();
    Serial.println("Data: " + data);
    // StaticJsonBuffer<44> jsonBuffer;
    // JsonObject& jObj = jsonBuffer.parseObject(data);
    // if (jObj.success())
    //     Serial.println("JSON parsing succeeds");
    // else
    // {
    //     Serial.println("JSON parsing failed");
    //     return;
    // }
    // int id = jObj["id"];
    // Serial.println("id: " + String(id));
    // switch (id)
    // {
    // case 0x0001:
    //     int intensity = jObj["intensity"];
    //     vibrate(intensity);
    //     break;
    // }
}

void vibrate(int intensity)
{
    Serial.println("Vibrate with " + String(intensity) + " intensity");
}