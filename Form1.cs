using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        int firstOperand = 0;
        string currentNumber = "";
        string currentOperator = "";
        bool isCalculated = false;

        public Form1()
        {
            InitializeComponent();
            textBox_result.Text = "";
        }

        // 1. 숫자 버튼 클릭 (button_0 ~ button_9)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (isCalculated)
            {
                textBox_input.Clear();
                textBox_result.Clear();
                currentNumber = "";
                currentOperator = "";
                firstOperand = 0;
                isCalculated = false;
            }

            currentNumber += btn.Text;
            textBox_input.Text += btn.Text;
        }

        // 중간 계산 함수
        private void CalculateIntermediate()
        {
            if (currentOperator == "" || currentNumber == "") return;

            int secondOperand = int.Parse(currentNumber);

            if (currentOperator == "+") firstOperand += secondOperand;
            else if (currentOperator == "-") firstOperand -= secondOperand;
            else if (currentOperator == "*") firstOperand *= secondOperand;
            else if (currentOperator == "/")
            {
                if (secondOperand != 0) firstOperand /= secondOperand;
            }
        }

        // 2-1. 더하기(+) 버튼 
        private void button_plus_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = int.Parse(currentNumber);

            currentOperator = "+";
            textBox_input.Text += " + ";
            currentNumber = "";
        }

        // 2-2. 빼기(-) 버튼 
        private void button_sub_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = int.Parse(currentNumber);

            currentOperator = "-";
            textBox_input.Text += " - ";
            currentNumber = "";
        }

        // 2-3. 곱하기(*) 버튼 
        private void button_multiply_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = int.Parse(currentNumber);

            currentOperator = "*";
            textBox_input.Text += " * ";
            currentNumber = "";
        }

        // 2-4. 나누기(/) 버튼 
        private void button_divide_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = int.Parse(currentNumber);

            currentOperator = "/";
            textBox_input.Text += " / ";
            currentNumber = "";
        }

        // 3. 결과 보기(=) 버튼 
        private void button_input_Click(object sender, EventArgs e)
        {
            if (currentNumber == "" || currentOperator == "") return;

            CalculateIntermediate();

            textBox_input.Text += " = " + firstOperand.ToString();
            textBox_result.Text = firstOperand.ToString();

            isCalculated = true;
            currentNumber = "";
            currentOperator = "";
        }

        // ★ 새로 추가된 4. C (Clear) 버튼: 모든 걸 초기화 
        private void button_c_Click(object sender, EventArgs e)
        {
            textBox_input.Clear();
            textBox_result.Clear();
            currentNumber = "";
            currentOperator = "";
            firstOperand = 0;
            isCalculated = false;
        }

        // ★ 새로 추가된 5. CE (Clear Entry) 버튼: 방금 입력한 피연산자만 지우기 
        private void button_ce_Click(object sender, EventArgs e)
        {
            // 계산이 완전히 끝난 상태면 C 버튼과 똑같이 전체 초기화 진행
            if (isCalculated)
            {
                button_c_Click(sender, e);
                return;
            }

            // 현재 입력 중인 숫자가 있다면
            if (currentNumber.Length > 0)
            {
                // 위쪽 화면(textBox_input)에서 지금 치고 있던 숫자 길이만큼만 싹둑 잘라내기
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - currentNumber.Length);

                // 컴퓨터가 몰래 기억하던 현재 숫자도 리셋!
                currentNumber = "";
            }
        }

        // ★ 새로 추가된 6. Del 버튼: 마지막 글자 하나만 쏙 지우기
        private void button_del_Click(object sender, EventArgs e)
        {
            // 이미 '='을 눌러서 계산이 다 끝난 상태면 뒤로 지울 게 없으니 그냥 무시!
            if (isCalculated) return;

            // 현재 치고 있는 숫자(currentNumber)가 1글자 이상 있을 때만 지우기 작동
            if (currentNumber.Length > 0)
            {
                // 1. 위쪽 화면(textBox_input)에서 맨 끝에 있는 글자 하나 싹둑 잘라내기
                textBox_input.Text = textBox_input.Text.Remove(textBox_input.Text.Length - 1);

                // 2. 컴퓨터가 몰래 기억하던 숫자(currentNumber)에서도 맨 끝 글자 싹둑 잘라내기
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
            }
        }
    }
}