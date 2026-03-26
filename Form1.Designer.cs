namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            APP_Name = new Label();
            textBox_input = new TextBox();
            textBox_result = new TextBox();
            button_ce = new Button();
            button_c = new Button();
            button_del = new Button();
            button_divide = new Button();
            button_7 = new Button();
            button_8 = new Button();
            button_9 = new Button();
            button_multiply = new Button();
            button_4 = new Button();
            button_5 = new Button();
            button_6 = new Button();
            button_sub = new Button();
            button_1 = new Button();
            button_2 = new Button();
            button_3 = new Button();
            button_plus = new Button();
            button_negative = new Button();
            button_0 = new Button();
            button_dot = new Button();
            button_input = new Button();
            SuspendLayout();
            // 
            // APP_Name
            // 
            APP_Name.AutoSize = true;
            APP_Name.Font = new Font("문체부 바탕체", 25F, FontStyle.Bold);
            APP_Name.ForeColor = SystemColors.HotTrack;
            APP_Name.Location = new Point(29, 21);
            APP_Name.Name = "APP_Name";
            APP_Name.Size = new Size(298, 42);
            APP_Name.TabIndex = 0;
            APP_Name.Text = "Simple Calculator";
            // 
            // textBox_input
            // 
            textBox_input.Location = new Point(29, 76);
            textBox_input.Name = "textBox_input";
            textBox_input.Size = new Size(286, 27);
            textBox_input.TabIndex = 1;
            // 
            // textBox_result
            // 
            textBox_result.Location = new Point(29, 123);
            textBox_result.Name = "textBox_result";
            textBox_result.Size = new Size(286, 27);
            textBox_result.TabIndex = 2;
            // 
            // button_ce
            // 
            button_ce.Location = new Point(29, 173);
            button_ce.Name = "button_ce";
            button_ce.Size = new Size(67, 34);
            button_ce.TabIndex = 3;
            button_ce.Text = "CE";
            button_ce.UseVisualStyleBackColor = true;
            button_ce.Click += button_ce_Click;
            // 
            // button_c
            // 
            button_c.Location = new Point(102, 173);
            button_c.Name = "button_c";
            button_c.Size = new Size(67, 34);
            button_c.TabIndex = 4;
            button_c.Text = "C";
            button_c.UseVisualStyleBackColor = true;
            button_c.Click += button_c_Click;
            // 
            // button_del
            // 
            button_del.Location = new Point(175, 173);
            button_del.Name = "button_del";
            button_del.Size = new Size(67, 34);
            button_del.TabIndex = 5;
            button_del.Text = "Del";
            button_del.UseVisualStyleBackColor = true;
            // 
            // button_divide
            // 
            button_divide.Location = new Point(248, 173);
            button_divide.Name = "button_divide";
            button_divide.Size = new Size(67, 34);
            button_divide.TabIndex = 6;
            button_divide.Text = "/";
            button_divide.UseVisualStyleBackColor = true;
            button_divide.Click += button_divide_Click;
            // 
            // button_7
            // 
            button_7.Location = new Point(29, 213);
            button_7.Name = "button_7";
            button_7.Size = new Size(67, 34);
            button_7.TabIndex = 7;
            button_7.Text = "7";
            button_7.UseVisualStyleBackColor = true;
            button_7.Click += NumberButton_Click;
            // 
            // button_8
            // 
            button_8.Location = new Point(102, 213);
            button_8.Name = "button_8";
            button_8.Size = new Size(67, 34);
            button_8.TabIndex = 8;
            button_8.Text = "8";
            button_8.UseVisualStyleBackColor = true;
            button_8.Click += NumberButton_Click;
            // 
            // button_9
            // 
            button_9.Location = new Point(175, 213);
            button_9.Name = "button_9";
            button_9.Size = new Size(67, 34);
            button_9.TabIndex = 9;
            button_9.Text = "9";
            button_9.UseVisualStyleBackColor = true;
            button_9.Click += NumberButton_Click;
            // 
            // button_multiply
            // 
            button_multiply.Location = new Point(248, 213);
            button_multiply.Name = "button_multiply";
            button_multiply.Size = new Size(67, 34);
            button_multiply.TabIndex = 10;
            button_multiply.Text = "*";
            button_multiply.UseVisualStyleBackColor = true;
            button_multiply.Click += button_multiply_Click;
            // 
            // button_4
            // 
            button_4.Location = new Point(29, 253);
            button_4.Name = "button_4";
            button_4.Size = new Size(67, 34);
            button_4.TabIndex = 11;
            button_4.Text = "4";
            button_4.UseVisualStyleBackColor = true;
            button_4.Click += NumberButton_Click;
            // 
            // button_5
            // 
            button_5.Location = new Point(102, 253);
            button_5.Name = "button_5";
            button_5.Size = new Size(67, 34);
            button_5.TabIndex = 12;
            button_5.Text = "5";
            button_5.UseVisualStyleBackColor = true;
            button_5.Click += NumberButton_Click;
            // 
            // button_6
            // 
            button_6.Location = new Point(175, 253);
            button_6.Name = "button_6";
            button_6.Size = new Size(67, 34);
            button_6.TabIndex = 13;
            button_6.Text = "6";
            button_6.UseVisualStyleBackColor = true;
            button_6.Click += NumberButton_Click;
            // 
            // button_sub
            // 
            button_sub.Location = new Point(248, 253);
            button_sub.Name = "button_sub";
            button_sub.Size = new Size(67, 34);
            button_sub.TabIndex = 14;
            button_sub.Text = "-";
            button_sub.UseVisualStyleBackColor = true;
            button_sub.Click += button_sub_Click;
            // 
            // button_1
            // 
            button_1.Location = new Point(29, 293);
            button_1.Name = "button_1";
            button_1.Size = new Size(67, 34);
            button_1.TabIndex = 15;
            button_1.Text = "1";
            button_1.UseVisualStyleBackColor = true;
            button_1.Click += NumberButton_Click;
            // 
            // button_2
            // 
            button_2.Location = new Point(102, 293);
            button_2.Name = "button_2";
            button_2.Size = new Size(67, 34);
            button_2.TabIndex = 16;
            button_2.Text = "2";
            button_2.UseVisualStyleBackColor = true;
            button_2.Click += NumberButton_Click;
            // 
            // button_3
            // 
            button_3.Location = new Point(175, 293);
            button_3.Name = "button_3";
            button_3.Size = new Size(67, 34);
            button_3.TabIndex = 17;
            button_3.Text = "3";
            button_3.UseVisualStyleBackColor = true;
            button_3.Click += NumberButton_Click;
            // 
            // button_plus
            // 
            button_plus.Location = new Point(248, 293);
            button_plus.Name = "button_plus";
            button_plus.Size = new Size(67, 34);
            button_plus.TabIndex = 18;
            button_plus.Text = "+";
            button_plus.UseVisualStyleBackColor = true;
            button_plus.Click += button_plus_Click;
            // 
            // button_negative
            // 
            button_negative.Location = new Point(29, 333);
            button_negative.Name = "button_negative";
            button_negative.Size = new Size(67, 34);
            button_negative.TabIndex = 19;
            button_negative.Text = "+ / -";
            button_negative.UseVisualStyleBackColor = true;
            // 
            // button_0
            // 
            button_0.Location = new Point(102, 333);
            button_0.Name = "button_0";
            button_0.Size = new Size(67, 34);
            button_0.TabIndex = 20;
            button_0.Text = "0";
            button_0.UseVisualStyleBackColor = true;
            button_0.Click += NumberButton_Click;
            // 
            // button_dot
            // 
            button_dot.Location = new Point(175, 333);
            button_dot.Name = "button_dot";
            button_dot.Size = new Size(67, 34);
            button_dot.TabIndex = 21;
            button_dot.Text = ".";
            button_dot.UseVisualStyleBackColor = true;
            // 
            // button_input
            // 
            button_input.Location = new Point(248, 333);
            button_input.Name = "button_input";
            button_input.Size = new Size(67, 34);
            button_input.TabIndex = 22;
            button_input.Text = "=";
            button_input.UseVisualStyleBackColor = true;
            button_input.Click += button_input_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 383);
            Controls.Add(button_input);
            Controls.Add(button_dot);
            Controls.Add(button_0);
            Controls.Add(button_negative);
            Controls.Add(button_plus);
            Controls.Add(button_3);
            Controls.Add(button_2);
            Controls.Add(button_1);
            Controls.Add(button_sub);
            Controls.Add(button_6);
            Controls.Add(button_5);
            Controls.Add(button_4);
            Controls.Add(button_multiply);
            Controls.Add(button_9);
            Controls.Add(button_8);
            Controls.Add(button_7);
            Controls.Add(button_divide);
            Controls.Add(button_del);
            Controls.Add(button_c);
            Controls.Add(button_ce);
            Controls.Add(textBox_result);
            Controls.Add(textBox_input);
            Controls.Add(APP_Name);
            Name = "Form1";
            Text = "Calculator v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label APP_Name;
        private TextBox textBox_input;
        private TextBox textBox_result;
        private Button button_ce;
        private Button button_c;
        private Button button_del;
        private Button button_divide;
        private Button button_7;
        private Button button_8;
        private Button button_9;
        private Button button_multiply;
        private Button button_4;
        private Button button_5;
        private Button button_6;
        private Button button_sub;
        private Button button_1;
        private Button button_2;
        private Button button_3;
        private Button button_plus;
        private Button button_negative;
        private Button button_0;
        private Button button_dot;
        private Button button_input;
    }
}
