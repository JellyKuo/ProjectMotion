#include "ProjectMotion.h"

SoftwareSerial btSerial(10, 11);
ProjectMotion motion(&btSerial, 38400);

void setup() {
  Serial.begin(38400);
  Serial.println("SETUP");
  motion.feedback(0x1001, vibrate);
  motion.input(0xf001,500,gyro);
  motion.begin(false);
}

void loop() {
  motion.run();
}

void vibrate(JsonObject& json) {
  int intensity = json["intensity"];
  Serial.println("Vibrate with intensity " + String(intensity) + " at " + String(millis()));
}

JsonObject& gyro(){
  motion.jsonBuffer.clear();
  JsonObject& json = motion.jsonBuffer.createObject();
  json["id"] = 0xf001;
  json["X"] = millis();
  json["Y"] = millis()*100;
  json["Z"] = millis()/100;
  return json;
}
