String receivedChar;
//boolean newData = false;
//boolean finished = true;
int red2 = 13; //built in led
int red = 12; //built in led
int yellow = 11;
int green = 10;

void setup() {
    Serial.begin(115200);
    Serial.println("<Arduino is ready>");
    pinMode(red, OUTPUT);
    pinMode(red2, OUTPUT);

    digitalWrite(green, HIGH);
}

void loop() {
  test();
  //delay(100);
}

void test() {
  while (Serial.available() == 0) {}     //wait for data available
  String teststr = Serial.readString();  //read until timeout
  teststr.trim();                        // remove any \r \n whitespace at the end of the String
  if (teststr == "red") {
    digitalWrite(red, HIGH);
    digitalWrite(red2, HIGH);
    digitalWrite(yellow, LOW);
    digitalWrite(green, LOW);
  }
  if (teststr == "yellow") {
    digitalWrite(red, LOW);
    digitalWrite(red2, LOW);
    digitalWrite(yellow, HIGH);
    digitalWrite(green, LOW);
  }
  if (teststr == "green") {
    digitalWrite(red, LOW);
    digitalWrite(red2, LOW);
    digitalWrite(yellow, LOW);
    digitalWrite(green, HIGH);
  }
  if (teststr == "off") {
    digitalWrite(red, LOW);
    digitalWrite(red2, LOW);
    digitalWrite(yellow, LOW);
    digitalWrite(green, LOW);
  }
    
}