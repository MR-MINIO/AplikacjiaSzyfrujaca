namespace AplikacjiaSzyfrowanie
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            cb1 = new CheckBox();
            cb2 = new CheckBox();
            cb3 = new CheckBox();
            cb4 = new CheckBox();
            textBox2 = new TextBox();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(366, 238);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "- - - ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(136, 219);
            button1.Name = "button1";
            button1.Size = new Size(113, 53);
            button1.TabIndex = 1;
            button1.Text = "Koduj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(525, 219);
            button2.Name = "button2";
            button2.Size = new Size(107, 53);
            button2.TabIndex = 2;
            button2.Text = "Dekoduj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(274, 181);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // cb1
            // 
            cb1.AutoSize = true;
            cb1.Checked = true;
            cb1.CheckState = CheckState.Checked;
            cb1.Location = new Point(175, 90);
            cb1.Name = "cb1";
            cb1.Size = new Size(89, 19);
            cb1.TabIndex = 4;
            cb1.Text = "Szyfr Cezara";
            cb1.UseVisualStyleBackColor = true;
            cb1.CheckedChanged += checkBox_CheckedChanged;
            // 
            // cb2
            // 
            cb2.AutoSize = true;
            cb2.Location = new Point(280, 90);
            cb2.Name = "cb2";
            cb2.Size = new Size(99, 19);
            cb2.TabIndex = 5;
            cb2.Text = "Szyfr Playfaira";
            cb2.UseVisualStyleBackColor = true;
            cb2.CheckedChanged += checkBox_CheckedChanged;
            // 
            // cb3
            // 
            cb3.AutoSize = true;
            cb3.Location = new Point(396, 90);
            cb3.Name = "cb3";
            cb3.Size = new Size(100, 19);
            cb3.TabIndex = 6;
            cb3.Text = "Szyfr Vigenère";
            cb3.UseVisualStyleBackColor = true;
            cb3.CheckedChanged += checkBox_CheckedChanged;
            // 
            // cb4
            // 
            cb4.AutoSize = true;
            cb4.Location = new Point(504, 90);
            cb4.Name = "cb4";
            cb4.Size = new Size(107, 19);
            cb4.TabIndex = 7;
            cb4.Text = "Szyfr Polibiusza";
            cb4.UseVisualStyleBackColor = true;
            cb4.CheckedChanged += checkBox_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(275, 285);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(220, 95);
            textBox2.TabIndex = 8;
            // 
            // button3
            // 
            button3.Location = new Point(539, 304);
            button3.Name = "button3";
            button3.Size = new Size(80, 55);
            button3.TabIndex = 9;
            button3.Text = "Wynik jako dane wejściowe";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 181);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 10;
            label2.Text = "Dane wejściowe:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 288);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 11;
            label3.Text = "Dane wyjściowe:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(315, 143);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(127, 23);
            textBox3.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(175, 146);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 13;
            label4.Text = "Klucz:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(cb4);
            Controls.Add(cb3);
            Controls.Add(cb2);
            Controls.Add(cb1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Szyfrator V1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private CheckBox cb1;
        private CheckBox cb2;
        private CheckBox cb3;
        private CheckBox cb4;
        private TextBox textBox2;
        private Button button3;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
    }
}
