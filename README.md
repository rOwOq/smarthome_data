### 🏠 SmartHome Data

스마트홈 IoT 프로젝트에서 센서 데이터를 수집, 저장, 시각화하기 위한 레포지토리입니다.  
Arduino Mega 2560 + 다양한 센서(MMB 키트 포함)와 C# 기반 데스크탑 프로그램을 활용하여 스마트홈 환경을 구현합니다.

---

## 📌 주요 기능
- DHT11 센서를 이용한 온습도 측정
- 조도 센서를 통한 밝기 감지
- 공기질 센서 데이터를 통한 환경 모니터링
- RGB LED, 서보모터, 팬 등 액추에이터 제어
- C# 기반 데이터 시각화 및 로그 저장
- 자동 보고서 생성 기능

---

## 📂 프로젝트 구조
```bash
smarthome_data/
 <br>├── arduino/           # Arduino Mega 2560 코드
 <br>├── csharp_app/        # C# WinForms/WPF 기반 프로그램
 <br>├── data/              # 수집된 센서 데이터 (CSV/JSON)
 <br>└── README.md          # 프로젝트 문서
