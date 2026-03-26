using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        int firstOperand = 0; // 첫 번째 숫자 저장
        bool isNewInput = true; // 새로운 숫자를 입력받을 타이밍인지 확인

        public Form1()
        {
            InitializeComponent();
        }

        // 1. 숫자 버튼 클릭 (button_0 ~ button_9 전부 이 이벤트로 연결!)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // 새로운 숫자를 입력할 타이밍(처음이거나, + 누른 직후거나, = 누른 직후)
            if (isNewInput)
            {
                textBox_result.Clear(); // 아래쪽 창 비우기

                // 만약 이전에 '='을 눌러서 계산이 끝난 상태라면 위쪽 창도 비워주기
                if (textBox_input.Text.Contains("="))
                {
                    textBox_input.Clear();
                }

                isNewInput = false;
            }

            // 아래쪽 창(현재 숫자)과 위쪽 창(전체 수식)에 방금 누른 숫자 찍기
            textBox_result.Text += btn.Text;
            textBox_input.Text += btn.Text;
        }

        // 2. 더하기(+) 버튼 클릭 이벤트 (button_plus)
        private void button_plus_Click(object sender, EventArgs e)
        {
            // 빈칸이 아닐 때만 현재까지 입력된 숫자를 첫 번째 피연산자로 저장
            if (textBox_result.Text != "")
            {
                firstOperand = int.Parse(textBox_result.Text);
            }

            // 위쪽 창에 " + " 기호를 양옆 띄어쓰기 포함해서 추가
            textBox_input.Text += " + ";

            // 더하기를 눌렀으니, 다음 숫자를 새로 입력받도록 설정
            isNewInput = true;
        }

        // 3. 결과 보기(=) 버튼 클릭 이벤트 (button_input)
        private void button_input_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text == "") return; // 오류 방지용

            // 두 번째 피연산자 가져오기
            int secondOperand = int.Parse(textBox_result.Text);

            // 더하기 계산 수행
            int sum = firstOperand + secondOperand;

            // ★ 네가 원했던 부분! 위쪽 창에 " = 결과값" 형태로 이어 붙이기
            textBox_input.Text += " = " + sum.ToString();

            // 아래쪽 창에는 계산된 최종 결과값만 딱 표시
            textBox_result.Text = sum.ToString();

            // 계산이 끝났으니, 다음 번에 숫자를 누르면 리셋되도록 설정
            isNewInput = true;
        }
    }
}