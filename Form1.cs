using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 계산 상태를 기억하기 위한 변수들
        int currentResult = 0;
        string currentOperator = "";
        bool isOperatorClicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. 숫자 버튼 클릭 이벤트
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // 초기 상태(0)이거나 연산자가 눌린 직후라면 입력창을 비워줌
            if (textBox_input.Text == "0" || isOperatorClicked)
            {
                textBox_input.Clear();
                isOperatorClicked = false;
            }

            // 누른 숫자를 위쪽 input 화면에 이어 붙이기
            textBox_input.Text += btn.Text;
        }

        // 2. 더하기(+) 버튼 클릭 이벤트
        private void button_plus_Click(object sender, EventArgs e)
        {
            // 위쪽 input 창에 입력된 문자를 정수로 변환하여 저장
            currentResult = int.Parse(textBox_input.Text);
            currentOperator = "+";
            isOperatorClicked = true;

            // textBox_result.Text = currentResult.ToString(); 
        }

        // 3. 결과 보기(=) 버튼 클릭 이벤트 (button_input)
        private void button_input_Click(object sender, EventArgs e)
        {
            // 두 번째 피연산자 가져오기 (위쪽 input 창 기준)
            int secondOperand = int.Parse(textBox_input.Text);
            int sum = 0;

            if (currentOperator == "+")
            {
                // 두 수 더하기 계산
                sum = currentResult + secondOperand;
            }

            // 윗쪽 텍스트 상자에 전체 수식 표시 (예: 5 + 2 = )
            textBox_input.Text = currentResult.ToString() + " + " + secondOperand.ToString() + " = ";

            // 계산된 최종 결과를 아랫쪽 result 텍스트 상자에 문자열로 표시
            textBox_result.Text = sum.ToString();

            // 다음 입력을 위해 상태 초기화
            isOperatorClicked = true;
        }
    }
}