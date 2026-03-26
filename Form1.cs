using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        int firstOperand = 0; // 첫 번째 숫자 저장할 공간
        string currentNumber = ""; // 화면에 안 띄우고 몰래 숫자를 기억해 둘 공간
        string currentOperator = ""; // 어떤 연산자를 눌렀는지 기억할 공간
        bool isCalculated = false; // '=' 버튼이 눌려서 계산이 끝났는지 확인하는 용도

        public Form1()
        {
            InitializeComponent();
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
                currentOperator = "";
                isCalculated = false;
            }

            // 방금 누른 숫자를 '위쪽 창'과 '몰래 기억하는 공간'에만 추가!
            currentNumber += btn.Text;
            textBox_input.Text += btn.Text;
        }

        // 2-1. 더하기(+) 버튼 클릭 이벤트 (button_plus)
        private void button_plus_Click(object sender, EventArgs e)
        {
            // ★ 버그 해결 1 & 2: 계산이 끝났거나, 숫자가 입력되지 않은 상태면 연산자 입력 무시!
            if (isCalculated || currentNumber == "") return;

            firstOperand = int.Parse(currentNumber);
            currentOperator = "+";
            textBox_input.Text += " + ";
            currentNumber = "";
        }

        // 2-2. 빼기(-) 버튼 클릭 이벤트 (button_sub)
        private void button_sub_Click(object sender, EventArgs e)
        {
            // ★ 버그 해결
            if (isCalculated || currentNumber == "") return;

            firstOperand = int.Parse(currentNumber);
            currentOperator = "-";
            textBox_input.Text += " - ";
            currentNumber = "";
        }

        // 2-3. 곱하기(*) 버튼 클릭 이벤트 (button_multiply)
        private void button_multiply_Click(object sender, EventArgs e)
        {
            // ★ 버그 해결
            if (isCalculated || currentNumber == "") return;

            firstOperand = int.Parse(currentNumber);
            currentOperator = "*";
            textBox_input.Text += " * ";
            currentNumber = "";
        }

        // 2-4. 나누기(/) 버튼 클릭 이벤트 (button_divide)
        private void button_divide_Click(object sender, EventArgs e)
        {
            // ★ 버그 해결
            if (isCalculated || currentNumber == "") return;

            firstOperand = int.Parse(currentNumber);
            currentOperator = "/";
            textBox_input.Text += " / ";
            currentNumber = "";
        }

        // 3. 결과 보기(=) 버튼 클릭 이벤트 (button_input)
        private void button_input_Click(object sender, EventArgs e)
        {
            // 두 번째 숫자가 아예 없거나 연산자가 없으면 에러 나니까 방지
            if (currentNumber == "" || currentOperator == "") return;

            // 두 번째 피연산자 가져오기
            int secondOperand = int.Parse(currentNumber);
            int result = 0;

            // 저장된 연산자에 따라 사칙연산 수행!
            if (currentOperator == "+")
            {
                result = firstOperand + secondOperand;
            }
            else if (currentOperator == "-")
            {
                result = firstOperand - secondOperand;
            }
            else if (currentOperator == "*")
            {
                result = firstOperand * secondOperand;
            }
            else if (currentOperator == "/")
            {
                if (secondOperand != 0)
                {
                    result = firstOperand / secondOperand;
                }
            }

            // 위쪽 창에는 " = 결과값" 형태로 수식 완성해서 붙여주기
            textBox_input.Text += " = " + result.ToString();

            // 아래쪽 창(result)에 계산된 최종 결과값을 띄워줌
            textBox_result.Text = result.ToString();

            // 계산이 끝났다고 깃발 꽂기
            isCalculated = true;

            // 다음 계산을 위해 임시 공간 비우기
            currentNumber = "";
            currentOperator = "";
        }
    }
}