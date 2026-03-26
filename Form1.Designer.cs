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
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            button_Lpare = new Button();
            button_Rpare = new Button();
            button_del = new Button();
            button_negative = new Button();
            button_0 = new Button();
            button_dot = new Button();
            button_1 = new Button();
            button_2 = new Button();
            button_3 = new Button();
            button_4 = new Button();
            button_5 = new Button();
            button_6 = new Button();
            button_9 = new Button();
            button_8 = new Button();
            button_7 = new Button();
            button_c = new Button();
            button_ce = new Button();
            button_input = new Button();
            button_plus = new Button();
            button_sub = new Button();
            button_multiply = new Button();
            button_divide = new Button();
            button_route = new Button();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // APP_Name
            // 
            APP_Name.AutoSize = true;
            APP_Name.Font = new Font("문체부 바탕체", 25F, FontStyle.Bold);
            APP_Name.ForeColor = SystemColors.HotTrack;
            APP_Name.Location = new Point(3, 0);
            APP_Name.Name = "APP_Name";
            APP_Name.Size = new Size(298, 42);
            APP_Name.TabIndex = 0;
            APP_Name.Text = "Simple Calculator";
            APP_Name.Click += APP_Name_Click;
            // 
            // textBox_input
            // 
            textBox_input.Dock = DockStyle.Fill;
            textBox_input.Location = new Point(3, 59);
            textBox_input.Name = "textBox_input";
            textBox_input.Size = new Size(741, 27);
            textBox_input.TabIndex = 1;
            // 
            // textBox_result
            // 
            textBox_result.Dock = DockStyle.Top;
            textBox_result.Location = new Point(3, 115);
            textBox_result.Name = "textBox_result";
            textBox_result.Size = new Size(741, 27);
            textBox_result.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(textBox_input, 0, 1);
            tableLayoutPanel2.Controls.Add(textBox_result, 0, 2);
            tableLayoutPanel2.Controls.Add(APP_Name, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(747, 170);
            tableLayoutPanel2.TabIndex = 23;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 297F));
            tableLayoutPanel3.Size = new Size(753, 473);
            tableLayoutPanel3.TabIndex = 24;
            tableLayoutPanel3.Paint += tableLayoutPanel3_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.3472214F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.6527786F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(button_Lpare, 0, 1);
            tableLayoutPanel1.Controls.Add(button_Rpare, 1, 1);
            tableLayoutPanel1.Controls.Add(button_del, 2, 0);
            tableLayoutPanel1.Controls.Add(button_negative, 0, 5);
            tableLayoutPanel1.Controls.Add(button_0, 1, 5);
            tableLayoutPanel1.Controls.Add(button_dot, 2, 5);
            tableLayoutPanel1.Controls.Add(button_1, 0, 4);
            tableLayoutPanel1.Controls.Add(button_2, 1, 4);
            tableLayoutPanel1.Controls.Add(button_3, 2, 4);
            tableLayoutPanel1.Controls.Add(button_4, 0, 3);
            tableLayoutPanel1.Controls.Add(button_5, 1, 3);
            tableLayoutPanel1.Controls.Add(button_6, 2, 3);
            tableLayoutPanel1.Controls.Add(button_9, 2, 2);
            tableLayoutPanel1.Controls.Add(button_8, 1, 2);
            tableLayoutPanel1.Controls.Add(button_7, 0, 2);
            tableLayoutPanel1.Controls.Add(button_c, 1, 0);
            tableLayoutPanel1.Controls.Add(button_ce, 0, 0);
            tableLayoutPanel1.Controls.Add(button_input, 3, 5);
            tableLayoutPanel1.Controls.Add(button_plus, 3, 4);
            tableLayoutPanel1.Controls.Add(button_sub, 3, 3);
            tableLayoutPanel1.Controls.Add(button_multiply, 3, 2);
            tableLayoutPanel1.Controls.Add(button_divide, 3, 1);
            tableLayoutPanel1.Controls.Add(button_route, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 179);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.2156868F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 21.17647F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9029121F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4757271F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.3300972F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(747, 291);
            tableLayoutPanel1.TabIndex = 23;
            // 
            // button_Lpare
            // 
            button_Lpare.Dock = DockStyle.Fill;
            button_Lpare.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_Lpare.Location = new Point(3, 49);
            button_Lpare.Name = "button_Lpare";
            button_Lpare.Size = new Size(180, 45);
            button_Lpare.TabIndex = 25;
            button_Lpare.Text = "（";
            button_Lpare.UseVisualStyleBackColor = true;
            button_Lpare.Click += button_Lpare_Click;
            // 
            // button_Rpare
            // 
            button_Rpare.Dock = DockStyle.Fill;
            button_Rpare.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_Rpare.Location = new Point(189, 49);
            button_Rpare.Name = "button_Rpare";
            button_Rpare.Size = new Size(183, 45);
            button_Rpare.TabIndex = 26;
            button_Rpare.Text = "）";
            button_Rpare.UseVisualStyleBackColor = true;
            button_Rpare.Click += button_Rpare_Click;
            // 
            // button_del
            // 
            button_del.Dock = DockStyle.Fill;
            button_del.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_del.ForeColor = Color.Coral;
            button_del.Location = new Point(378, 3);
            button_del.Name = "button_del";
            button_del.Size = new Size(178, 40);
            button_del.TabIndex = 5;
            button_del.Text = "Del";
            button_del.UseVisualStyleBackColor = true;
            button_del.Click += button_del_Click;
            // 
            // button_negative
            // 
            button_negative.Dock = DockStyle.Fill;
            button_negative.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_negative.ForeColor = Color.Chocolate;
            button_negative.Location = new Point(3, 243);
            button_negative.Name = "button_negative";
            button_negative.Size = new Size(180, 45);
            button_negative.TabIndex = 19;
            button_negative.Text = "+ / -";
            button_negative.UseVisualStyleBackColor = true;
            button_negative.Click += button_negative_Click;
            // 
            // button_0
            // 
            button_0.BackColor = SystemColors.ButtonHighlight;
            button_0.Dock = DockStyle.Fill;
            button_0.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_0.ForeColor = Color.CornflowerBlue;
            button_0.Location = new Point(189, 243);
            button_0.Name = "button_0";
            button_0.Size = new Size(183, 45);
            button_0.TabIndex = 20;
            button_0.Text = "0";
            button_0.UseVisualStyleBackColor = false;
            button_0.Click += NumberButton_Click;
            // 
            // button_dot
            // 
            button_dot.Dock = DockStyle.Fill;
            button_dot.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_dot.ForeColor = Color.Chocolate;
            button_dot.Location = new Point(378, 243);
            button_dot.Name = "button_dot";
            button_dot.Size = new Size(178, 45);
            button_dot.TabIndex = 21;
            button_dot.Text = ".";
            button_dot.UseVisualStyleBackColor = true;
            button_dot.Click += button_dot_Click;
            // 
            // button_1
            // 
            button_1.Dock = DockStyle.Fill;
            button_1.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_1.ForeColor = Color.CornflowerBlue;
            button_1.Location = new Point(3, 190);
            button_1.Name = "button_1";
            button_1.Size = new Size(180, 47);
            button_1.TabIndex = 15;
            button_1.Text = "1";
            button_1.UseVisualStyleBackColor = true;
            button_1.Click += NumberButton_Click;
            // 
            // button_2
            // 
            button_2.Dock = DockStyle.Fill;
            button_2.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_2.ForeColor = Color.CornflowerBlue;
            button_2.Location = new Point(189, 190);
            button_2.Name = "button_2";
            button_2.Size = new Size(183, 47);
            button_2.TabIndex = 16;
            button_2.Text = "2";
            button_2.UseVisualStyleBackColor = true;
            button_2.Click += NumberButton_Click;
            // 
            // button_3
            // 
            button_3.Dock = DockStyle.Fill;
            button_3.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_3.ForeColor = Color.CornflowerBlue;
            button_3.Location = new Point(378, 190);
            button_3.Name = "button_3";
            button_3.Size = new Size(178, 47);
            button_3.TabIndex = 17;
            button_3.Text = "3";
            button_3.UseVisualStyleBackColor = true;
            button_3.Click += NumberButton_Click;
            // 
            // button_4
            // 
            button_4.Dock = DockStyle.Fill;
            button_4.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_4.ForeColor = Color.CornflowerBlue;
            button_4.Location = new Point(3, 148);
            button_4.Name = "button_4";
            button_4.Size = new Size(180, 36);
            button_4.TabIndex = 11;
            button_4.Text = "4";
            button_4.UseVisualStyleBackColor = true;
            button_4.Click += NumberButton_Click;
            // 
            // button_5
            // 
            button_5.Dock = DockStyle.Fill;
            button_5.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_5.ForeColor = Color.CornflowerBlue;
            button_5.Location = new Point(189, 148);
            button_5.Name = "button_5";
            button_5.Size = new Size(183, 36);
            button_5.TabIndex = 12;
            button_5.Text = "5";
            button_5.UseVisualStyleBackColor = true;
            button_5.Click += NumberButton_Click;
            // 
            // button_6
            // 
            button_6.Dock = DockStyle.Fill;
            button_6.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_6.ForeColor = Color.CornflowerBlue;
            button_6.Location = new Point(378, 148);
            button_6.Name = "button_6";
            button_6.Size = new Size(178, 36);
            button_6.TabIndex = 13;
            button_6.Text = "6";
            button_6.UseVisualStyleBackColor = true;
            button_6.Click += NumberButton_Click;
            // 
            // button_9
            // 
            button_9.Dock = DockStyle.Fill;
            button_9.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_9.ForeColor = Color.CornflowerBlue;
            button_9.Location = new Point(378, 100);
            button_9.Name = "button_9";
            button_9.Size = new Size(178, 42);
            button_9.TabIndex = 9;
            button_9.Text = "9";
            button_9.UseVisualStyleBackColor = true;
            button_9.Click += NumberButton_Click;
            // 
            // button_8
            // 
            button_8.Dock = DockStyle.Fill;
            button_8.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_8.ForeColor = Color.CornflowerBlue;
            button_8.Location = new Point(189, 100);
            button_8.Name = "button_8";
            button_8.Size = new Size(183, 42);
            button_8.TabIndex = 8;
            button_8.Text = "8";
            button_8.UseVisualStyleBackColor = true;
            button_8.Click += NumberButton_Click;
            // 
            // button_7
            // 
            button_7.Dock = DockStyle.Fill;
            button_7.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_7.ForeColor = Color.CornflowerBlue;
            button_7.Location = new Point(3, 100);
            button_7.Name = "button_7";
            button_7.Size = new Size(180, 42);
            button_7.TabIndex = 7;
            button_7.Text = "7";
            button_7.UseVisualStyleBackColor = true;
            button_7.Click += NumberButton_Click;
            // 
            // button_c
            // 
            button_c.Dock = DockStyle.Fill;
            button_c.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_c.ForeColor = Color.Coral;
            button_c.Location = new Point(189, 3);
            button_c.Name = "button_c";
            button_c.Size = new Size(183, 40);
            button_c.TabIndex = 4;
            button_c.Text = "C";
            button_c.UseVisualStyleBackColor = true;
            button_c.Click += button_c_Click;
            // 
            // button_ce
            // 
            button_ce.Dock = DockStyle.Fill;
            button_ce.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_ce.ForeColor = Color.Coral;
            button_ce.Location = new Point(3, 3);
            button_ce.Name = "button_ce";
            button_ce.Size = new Size(180, 40);
            button_ce.TabIndex = 3;
            button_ce.Text = "CE";
            button_ce.UseVisualStyleBackColor = true;
            button_ce.Click += button_ce_Click;
            // 
            // button_input
            // 
            button_input.Dock = DockStyle.Fill;
            button_input.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_input.Location = new Point(562, 243);
            button_input.Name = "button_input";
            button_input.Size = new Size(182, 45);
            button_input.TabIndex = 22;
            button_input.Text = "=";
            button_input.UseVisualStyleBackColor = true;
            button_input.Click += button_input_Click;
            // 
            // button_plus
            // 
            button_plus.Dock = DockStyle.Fill;
            button_plus.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_plus.Location = new Point(562, 190);
            button_plus.Name = "button_plus";
            button_plus.Size = new Size(182, 47);
            button_plus.TabIndex = 18;
            button_plus.Text = "+";
            button_plus.UseVisualStyleBackColor = true;
            button_plus.Click += button_plus_Click;
            // 
            // button_sub
            // 
            button_sub.Dock = DockStyle.Fill;
            button_sub.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_sub.Location = new Point(562, 148);
            button_sub.Name = "button_sub";
            button_sub.Size = new Size(182, 36);
            button_sub.TabIndex = 14;
            button_sub.Text = "-";
            button_sub.UseVisualStyleBackColor = true;
            button_sub.Click += button_sub_Click;
            // 
            // button_multiply
            // 
            button_multiply.Dock = DockStyle.Fill;
            button_multiply.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_multiply.Location = new Point(562, 100);
            button_multiply.Name = "button_multiply";
            button_multiply.Size = new Size(182, 42);
            button_multiply.TabIndex = 10;
            button_multiply.Text = "×";
            button_multiply.UseVisualStyleBackColor = true;
            button_multiply.Click += button_multiply_Click;
            // 
            // button_divide
            // 
            button_divide.Dock = DockStyle.Fill;
            button_divide.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_divide.Location = new Point(562, 49);
            button_divide.Name = "button_divide";
            button_divide.Size = new Size(182, 45);
            button_divide.TabIndex = 6;
            button_divide.Text = "÷";
            button_divide.UseVisualStyleBackColor = true;
            button_divide.Click += button_divide_Click;
            // 
            // button_route
            // 
            button_route.Dock = DockStyle.Fill;
            button_route.Font = new Font("맑은 고딕", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_route.Location = new Point(378, 49);
            button_route.Name = "button_route";
            button_route.Size = new Size(178, 45);
            button_route.TabIndex = 27;
            button_route.Text = "√";
            button_route.UseVisualStyleBackColor = true;
            button_route.Click += button_route_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(753, 473);
            Controls.Add(tableLayoutPanel3);
            Name = "Form1";
            Text = "Calculator v1.0";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label APP_Name;
        private TextBox textBox_input;
        private TextBox textBox_result;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button_input;
        private Button button_dot;
        private Button button_0;
        private Button button_negative;
        private Button button_1;
        private Button button_2;
        private Button button_3;
        private Button button_plus;
        private Button button_sub;
        private Button button_multiply;
        private Button button_divide;
        private Button button_6;
        private Button button_5;
        private Button button_4;
        private Button button_7;
        private Button button_8;
        private Button button_9;
        private Button button_ce;
        private Button button_c;
        private Button button_del;
        private Button button_Lpare;
        private Button button_Rpare;
        private Button button_route;
    }
}
