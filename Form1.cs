using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // ★ 변경: 소수점 계산을 위해 int를 double로 싹 바꿨어!
        double firstOperand = 0;
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
            if (currentOperator == "" || currentNumber == "" || currentNumber == "-") return;

            // ★ 변경: int.Parse 대신 double.Parse 사용!
            double secondOperand = double.Parse(currentNumber);

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
            if (isCalculated || currentNumber == "" || currentNumber == "-") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber); // ★ 변경

            currentOperator = "+";
            textBox_input.Text += " + ";
            currentNumber = "";
        }

        // 2-2. 빼기(-) 버튼
        private void button_sub_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "" || currentNumber == "-") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber); // ★ 변경

            currentOperator = "-";
            textBox_input.Text += " - ";
            currentNumber = "";
        }

        // 2-3. 곱하기(*) 버튼
        private void button_multiply_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "" || currentNumber == "-") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber); // ★ 변경

            currentOperator = "*";
            textBox_input.Text += " * ";
            currentNumber = "";
        }

        // 2-4. 나누기(/) 버튼
        private void button_divide_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "" || currentNumber == "-") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber); // ★ 변경

            currentOperator = "/";
            textBox_input.Text += " / ";
            currentNumber = "";
        }

        // 3. 결과 보기(=) 버튼
        private void button_input_Click(object sender, EventArgs e)
        {
            if (currentNumber == "" || currentOperator == "" || currentNumber == "-") return;

            CalculateIntermediate();

            textBox_input.Text += " = " + firstOperand.ToString();
            textBox_result.Text = firstOperand.ToString();

            isCalculated = true;
            currentNumber = "";
            currentOperator = "";
        }

        // 4. C (Clear) 버튼
        private void button_c_Click(object sender, EventArgs e)
        {
            textBox_input.Clear();
            textBox_result.Clear();
            currentNumber = "";
            currentOperator = "";
            firstOperand = 0;
            isCalculated = false;
        }

        // 5. CE (Clear Entry) 버튼
        private void button_ce_Click(object sender, EventArgs e)
        {
            if (isCalculated)
            {
                button_c_Click(sender, e);
                return;
            }

            if (currentNumber.Length > 0)
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - currentNumber.Length);
                currentNumber = "";
            }
        }

        // 6. Del 버튼
        private void button_del_Click(object sender, EventArgs e)
        {
            if (isCalculated) return;

            if (currentNumber.Length > 0)
            {
                textBox_input.Text = textBox_input.Text.Remove(textBox_input.Text.Length - 1);
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
            }
        }

        // ★ 새로 추가된 7. 소수점(.) 버튼
        private void button_dot_Click(object sender, EventArgs e)
        {
            if (isCalculated) return;

            // 소수점이 아직 없을 때만 찍을 수 있게 방지
            if (!currentNumber.Contains("."))
            {
                if (currentNumber == "")
                {
                    // 아무것도 안 쳤는데 . 누르면 0. 으로 시작!
                    currentNumber = "0.";
                    textBox_input.Text += "0.";
                }
                else
                {
                    currentNumber += ".";
                    textBox_input.Text += ".";
                }
            }
        }

        // ★ 새로 추가된 8. 음수/양수 전환(+/-) 버튼
        private void button_negative_Click(object sender, EventArgs e)
        {
            // 숫자가 아예 없거나, 이미 계산이 끝난 상태면 무시
            if (isCalculated || currentNumber == "") return;

            // 1. 화면(textBox_input)에서 지금 치고 있던 숫자를 잠시 지워둠
            textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - currentNumber.Length);

            // 2. 부호 바꾸기 로직
            if (currentNumber.StartsWith("-"))
            {
                // 이미 음수면 맨 앞의 '-'를 잘라내서 양수로 만듦
                currentNumber = currentNumber.Substring(1);
            }
            else
            {
                // 양수면 맨 앞에 '-'를 붙여서 음수로 만듦
                currentNumber = "-" + currentNumber;
            }

            // 3. 부호가 바뀐 숫자를 화면(textBox_input)에 다시 예쁘게 붙여줌
            textBox_input.Text += currentNumber;
        }
    }
}