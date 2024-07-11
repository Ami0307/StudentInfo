namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox StudentsList;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.ComboBox ProgramsBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ClearButton;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        private void InitializeComponent()
        {
            StudentsList = new ListBox();
            NameBox = new TextBox();
            EmailBox = new TextBox();
            ProgramsBox = new ComboBox();
            SaveButton = new Button();
            ClearButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // StudentsList
            // 
            StudentsList.FormattingEnabled = true;
            StudentsList.Location = new Point(21, 12);
            StudentsList.Name = "StudentsList";
            StudentsList.Size = new Size(534, 224);
            StudentsList.TabIndex = 0;
            StudentsList.SelectedIndexChanged += StudentsList_SelectedIndexChanged;
            // 
            // NameBox
            // 
            NameBox.Location = new Point(78, 257);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(84, 27);
            NameBox.TabIndex = 1;
            NameBox.TextChanged += NameBox_TextChanged;
            // 
            // EmailBox
            // 
            EmailBox.Location = new Point(243, 257);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(108, 27);
            EmailBox.TabIndex = 2;
            // 
            // ProgramsBox
            // 
            ProgramsBox.FormattingEnabled = true;
            ProgramsBox.Location = new Point(416, 256);
            ProgramsBox.Name = "ProgramsBox";
            ProgramsBox.Size = new Size(139, 28);
            ProgramsBox.TabIndex = 3;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(357, 308);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(168, 308);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(75, 23);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 260);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 6;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 260);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 7;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(357, 260);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 8;
            label3.Text = "Major";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(584, 361);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ClearButton);
            Controls.Add(SaveButton);
            Controls.Add(ProgramsBox);
            Controls.Add(EmailBox);
            Controls.Add(NameBox);
            Controls.Add(StudentsList);
            Name = "Form1";
            Text = "Student Management";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
    }
}