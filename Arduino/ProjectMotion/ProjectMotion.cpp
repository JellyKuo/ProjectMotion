#include "Arduino.h"
#include "ProjectMotion.h"

ProjectMotion::ProjectMotion(SoftwareSerial* softwareSerial, int baudRate = 38400) {
  btSerial = softwareSerial;
  btBaudRate = baudRate;
}

void ProjectMotion::begin(bool loopOverride){
  btSerial->begin(38400);
  Serial.println("ProjectMotion Begin");
  while(loopOverride){
    run();
  }
}

void ProjectMotion::begin(int baudRate, bool loopOverride) {
  btBaudRate = baudRate;
  begin(loopOverride);
}

void ProjectMotion::feedback(int Id, int (*f)(JsonObject&)) {
  Serial.println("Feedback registred ID: " + String(Id,HEX) + ", counter: " + String(feedbackFuncIdCount));
  feedbackFuncIds[feedbackFuncIdCount] = Id;
  feedbackFuncs[feedbackFuncIdCount] = f;
  feedbackFuncIdCount++;
}

void ProjectMotion::input(int Id,int frequency, int (*f)()){
  Serial.println("input registred ID: " + String(Id,HEX) + ", counter: " + String(inputFuncIdCount));
  inputFuncIds[inputFuncIdCount] = Id;
  inputFuncs[inputFuncIdCount] = f;
  inputFreqs[inputFuncIdCount] = frequency;
  inputFuncIdCount++;
}

void ProjectMotion::run() {
  read();
  if(inputState)
    send();
}

void ProjectMotion::read() {
  if (!btSerial->available()) {
    return;
  }

  char jsonStr[64]={0};
  int i = 0;
  while (btSerial->available()) {
    int value = btSerial->read();
    jsonStr[i] = value;
    i++;
  }
  Serial.println(jsonStr);
  JsonObject& json = jsonBuffer.parseObject(jsonStr);
  int id = json["id"];
  for (int i = 0; i < feedbackFuncIdCount; i++) {
    if (feedbackFuncIds[i] == id) {
      Serial.println("Function Id: " + String(id,HEX) + ". Matched, calling");
      feedbackFuncs[i](json);
      return;
    }
  }
  switch(id){
    case 0x0001:
    break;
    case 0x0002:
    inputState = json["state"];
    Serial.println("Input State set to "+String(inputState));
    break;
    case 0x0003:
    break;
    default:
    Serial.println("Function Id: " + String(id,HEX) + ". Not matched");
    break;
  }
  
}

void ProjectMotion::send() {
  if(millis() > lastMillis){
    for(int i = 0; i<inputFuncIdCount;i++){
      if(lastMillis % inputFreqs[i] == 0){
        // int id = inputFuncIds[i];
        JsonObject& json = inputFuncs[i]();
        // json["id"] = id;
        int length = json.measureLength();
        btSerial->write(length);
        char jsonStr[64]={0};
        json.printTo(jsonStr);
        Serial.println("Send data, id: "+String("NINP")+", length: "+String(length));
        btSerial->write(jsonStr);
      }
    }
    lastMillis = millis();
  }
}

void ProjectMotion::trigger(JsonObject& json){
  int length = json.measureLength();
  btSerial->write(length);
  char jsonStr[64]={0};
  json.printTo(jsonStr);
  Serial.println("Send data, id: "+String("NINP")+", length: "+String(length));
  btSerial->write(jsonStr);
}