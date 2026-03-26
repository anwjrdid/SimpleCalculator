using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        int firstOperand = 0; // 첫 번째 숫자 저장할 공간
        string currentNumber = ""; // 화면에 안 띄우고 몰래 숫자를 기억해 둘 공간
        bool isCalculated = false; // '=' 버튼이 눌려서 계산이 끝났는지 확인하는 용도

        public Form1()
        {
            InitializeComponent();

            // 처음 켰을 때 아래쪽 결과창은 아무것도 없이 깨끗하게 비워두기!
            textBox_result.Text = "";
        }

        // 1. 숫자 버튼 클릭 (button_0 ~ button_9 전부 이 이벤트로 연결!)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // 만약 계산이 다 끝난 상태('= '누른 직후)에서 새 숫자를 누르면, 화면 다 지우고 새로 시작!
            if (isCalculated)
            {
                textBox_input.Clear();
                textBox_result.Clear();
                currentNumber = "";
                isCalculated = false;
            }

            // ★ 핵심: 방금 누른 숫자를 '위쪽 창'과 '몰래 기억하는 공간'에만 추가! (아래쪽 창은 건드리지 않음)
            currentNumber += btn.Text;
            textBox_input.Text += btn.Text;
        }

        // 2. 더하기(+) 버튼 클릭 이벤트 (button_plus)
        private void button_plus_Click(object sender, EventArgs e)
        {
            // 기억해둔 숫자가 있으면 첫 번째 피연산자로 넘겨줌
            if (currentNumber != "")
            {
                firstOperand = int.Parse(currentNumber);
            }

            // 위쪽 창에 " + " 기호를 양옆 띄어쓰기 포함해서 예쁘게 추가
            textBox_input.Text += " + ";

            // 더하기를 눌렀으니, 다음 숫자를 새로 받아야 해서 임시 공간은 비워줌
            currentNumber = "";
        }

        // 3. 결과 보기(=) 버튼 클릭 이벤트 (button_input)
        private void button_input_Click(object sender, EventArgs e)
        {
            // 두 번째 숫자가 아예 없는데 '=' 누르면 에러 나니까 방지
            if (currentNumber == "") return;

            // 두 번째 피연산자 가져오기
            int secondOperand = int.Parse(currentNumber);

            // 더하기 계산 수행!
            int sum = firstOperand + secondOperand;

            // 위쪽 창에는 " = 결과값" 형태로 수식 완성해서 붙여주기
            textBox_input.Text += " = " + sum.ToString();

            // 아래쪽 창(result)에 계산된 최종 결과값을 띄워줌
            textBox_result.Text = sum.ToString();

            // 계산이 끝났다고 깃발 꽂기 (다음 번 숫자를 누를 때 화면이 리셋되도록)
            isCalculated = true;

            // 다음 계산을 위해 임시 공간 비우기
            currentNumber = "";
        }
    }
}