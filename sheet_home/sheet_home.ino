#include "DHT.h"
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <Servo.h>

// ───── 센서 핀 정의 ─────
#define DHTPIN 12
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);

#define LIGHT_PIN A0
#define AIR_PIN   A1
#define PIR_PIN   3
#define VR_PIN    A4
#define BUTTON_PIN 2  // 초인종 버튼 (Interrupt0)

// ───── 제어 핀 정의 ─────
#define FAN_PIN   4
#define BUZZER_PIN 11
#define DOORLOCK_PIN 31
#define CEILING_FAN_PIN 32
#define LED_STATUS 13

// ───── 서보모터 ─────
#define SERVO_PIN 9
Servo servo1;
int currentAngle = 0;  // 현재 서보 각도 저장

// ───── RGB LED 핀 ─────
#define RGB_R 23
#define RGB_G 35
#define RGB_B 36

// ───── LCD 정의 ─────
LiquidCrystal_I2C lcd(0x27, 16, 2);

volatile bool bellPressed = false; // 초인종 이벤트 플래그

void bellISR() {  
  bellPressed = true;
}

// ───── 서보 부드럽게 이동 함수 ─────
void moveServoSmooth(int target, int stepDelay) {
  if (currentAngle < target) {
    for (int pos = currentAngle; pos <= target; pos++) {
      servo1.write(pos);
      delay(stepDelay);
    }
  } else {
    for (int pos = currentAngle; pos >= target; pos--) {
      servo1.write(pos);
      delay(stepDelay);
    }
  }
  currentAngle = target;
}

void setup() {
  Serial.begin(115200);
  dht.begin();

  pinMode(PIR_PIN, INPUT);
  pinMode(FAN_PIN, OUTPUT);
  pinMode(BUZZER_PIN, OUTPUT);
  pinMode(DOORLOCK_PIN, OUTPUT);
  pinMode(CEILING_FAN_PIN, OUTPUT);
  pinMode(LED_STATUS, OUTPUT);

  pinMode(RGB_R, OUTPUT);
  pinMode(RGB_G, OUTPUT);
  pinMode(RGB_B, OUTPUT);

  servo1.attach(SERVO_PIN);
  servo1.write(0); // 초기 0도로 세팅
  currentAngle = 0;

  digitalWrite(FAN_PIN, LOW);
  digitalWrite(BUZZER_PIN, LOW);
  digitalWrite(DOORLOCK_PIN, LOW);
  digitalWrite(CEILING_FAN_PIN, LOW);
  digitalWrite(LED_STATUS, LOW);

  lcd.init();
  lcd.backlight();
  lcd.setCursor(0,0);
  lcd.print("SMART HOME KIT");
  lcd.setCursor(0,1);
  lcd.print("SYSTEM READY");
  delay(2000);
  lcd.clear();

  pinMode(BUTTON_PIN, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(BUTTON_PIN), bellISR, FALLING);

  Serial.println("SYSTEM_READY");
}

void loop() {
  float temp = dht.readTemperature();
  float hum  = dht.readHumidity();
  int light  = analogRead(LIGHT_PIN);
  int air    = analogRead(AIR_PIN);
  int pir    = digitalRead(PIR_PIN);
  int vrVal  = analogRead(VR_PIN);

  lcd.clear();
  lcd.setCursor(0,0);
  if (!isnan(temp) && !isnan(hum)) {
    lcd.print("T:"); lcd.print(temp,1);
    lcd.print(" H:"); lcd.print(hum,0); lcd.print("%");
  } else {
    lcd.print("DHT FAIL");
  }

  lcd.setCursor(0,1);
  lcd.print("L:"); lcd.print(light);
  lcd.print(" A:"); lcd.print(air);

  if (isnan(temp) || isnan(hum)) {
    Serial.println("ERROR:DHT_FAIL");
  } else {
    Serial.print("TEMP:"); Serial.print(temp, 1);
    Serial.print(",HUM:"); Serial.print(hum, 1);
    Serial.print(",LIGHT:"); Serial.print(light);
    Serial.print(",AIR:"); Serial.print(air);
    Serial.print(",PIR:"); Serial.print(pir);
    Serial.print(",VR:"); Serial.println(vrVal);
  }

  if (bellPressed) {
    Serial.println("EVENT:BELL");
    lcd.setCursor(10,1);
    lcd.print("BELL");
    digitalWrite(LED_STATUS, HIGH);
    tone(BUZZER_PIN, 1000, 500);
    bellPressed = false;
  }

  if (Serial.available()) {
    String cmd = Serial.readStringUntil('\n');
    cmd.trim();

    if (cmd == "FAN_ON") {
      digitalWrite(FAN_PIN, HIGH);
      Serial.println("ACK:FAN_ON");
    } 
    else if (cmd == "FAN_OFF") {
      digitalWrite(FAN_PIN, LOW);
      Serial.println("ACK:FAN_OFF");
    } 
    else if (cmd == "CEILING_ON") {
      digitalWrite(CEILING_FAN_PIN, HIGH);
      Serial.println("ACK:CEILING_ON");
    }
    else if (cmd == "CEILING_OFF") {
      digitalWrite(CEILING_FAN_PIN, LOW);
      Serial.println("ACK:CEILING_OFF");
    }
    else if (cmd == "BUZZER_ON") {
      digitalWrite(BUZZER_PIN, HIGH);
      Serial.println("ACK:BUZZER_ON");
    } 
    else if (cmd == "BUZZER_OFF") {
      digitalWrite(BUZZER_PIN, LOW);
      Serial.println("ACK:BUZZER_OFF");
    }
    else if (cmd == "DOOR_OPEN") {
      digitalWrite(DOORLOCK_PIN, HIGH);
      Serial.println("ACK:DOOR_OPEN");
    }
    else if (cmd == "DOOR_CLOSE") {
      digitalWrite(DOORLOCK_PIN, LOW);
      Serial.println("ACK:DOOR_CLOSE");
    }
    else if (cmd.startsWith("SERVO:")) {
      int angle = cmd.substring(6).toInt();
      moveServoSmooth(angle, 25); // 각도당 15ms 지연 → 부드럽게 이동
      Serial.print("ACK:SERVO "); Serial.println(angle);
    }
    else if (cmd == "LED_RED") {
      analogWrite(RGB_R, 255); analogWrite(RGB_G, 0); analogWrite(RGB_B, 0);
      Serial.println("ACK:LED_RED");
    }
    else if (cmd == "LED_GREEN") {
      analogWrite(RGB_R, 0); analogWrite(RGB_G, 255); analogWrite(RGB_B, 0);
      Serial.println("ACK:LED_GREEN");
    }
    else if (cmd == "LED_BLUE") {
      analogWrite(RGB_R, 0); analogWrite(RGB_G, 0); analogWrite(RGB_B, 255);
      Serial.println("ACK:LED_BLUE");
    }
    else if (cmd == "LED_OFF") {
      analogWrite(RGB_R, 0); analogWrite(RGB_G, 0); analogWrite(RGB_B, 0);
      Serial.println("ACK:LED_OFF");
    }
  }

  delay(500);
}
