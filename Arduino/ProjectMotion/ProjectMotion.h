#ifndef ProjectMotion_h
#define ProjectMotion_h

#include "Arduino.h"
#include "SoftwareSerial.h"
#include "ArduinoJson.h"

#define FUNCTION_COUNT 5
#define hwSerialBaud 38400

class ProjectMotion {
  private:
    int btBaudRate;
    int (*feedbackFuncs[FUNCTION_COUNT])(JsonObject&);
    int feedbackFuncIds[FUNCTION_COUNT];
    int feedbackFuncIdCount = 0;
    JsonObject& (*inputFuncs[FUNCTION_COUNT])();
    int inputFuncIds[FUNCTION_COUNT];
    int inputFuncIdCount = 0;
    int inputFreqs[FUNCTION_COUNT];
    int freqCount = 0;
    long lastMillis = 0;
    bool inputState = false;
    SoftwareSerial* btSerial;
  public:
    ProjectMotion(SoftwareSerial* softwareSerial, int baudRate);
    void begin(bool loopOverride);
    void begin(int baudRate, bool loopOverride);
    void feedback(int Id, int (*f)(JsonObject&));
    void input(int Id,int frequency, int (*f)());
    void run();
    void read();
    void send();
    void trigger(JsonObject&);
    StaticJsonBuffer<200> jsonBuffer;
};

#endif
