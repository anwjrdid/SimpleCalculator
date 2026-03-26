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

            // ★ 변경: 시작하자마자 +/- 눌러서 "(-)" 상태일 때 숫자 누르면 괄호 안에 예쁘게 넣기
            if (currentNumber == "-")
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3);
                currentNumber += btn.Text;
                textBox_input.Text += "(" + currentNumber + ")";
            }
            else if (currentNumber.StartsWith("-"))
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
            else if (currentOperator == "**")
            {
                firstOperand = Math.Pow(firstOperand, secondOperand);
            }
        }

        // ★ 새로 추가된 핵심 로직: 연산자 버튼 공통 처리 (버그 완벽 차단)
        private void HandleOperator(string op)
        {
            // 계산이 끝난 직후 연산자를 누르면, 그 결과값을 이어서 계산하게 해줌!
            if (isCalculated)
            {
                isCalculated = false;
                currentOperator = op;
                string formattedFirst = firstOperand < 0 ? "(" + firstOperand + ")" : firstOperand.ToString();
                textBox_input.Text = formattedFirst + " " + op + " ";
                textBox_result.Clear();
                return;
            }

            if (currentNumber == "" || currentNumber == "-") return;

            if (currentOperator != "") CalculateIntermediate();
            else firstOperand = double.Parse(currentNumber);

            currentOperator = op;
            textBox_input.Text += " " + op + " ";
            currentNumber = "";
        }

        // 2-1. 더하기(+)
        private void button_plus_Click(object sender, EventArgs e)
        {
            HandleOperator("+");
        }

        // 2-2. 빼기(-)
        private void button_sub_Click(object sender, EventArgs e)
        {
            HandleOperator("-");
        }

        // 2-3. 곱하기(*)
        private void button_multiply_Click(object sender, EventArgs e)
        {
            // ** 처리를 위한 특수 로직
            if (currentNumber == "" && currentOperator == "*")
            {
                currentOperator = "**";
                if (textBox_input.Text.EndsWith(" * "))
                {
                    textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3) + " ** ";
                }
                return;
            }

            HandleOperator("*");
        }

        // 2-4. 나누기(/)
        private void button_divide_Click(object sender, EventArgs e)
        {
            HandleOperator("/");
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

            if (currentNumber == "-")
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3);
                currentNumber = "";
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

            if (currentNumber == "-")
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3);
                currentNumber = "";
                return;
            }

            if (currentNumber.StartsWith("-"))
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - (currentNumber.Length + 2));
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);

                if (currentNumber == "-")
                {
                    textBox_input.Text += "(-)";
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
                else if (currentNumber == "-")
                {
                    textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3);
                    currentNumber = "-0.";
                    textBox_input.Text += "(-0.)";
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
            // ★ 변경: 계산이 끝난 후 +/- 를 누르면 결과값의 부호를 즉시 바꿔줌!
            if (isCalculated)
            {
                firstOperand = -firstOperand;
                string formattedResult = firstOperand < 0 ? "(" + firstOperand + ")" : firstOperand.ToString();

                int equalsIndex = textBox_input.Text.LastIndexOf("=");
                if (equalsIndex != -1)
                {
                    textBox_input.Text = textBox_input.Text.Substring(0, equalsIndex + 1) + " " + firstOperand.ToString();
                }
                textBox_result.Text = firstOperand.ToString();
                return;
            }

            // ★ 네가 원했던 기능: 아무것도 안 친 상태에서 +/- 누르면 (-)부터 시작!
            if (currentNumber == "")
            {
                currentNumber = "-";
                textBox_input.Text += "(-)";
                return;
            }

            // 이미 (-)만 있는 상태에서 한 번 더 누르면 취소
            if (currentNumber == "-")
            {
                currentNumber = "";
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3);
                return;
            }

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