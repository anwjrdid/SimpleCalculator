using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        double firstOperand = 0;
        string currentNumber = "";
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
                firstOperand = 0;
                isCalculated = false;
            }

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

        // 수식 평가 엔진 (암묵적 곱셈 처리 포함)
        private double Evaluate(string expr)
        {
            expr = expr.Replace(" ", ""); // 띄어쓰기 전부 제거

            // 1. 숨어있는 곱하기(×) 기호를 명시적으로 쏙쏙 끼워넣기!
            string newExpr = "";
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                newExpr += c;
                if (i < expr.Length - 1)
                {
                    char nextC = expr[i + 1];
                    bool isDigitOrDot = char.IsDigit(c) || c == '.';
                    bool isNextDigitOrDot = char.IsDigit(nextC) || nextC == '.';

                    // 규칙 A: 숫자 뒤에 여는 괄호나 루트가 오면 곱하기(×) 추가!
                    if (isDigitOrDot && (nextC == '(' || nextC == '√'))
                    {
                        newExpr += "×";
                    }
                    // 규칙 B: 닫는 괄호 뒤에 숫자, 괄호, 루트가 오면 곱하기(×) 추가!
                    else if (c == ')' && (isNextDigitOrDot || nextC == '(' || nextC == '√'))
                    {
                        newExpr += "×";
                    }
                }
            }
            expr = newExpr;

            // 2. 괄호 안쪽부터 먼저 계산!
            while (expr.Contains("("))
            {
                int close = expr.IndexOf(')');
                int open = expr.LastIndexOf('(', close);
                string inner = expr.Substring(open + 1, close - open - 1);

                double innerResult = EvalFlat(inner);

                string prefix = expr.Substring(0, open);
                string suffix = expr.Substring(close + 1);

                // 루트 기호 처리
                if (prefix.EndsWith("√"))
                {
                    innerResult = Math.Sqrt(innerResult);
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }

                expr = prefix + innerResult.ToString("0.################") + suffix;
            }

            // 3. 괄호가 다 풀렸으니 사칙연산 룰에 맞춰 계산!
            return EvalFlat(expr);
        }

        // 괄호 없는 수식을 사칙연산 우선순위에 맞게 푸는 함수
        private double EvalFlat(string expr)
        {
            List<string> tokens = Tokenize(expr);

            // 1순위: 거듭제곱(**)
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "**")
                {
                    double left = double.Parse(tokens[i - 1]);
                    double right = double.Parse(tokens[i + 1]);
                    tokens[i - 1] = Math.Pow(left, right).ToString("0.################");
                    tokens.RemoveRange(i, 2);
                    i--;
                }
            }
            // 2순위: 곱하기(×), 나누기(÷, /) (왼쪽에서 오른쪽으로!)
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "×" || tokens[i] == "÷" || tokens[i] == "/")
                {
                    double left = double.Parse(tokens[i - 1]);
                    double right = double.Parse(tokens[i + 1]);
                    double res = tokens[i] == "×" ? left * right : left / right;
                    tokens[i - 1] = res.ToString("0.################");
                    tokens.RemoveRange(i, 2);
                    i--;
                }
            }
            // 3순위: 더하기(+), 빼기(-)
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-")
                {
                    double left = double.Parse(tokens[i - 1]);
                    double right = double.Parse(tokens[i + 1]);
                    double res = tokens[i] == "+" ? left + right : left - right;
                    tokens[i - 1] = res.ToString("0.################");
                    tokens.RemoveRange(i, 2);
                    i--;
                }
            }

            if (tokens.Count > 0) return double.Parse(tokens[0]);
            return 0;
        }

        // 문자열을 기호와 숫자로 잘라주는 보조 함수 
        private List<string> Tokenize(string expr)
        {
            List<string> tokens = new List<string>();
            string currentNum = "";
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                if (char.IsDigit(c) || c == '.')
                {
                    currentNum += c;
                }
                else
                {
                    // ★ 변경: "×" 기호 인식 추가
                    bool isOperator = (tokens.Count > 0) && ("+-×÷/".Contains(tokens[tokens.Count - 1]) || tokens[tokens.Count - 1] == "**");
                    if (c == '-' && currentNum == "" && (tokens.Count == 0 || isOperator))
                    {
                        currentNum += c;
                    }
                    else
                    {
                        if (currentNum != "" && currentNum != "-")
                        {
                            tokens.Add(currentNum);
                            currentNum = "";
                        }
                        else if (currentNum == "-")
                        {
                            tokens.Add("-");
                            currentNum = "";
                        }

                        if (c == '*' && i + 1 < expr.Length && expr[i + 1] == '*')
                        {
                            tokens.Add("**");
                            i++;
                        }
                        else
                        {
                            tokens.Add(c.ToString());
                        }
                    }
                }
            }
            if (currentNum != "") tokens.Add(currentNum);
            return tokens;
        }

        // 연산자 버튼 공통 처리
        private void HandleOperator(string op)
        {
            if (isCalculated)
            {
                isCalculated = false;
                string prevRes = firstOperand.ToString("0.################");
                if (firstOperand < 0) prevRes = "(" + prevRes + ")";
                textBox_input.Text = prevRes + " " + op + " ";
                textBox_result.Clear();
                return;
            }

            string txt = textBox_input.Text.Trim();
            if (txt == "") return;

            if (currentNumber == "" && !txt.EndsWith(")") && !txt.EndsWith("√")) return;

            textBox_input.Text += " " + op + " ";
            currentNumber = "";
        }

        // 2-1. 더하기(+)
        private void button_plus_Click(object sender, EventArgs e) { HandleOperator("+"); }
        // 2-2. 빼기(-)
        private void button_sub_Click(object sender, EventArgs e) { HandleOperator("-"); }

        // ★ 2-3. 곱하기(×) - UI에서 '×' 기호 사용
        private void button_multiply_Click(object sender, EventArgs e)
        {
            // × 버튼을 두 번 누르면 거듭제곱(**)으로 변환
            if (textBox_input.Text.EndsWith(" × "))
            {
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3) + " ** ";
                return;
            }
            HandleOperator("×");
        }

        // 2-4. 나누기(÷)
        private void button_divide_Click(object sender, EventArgs e) { HandleOperator("÷"); }

        // 3. 결과 보기(=)
        private void button_input_Click(object sender, EventArgs e)
        {
            if (isCalculated) return;

            string txt = textBox_input.Text.Trim();
            // 마지막이 연산자로 끝나면 계산 안 함 (×, ** 포함)
            if (txt == "" || txt.EndsWith("+") || txt.EndsWith("-") || txt.EndsWith("×") || txt.EndsWith("/") || txt.EndsWith("÷") || txt.EndsWith("**")) return;

            try
            {
                string expr = textBox_input.Text;

                int openCount = expr.Split('(').Length - 1;
                int closeCount = expr.Split(')').Length - 1;
                while (openCount > closeCount)
                {
                    expr += ")";
                    textBox_input.Text += ")";
                    closeCount++;
                }

                double result = Evaluate(expr);

                textBox_input.Text += " = " + result.ToString("0.################");
                textBox_result.Text = result.ToString("0.################");

                firstOperand = result;
                isCalculated = true;
                currentNumber = "";
            }
            catch (Exception)
            {
                MessageBox.Show("수식에 오류가 있습니다.");
            }
        }

        // 4. C (Clear)
        private void button_c_Click(object sender, EventArgs e)
        {
            textBox_input.Clear();
            textBox_result.Clear();
            currentNumber = "";
            firstOperand = 0;
            isCalculated = false;
        }

        // 5. CE (Clear Entry)
        private void button_ce_Click(object sender, EventArgs e)
        {
            if (isCalculated) { button_c_Click(sender, e); return; }
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
                if (currentNumber == "-") textBox_input.Text += "(-)";
                else textBox_input.Text += "(" + currentNumber + ")";
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
                if (currentNumber == "") { currentNumber = "0."; textBox_input.Text += "0."; }
                else if (currentNumber == "-") { textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3); currentNumber = "-0."; textBox_input.Text += "(-0.)"; }
                else if (currentNumber.StartsWith("-")) { textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - (currentNumber.Length + 2)); currentNumber += "."; textBox_input.Text += "(" + currentNumber + ")"; }
                else { currentNumber += "."; textBox_input.Text += "."; }
            }
        }

        // 8. 음수/양수 전환(+/-) 버튼
        private void button_negative_Click(object sender, EventArgs e)
        {
            if (isCalculated)
            {
                textBox_input.Clear(); textBox_result.Clear(); firstOperand = 0; isCalculated = false;
                currentNumber = "-"; textBox_input.Text += "(-)"; return;
            }
            if (currentNumber == "") { currentNumber = "-"; textBox_input.Text += "(-)"; return; }
            if (currentNumber == "-") { currentNumber = ""; textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - 3); return; }

            int oldLength = currentNumber.StartsWith("-") ? currentNumber.Length + 2 : currentNumber.Length;
            textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - oldLength);

            currentNumber = currentNumber.StartsWith("-") ? currentNumber.Substring(1) : "-" + currentNumber;
            textBox_input.Text += currentNumber.StartsWith("-") ? "(" + currentNumber + ")" : currentNumber;
        }

        // 9. 루트(√) 버튼
        private void button_route_Click(object sender, EventArgs e)
        {
            if (isCalculated)
            {
                if (firstOperand < 0) { MessageBox.Show("음수의 제곱근은 계산할 수 없습니다."); return; }
                double originalValue = firstOperand;
                firstOperand = Math.Sqrt(firstOperand);
                textBox_input.Text = "√(" + originalValue + ") = " + firstOperand.ToString("0.################");
                textBox_result.Text = firstOperand.ToString("0.################");
                return;
            }

            if (currentNumber != "")
            {
                double val = double.Parse(currentNumber);
                if (val < 0) { MessageBox.Show("음수의 제곱근은 계산할 수 없습니다."); return; }
                double result = Math.Sqrt(val);

                int oldLength = currentNumber.StartsWith("-") ? currentNumber.Length + 2 : currentNumber.Length;
                textBox_input.Text = textBox_input.Text.Substring(0, textBox_input.Text.Length - oldLength);

                currentNumber = result.ToString("0.################");
                textBox_input.Text += "√(" + val + ")";
            }
        }

        // 10. 왼쪽 괄호 ( 버튼
        private void button_Lpare_Click(object sender, EventArgs e)
        {
            if (isCalculated) button_c_Click(sender, e);
            currentNumber = "";
            textBox_input.Text += "(";
        }

        // 11. 오른쪽 괄호 ) 버튼
        private void button_Rpare_Click(object sender, EventArgs e)
        {
            int openCount = textBox_input.Text.Split('(').Length - 1;
            int closeCount = textBox_input.Text.Split(')').Length - 1;
            if (openCount <= closeCount) return;

            currentNumber = "";
            textBox_input.Text += ")";
        }

        private void APP_Name_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e) { }
    }
}