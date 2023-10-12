namespace logbox
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            showTextBox = new RichTextBox();
            wordFormBox = new TextBox();
            comboBox = new ComboBox();
            btnOpenFile = new Button();
            openFileDialog = new OpenFileDialog();
            btnHighlight = new Button();
            btnParseLogs = new Button();
            addBox = new TextBox();
            btnAdd = new Button();
            btnChooseFiles = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // showTextBox
            // 
            showTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            showTextBox.Location = new Point(12, 258);
            showTextBox.MaximumSize = new Size(758, 283);
            showTextBox.MinimumSize = new Size(758, 283);
            showTextBox.Name = "showTextBox";
            showTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            showTextBox.Size = new Size(758, 283);
            showTextBox.TabIndex = 0;
            showTextBox.Text = "";
            // 
            // wordFormBox
            // 
            wordFormBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wordFormBox.Location = new Point(12, 102);
            wordFormBox.MaximumSize = new Size(758, 150);
            wordFormBox.MinimumSize = new Size(758, 150);
            wordFormBox.Multiline = true;
            wordFormBox.Name = "wordFormBox";
            wordFormBox.ScrollBars = ScrollBars.Vertical;
            wordFormBox.Size = new Size(758, 150);
            wordFormBox.TabIndex = 1;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Вирус", "Кака", "пука", "вирус", "кака", "Чирков", "гей" });
            comboBox.Location = new Point(12, 12);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(218, 28);
            comboBox.TabIndex = 2;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(253, 12);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(94, 29);
            btnOpenFile.TabIndex = 3;
            btnOpenFile.Text = "Open File";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // btnHighlight
            // 
            btnHighlight.Location = new Point(353, 12);
            btnHighlight.Name = "btnHighlight";
            btnHighlight.Size = new Size(94, 29);
            btnHighlight.TabIndex = 4;
            btnHighlight.Text = "Highlight";
            btnHighlight.UseVisualStyleBackColor = true;
            btnHighlight.Click += btnHighlight_Click;
            // 
            // btnParseLogs
            // 
            btnParseLogs.Location = new Point(649, 11);
            btnParseLogs.Name = "btnParseLogs";
            btnParseLogs.Size = new Size(121, 29);
            btnParseLogs.TabIndex = 5;
            btnParseLogs.Text = "Parse Log";
            btnParseLogs.UseVisualStyleBackColor = true;
            btnParseLogs.Click += btnParseLogs_Click;
            // 
            // addBox
            // 
            addBox.Location = new Point(12, 49);
            addBox.Name = "addBox";
            addBox.Size = new Size(218, 27);
            addBox.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(253, 49);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(194, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add word to list";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnChooseFiles
            // 
            btnChooseFiles.Location = new Point(649, 48);
            btnChooseFiles.Name = "btnChooseFiles";
            btnChooseFiles.Size = new Size(121, 29);
            btnChooseFiles.TabIndex = 8;
            btnChooseFiles.Text = "Choose Files";
            btnChooseFiles.UseVisualStyleBackColor = true;
            btnChooseFiles.Click += btnChooseFiles_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.InitialDirectory = "C:\\Users\\goha7\\Desktop\\prog\\timp\\5 sem timp\\repos\\logbox\\bin\\Debug\\net6.0-windows\\files";
            openFileDialog1.Multiselect = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(btnChooseFiles);
            Controls.Add(btnAdd);
            Controls.Add(addBox);
            Controls.Add(btnParseLogs);
            Controls.Add(btnHighlight);
            Controls.Add(btnOpenFile);
            Controls.Add(comboBox);
            Controls.Add(wordFormBox);
            Controls.Add(showTextBox);
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            Text = "Lab1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox showTextBox;
        private TextBox wordFormBox;
        private ComboBox comboBox;
        private Button btnOpenFile;
        private OpenFileDialog openFileDialog;
        private Button btnHighlight;
        private Button btnParseLogs;
        private TextBox addBox;
        private Button btnAdd;
        private Button btnChooseFiles;
        public OpenFileDialog openFileDialog1;
    }
}