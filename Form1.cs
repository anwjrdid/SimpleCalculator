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

            // 시작하자마자 +/- 눌러서 "(-)" 상태일 때 숫자 누르면 괄호 안에 예쁘게 넣기
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
            else if (currentOperator == "÷") // ★ 나누기 기호 완벽하게 수정!
            {
                if (secondOperand != 0) firstOperand /= secondOperand;
            }
            else if (currentOperator == "**")
            {
                firstOperand = Math.Pow(firstOperand, secondOperand);
            }
        }

        // 연산자 버튼 공통 처리 (버그 완벽 차단)
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

        // 2-4. 나누기(÷)
        private void button_divide_Click(object sender, EventArgs e)
        {
            HandleOperator("÷"); // ★ 화면 기호랑 완벽 일치!
        }

        // 3. 결과 보기(=)
        private void button_input_Click(object sender, EventArgs e) // ★ 수정: = 누르기 전에 현재 숫자가 (-)만 있는 상태면, 계산 안 하도록 예외 처리
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
        private void button_c_Click(object sender, EventArgs e) // ★ 수정: C 누르면 모든 상태 완전히 초기화!
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

            if (currentNumber == "-") // ★ 수정: 현재 숫자가 (-)만 있는 상태면, 괄호까지 포함해서 지우기
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3);
                currentNumber = "";
                return;
            }

            if (currentNumber.Length > 0) // ★ 수정: 현재 숫자가 음수면 괄호까지 포함해서 지우기
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

            if (currentNumber.StartsWith("-")) // ★ 수정: 음수이면서 숫자 하나 삭제한 상태면, 괄호까지 포함해서 지우고 새로 그리기
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - (currentNumber.Length + 2));
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);

                if (currentNumber == "-")
                {
                    textBox_input.Text += "(-)";
                }
                else // ★ 수정: 음수이면서 숫자 하나 삭제한 상태면, 괄호까지 포함해서 지우고 새로 그리기
                {
                    textBox_input.Text += "(" + currentNumber + ")";
                }
            }
            else // 일반적인 숫자 삭제
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

            if (!currentNumber.Contains(".")) // 이미 소수점이 있으면 무시
            {
                if (currentNumber == "")
                {
                    currentNumber = "0.";
                    textBox_input.Text += "0.";
                }
                else if (currentNumber == "-")  // ★ 수정: 시작하자마자 +/- 누르고 바로 . 누르면, 괄호까지 포함해서 지우고 새로 그리기
                {
                    textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3);
                    currentNumber = "-0.";
                    textBox_input.Text += "(-0.)";
                }
                else if (currentNumber.StartsWith("-")) // ★ 수정: 음수이면서 소수점 없는 상태에서 . 누르면, 괄호까지 포함해서 지우고 새로 그리기
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
            // ★ 수정: 계산이 끝난 후 +/- 를 누르면, 이전 결과를 지우고 새롭게 (-) 입력 시작!
            if (isCalculated)
            {
                textBox_input.Clear();
                textBox_result.Clear();
                currentOperator = "";
                firstOperand = 0;
                isCalculated = false;

                currentNumber = "-";
                textBox_input.Text += "(-)";
                return;
            }

            // 아무것도 안 친 상태에서 +/- 누르면 (-)부터 시작!
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

            int oldLength = currentNumber.StartsWith("-") ? currentNumber.Length + 2 : currentNumber.Length; // ★ 수정: 현재 숫자가 음수면 괄호까지 포함해서 지우기
            textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - oldLength); // ★ 수정: 현재 숫자가 음수면 괄호까지 포함해서 지우기

            if (currentNumber.StartsWith("-"))
                currentNumber = currentNumber.Substring(1);
            else
                currentNumber = "-" + currentNumber;

            if (currentNumber.StartsWith("-"))
                textBox_input.Text += "(" + currentNumber + ")";
            else
                textBox_input.Text += currentNumber;
        }

        // 9. 루트(√) 버튼
        private void button_route_Click(object sender, EventArgs e)
        {
            // 1. 계산이 끝난 직후라면, 최종 결과값에 바로 루트를 씌움
            if (isCalculated)
            {
                if (firstOperand < 0)
                {
                    MessageBox.Show("음수의 제곱근은 계산할 수 없습니다.");
                    return;
                }
                double originalValue = firstOperand;
                firstOperand = Math.Sqrt(firstOperand); // 루트 계산

                // 화면 업데이트
                textBox_input.Text = "√(" + originalValue + ") = " + firstOperand.ToString();
                textBox_result.Text = firstOperand.ToString();
                return;
            }

            // 2. 숫자를 막 입력하던 중이라면, 그 숫자에 루트를 씌움
            if (currentNumber != "")
            {
                double val = double.Parse(currentNumber);
                if (val < 0)
                {
                    MessageBox.Show("음수의 제곱근은 계산할 수 없습니다.");
                    return;
                }
                double result = Math.Sqrt(val);

                // 화면에서 방금까지 치던 숫자를 잠깐 지움
                int oldLength = currentNumber.StartsWith("-") ? currentNumber.Length + 2 : currentNumber.Length;
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - oldLength);

                // 내부 숫자는 루트 계산 결과로 덮어쓰고, 화면에는 예쁘게 표시!
                currentNumber = result.ToString();
                textBox_input.Text += "√(" + val + ")";
            }
        }

        private void APP_Name_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}