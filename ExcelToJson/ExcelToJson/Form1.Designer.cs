namespace ExcelToJson
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
            buildButton = new Button();
            refreshButton = new Button();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            clientJsonBox = new TextBox();
            clientSourceBox = new TextBox();
            serverSourceBox = new TextBox();
            serverJsonBox = new TextBox();
            excelPathBox = new TextBox();
            label1 = new Label();
            listBox1 = new ListBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buildButton
            // 
            buildButton.Location = new Point(647, 385);
            buildButton.Name = "buildButton";
            buildButton.Size = new Size(142, 40);
            buildButton.TabIndex = 0;
            buildButton.Text = "Build";
            buildButton.UseVisualStyleBackColor = true;
            buildButton.Click += buildButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(647, 347);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(142, 32);
            refreshButton.TabIndex = 1;
            refreshButton.Text = "새로고침";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(clientJsonBox);
            panel1.Controls.Add(clientSourceBox);
            panel1.Controls.Add(serverSourceBox);
            panel1.Controls.Add(serverJsonBox);
            panel1.Controls.Add(excelPathBox);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(23, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(608, 412);
            panel1.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 255);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 13;
            label5.Text = "Server source";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 195);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 12;
            label4.Text = "Server json";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 135);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 11;
            label3.Text = "Client source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 75);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 10;
            label2.Text = "Client json";
            // 
            // clientJsonBox
            // 
            clientJsonBox.Location = new Point(16, 93);
            clientJsonBox.Name = "clientJsonBox";
            clientJsonBox.Size = new Size(569, 23);
            clientJsonBox.TabIndex = 9;
            clientJsonBox.TextChanged += clientJsonBox_TextChanged;
            // 
            // clientSourceBox
            // 
            clientSourceBox.Location = new Point(16, 153);
            clientSourceBox.Name = "clientSourceBox";
            clientSourceBox.Size = new Size(569, 23);
            clientSourceBox.TabIndex = 8;
            clientSourceBox.TextChanged += clientSourceBox_TextChanged;
            // 
            // serverSourceBox
            // 
            serverSourceBox.Location = new Point(16, 273);
            serverSourceBox.Name = "serverSourceBox";
            serverSourceBox.Size = new Size(569, 23);
            serverSourceBox.TabIndex = 7;
            serverSourceBox.TextChanged += serverSourceBox_TextChanged;
            // 
            // serverJsonBox
            // 
            serverJsonBox.Location = new Point(16, 213);
            serverJsonBox.Name = "serverJsonBox";
            serverJsonBox.Size = new Size(569, 23);
            serverJsonBox.TabIndex = 6;
            serverJsonBox.TextChanged += serverJsonBox_TextChanged;
            // 
            // excelPathBox
            // 
            excelPathBox.Location = new Point(16, 33);
            excelPathBox.Name = "excelPathBox";
            excelPathBox.Size = new Size(569, 23);
            excelPathBox.TabIndex = 5;
            excelPathBox.TextChanged += excelPath_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 15);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Excel path";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(647, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(142, 319);
            listBox1.TabIndex = 14;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 439);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Controls.Add(refreshButton);
            Controls.Add(buildButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion 

        private Button buildButton;
        private Button refreshButton;
        private Panel panel1;
        private Label label1;
        private TextBox excelPathBox;
        private TextBox clientJsonBox;
        private TextBox clientSourceBox;
        private TextBox serverSourceBox;
        private TextBox serverJsonBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ListBox listBox1;
    }
}
