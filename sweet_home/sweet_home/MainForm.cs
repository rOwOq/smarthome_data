using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace sweet_home
{
    public partial class MainForm : Form
    {
        private SerialPort serial;
        private int timeIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            InitSerial();
            InitChart();
        }

        // ===============================
        // 시리얼 초기화
        // ===============================
        private void InitSerial()
        {
            try
            {
                serial = new SerialPort("COM8", 115200); // 👉 아두이노 포트 확인
                serial.DataReceived += Serial_DataReceived;
                serial.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("시리얼 연결 실패: " + ex.Message);
            }
        }

        // ===============================
        // 시리얼 수신 이벤트
        // (데이터 예: "TEMP:23.0,HUM:46.0,LIGHT:120,AIR:5,PIR:0,VR:650")
        // ===============================
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serial.ReadLine().Trim();
                string[] parts = data.Split(',');

                double temp = 0;
                double hum = 0;
                int light = 0;
                int air = 0;
                int vr = 0;

                this.Invoke(new Action(() =>
                {
                    foreach (string part in parts)
                    {
                        string[] kv = part.Split(':');
                        if (kv.Length == 2)
                        {
                            string key = kv[0];
                            string value = kv[1];

                            switch (key)
                            {
                                case "TEMP":
                                    temp = Convert.ToDouble(value);
                                    lblTemp.Text = $"온도: {temp:F1} °C";
                                    break;

                                case "HUM":
                                    hum = Convert.ToDouble(value);
                                    lblHum.Text = $"습도: {hum:F1} %";
                                    break;

                                case "LIGHT":
                                    light = Convert.ToInt32(value);
                                    lblLight.Text = $"조도: {light}";
                                    break;

                                case "AIR":
                                    air = Convert.ToInt32(value);
                                    lblAir.Text = $"공기질: {air}";
                                    break;

                                case "PIR":
                                    lblPir.Text = (value == "1" ? "모션 감지" : "모션 없음");
                                    break;

                                case "VR":
                                    vr = Convert.ToInt32(value);
                                    lblVr.Text = $"VR: {vr}";
                                    break;

                                case "EVENT":
                                    if (value == "BELL")
                                    {
                                        MessageBox.Show("🔔 초인종 버튼이 눌렸습니다!");
                                    }
                                    break;
                            }
                        }
                    }

                    // ✅ 센서 값으로 차트 업데이트
                    UpdateChart(temp, hum, light, air, vr);
                }));
            }
            catch { /* 오류 무시 */ }
        }

        // ===============================
        // 차트 초기화
        // ===============================
        private void InitChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // 차트 영역
            ChartArea chartArea = new ChartArea("Default");
            chartArea.AxisX.Title = "시간";
            chartArea.AxisY.Title = "값";
            chart1.ChartAreas.Add(chartArea);

            chart1.Series.Add(CreateSeries("온도(℃)", Color.Red));
            chart1.Series.Add(CreateSeries("습도(%)", Color.Blue));
            chart1.Series.Add(CreateSeries("조도", Color.Orange));
            chart1.Series.Add(CreateSeries("공기질", Color.Green));
     
            chart1.Legends[0].Docking = Docking.Top;
        }

        private Series CreateSeries(string name, Color color)
        {
            Series s = new Series(name);
            s.ChartType = SeriesChartType.Line;
            s.Color = color;
            s.BorderWidth = 2;
            return s;
        }

        // ===============================
        // 차트 업데이트
        // ===============================
        private void UpdateChart(double temp, double hum, int light, int air, int vr)
        {
            chart1.Series["온도(℃)"].Points.AddXY(timeIndex, temp);
            chart1.Series["습도(%)"].Points.AddXY(timeIndex, hum);
            chart1.Series["조도"].Points.AddXY(timeIndex, light);
            chart1.Series["공기질"].Points.AddXY(timeIndex, air);

            // 오래된 데이터 제거 (50개 이상이면 삭제)
            foreach (var series in chart1.Series)
            {
                if (series.Points.Count > 50)
                    series.Points.RemoveAt(0);
            }

            chart1.ChartAreas[0].RecalculateAxesScale();
            timeIndex++;
        }

        // ===============================
        // 버튼 이벤트 (제어)
        // ===============================
        private void btnFanOn_Click(object sender, EventArgs e) => serial.WriteLine("FAN_ON");
        private void btnFanOff_Click(object sender, EventArgs e) => serial.WriteLine("FAN_OFF");

        private void btnDoorOpen_Click(object sender, EventArgs e) => serial.WriteLine("DOOR_OPEN");
        private void btnDoorClose_Click(object sender, EventArgs e) => serial.WriteLine("DOOR_CLOSE");

        private void btnBuzzerOn_Click(object sender, EventArgs e)
        {
            serial.WriteLine("BUZZER_ON");
            lblBuzzerStatus.Text = "부저 상태: ON";
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            serial.WriteLine("BUZZER_OFF");
            lblBuzzerStatus.Text = "부저 상태: OFF";
        }

        private void trackServo_Scroll(object sender, EventArgs e)
        {
            int angle = trackServo.Value * 15;
            serial.WriteLine($"SERVO:{angle}");
            lblServoStatus.Text = $"서보 각도: {angle}°";
        }

        private void btnCeilingOn_Click(object sender, EventArgs e) => serial.WriteLine("CEILING_ON");
        private void btnCeilingOff_Click(object sender, EventArgs e) => serial.WriteLine("CEILING_OFF");

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 실행할 초기화 코드 넣을 수 있음
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            // 차트 클릭 시 동작 (필요 없으면 그냥 비워두세요)
        }

    }
}
