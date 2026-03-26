using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        double firstOperand = 0;
        string currentNumber = "";
        string currentOperator = "";
        bool isCalculated = false;

        public Form1()
        {
            InitializeComponent();
            textBox_result.Text = "";
        }

        // 1. 숫자 버튼 클릭
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

            // 음수라서 괄호가 쳐져 있다면, 괄호 부분까지 화면에서 지우고 새 숫자 붙여서 다시 괄호 씌우기!
            if (currentNumber.StartsWith("-"))
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - (currentNumber.Length + 2));
                currentNumber += btn.Text;
                textBox_input.Text += "(" + currentNumber + ")";
            }
            else
            {
                currentNumber += btn.Text;
                textBox_input.Text += btn.Text;
            }
        }

        // 중간 계산 함수
        private void CalculateIntermediate()
        {
            if (currentOperator == "" || currentNumber == "" || currentNumber == "-") return;

            double secondOperand = double.Parse(currentNumber);

            if (currentOperator == "+") firstOperand += secondOperand;
            else if (currentOperator == "-") firstOperand -= secondOperand;
            else if (currentOperator == "*") firstOperand *= secondOperand;
            else if (currentOperator == "/")
            {
                if (secondOperand != 0) firstOperand /= secondOperand;
            }
            // ★ 새로 추가된 기능: 거듭제곱(**) 계산 로직!
            else if (currentOperator == "**")
            {
                // Math.Pow(5, 2) 하면 5의 2승인 25가 나오는 함수야!
                firstOperand = Math.Pow(firstOperand, secondOperand);
            }
        }

        // 2-1. 더하기(+)
        private void button_plus_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "" || currentNumber == "-") return;
            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber);

            currentOperator = "+";
            textBox_input.Text += " + ";
            currentNumber = "";
        }

        // 2-2. 빼기(-)
        private void button_sub_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "" || currentNumber == "-") return;
            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber);

            currentOperator = "-";
            textBox_input.Text += " - ";
            currentNumber = "";
        }

        // 2-3. 곱하기(*)
        private void button_multiply_Click(object sender, EventArgs e)
        {
            if (isCalculated) return;

            // ★ 핵심 로직: 방금 '*'를 눌렀는데 또 '*'를 누른 거라면?
            if (currentNumber == "" && currentOperator == "*")
            {
                currentOperator = "**"; // 연산자를 거듭제곱으로 변경!

                // 화면의 " * " 기호를 " ** "로 싹 바꿔치기
                if (textBox_input.Text.EndsWith(" * "))
                {
                    textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3) + " ** ";
                }
                return; // 두 번째 숫자가 들어올 때까지 대기
            }

            if (currentNumber == "" || currentNumber == "-") return;
            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber);

            currentOperator = "*";
            textBox_input.Text += " * ";
            currentNumber = "";
        }

        // 2-4. 나누기(/)
        private void button_divide_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "" || currentNumber == "-") return;
            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber);

            currentOperator = "/";
            textBox_input.Text += " / ";
            currentNumber = "";
        }

        // 3. 결과 보기(=)
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

        // 4. C (Clear)
        private void button_c_Click(object sender, EventArgs e)
        {
            textBox_input.Clear();
            textBox_result.Clear();
            currentNumber = "";
            currentOperator = "";
            firstOperand = 0;
            isCalculated = false;
        }

        // 5. CE (Clear Entry)
        private void button_ce_Click(object sender, EventArgs e)
        {
            if (isCalculated)
            {
                button_c_Click(sender, e);
                return;
            }

            if (currentNumber.Length > 0)
            {
                int oldLength = currentNumber.StartsWith("-") ? currentNumber.Length + 2 : currentNumber.Length;
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - oldLength);
                currentNumber = "";
            }
        }

        // 6. Del 버튼
        private void button_del_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber.Length == 0) return;

            if (currentNumber.StartsWith("-"))
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - (currentNumber.Length + 2));
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);

                if (currentNumber == "-")
                {
                    currentNumber = "";
                }
                else
                {
                    textBox_input.Text += "(" + currentNumber + ")";
                }
            }
            else
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - currentNumber.Length);
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
                textBox_input.Text += currentNumber;
            }
        }

        // 7. 소수점(.) 버튼
        private void button_dot_Click(object sender, EventArgs e)
        {
            if (isCalculated) return;

            if (!currentNumber.Contains("."))
            {
                if (currentNumber == "")
                {
                    currentNumber = "0.";
                    textBox_input.Text += "0.";
                }
                else if (currentNumber.StartsWith("-"))
                {
                    textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - (currentNumber.Length + 2));
                    currentNumber += ".";
                    textBox_input.Text += "(" + currentNumber + ")";
                }
                else
                {
                    currentNumber += ".";
                    textBox_input.Text += ".";
                }
            }
        }

        // 8. 음수/양수 전환(+/-) 버튼
        private void button_negative_Click(object sender, EventArgs e)
        {
            if (isCalculated || currentNumber == "") return;

            int oldLength = currentNumber.StartsWith("-") ? currentNumber.Length + 2 : currentNumber.Length;
            textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - oldLength);

            if (currentNumber.StartsWith("-"))
                currentNumber = currentNumber.Substring(1);
            else
                currentNumber = "-" + currentNumber;

            if (currentNumber.StartsWith("-"))
                textBox_input.Text += "(" + currentNumber + ")";
            else
                textBox_input.Text += currentNumber;
        }
    }
}