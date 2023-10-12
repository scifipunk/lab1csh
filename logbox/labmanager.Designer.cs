namespace logbox
{
    partial class labmanager
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
            LogBox = new RichTextBox();
            clearButton = new Button();
            menuStrip1 = new MenuStrip();
            labsToolStripMenuItem = new ToolStripMenuItem();
            lab1ToolStripMenuItem = new ToolStripMenuItem();
            fileToolStripMenuItem = new ToolStripMenuItem();
            btnHighlight = new Button();
            btnShowAmount = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dateSince = new DateTimePicker();
            dateFor = new DateTimePicker();
            btnConfirm = new Button();
            menuStrip1.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LogBox
            // 
            LogBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogBox.Location = new Point(12, 63);
            LogBox.MaximumSize = new Size(758, 438);
            LogBox.MinimumSize = new Size(758, 438);
            LogBox.Name = "LogBox";
            LogBox.Size = new Size(758, 438);
            LogBox.TabIndex = 0;
            LogBox.Text = "";
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clearButton.Location = new Point(327, 507);
            clearButton.MaximumSize = new Size(136, 34);
            clearButton.MinimumSize = new Size(136, 34);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(136, 34);
            clearButton.TabIndex = 1;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { labsToolStripMenuItem, fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(782, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // labsToolStripMenuItem
            // 
            labsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lab1ToolStripMenuItem });
            labsToolStripMenuItem.Name = "labsToolStripMenuItem";
            labsToolStripMenuItem.Size = new Size(53, 24);
            labsToolStripMenuItem.Text = "Labs";
            // 
            // lab1ToolStripMenuItem
            // 
            lab1ToolStripMenuItem.Name = "lab1ToolStripMenuItem";
            lab1ToolStripMenuItem.Size = new Size(124, 26);
            lab1ToolStripMenuItem.Text = "Lab1";
            lab1ToolStripMenuItem.Click += lab1ToolStripMenuItem_Click;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // btnHighlight
            // 
            btnHighlight.Location = new Point(469, 507);
            btnHighlight.Name = "btnHighlight";
            btnHighlight.Size = new Size(136, 34);
            btnHighlight.TabIndex = 4;
            btnHighlight.Text = "Highlight";
            btnHighlight.UseVisualStyleBackColor = true;
            btnHighlight.Click += btnHighlight_Click;
            // 
            // btnShowAmount
            // 
            btnShowAmount.Location = new Point(185, 507);
            btnShowAmount.Name = "btnShowAmount";
            btnShowAmount.Size = new Size(136, 34);
            btnShowAmount.TabIndex = 5;
            btnShowAmount.Text = "Show Stats";
            btnShowAmount.UseVisualStyleBackColor = true;
            btnShowAmount.Click += btnShowAmount_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(label1, 0, 1);
            tableLayoutPanel.Controls.Add(label2, 1, 0);
            tableLayoutPanel.Controls.Add(label3, 1, 2);
            tableLayoutPanel.Controls.Add(dateSince, 1, 1);
            tableLayoutPanel.Controls.Add(dateFor, 1, 3);
            tableLayoutPanel.Controls.Add(btnConfirm, 0, 2);
            tableLayoutPanel.Location = new Point(174, 150);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Size = new Size(397, 175);
            tableLayoutPanel.TabIndex = 6;
            tableLayoutPanel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 43);
            label1.Name = "label1";
            label1.Size = new Size(192, 43);
            label1.TabIndex = 0;
            label1.Text = "Choose Date";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(201, 0);
            label2.Name = "label2";
            label2.Size = new Size(193, 43);
            label2.TabIndex = 1;
            label2.Text = "since";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(201, 86);
            label3.Name = "label3";
            label3.Size = new Size(193, 43);
            label3.TabIndex = 2;
            label3.Text = "for";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dateSince
            // 
            dateSince.Format = DateTimePickerFormat.Time;
            dateSince.Location = new Point(201, 46);
            dateSince.Name = "dateSince";
            dateSince.Size = new Size(193, 27);
            dateSince.TabIndex = 3;
            // 
            // dateFor
            // 
            dateFor.Dock = DockStyle.Fill;
            dateFor.Format = DateTimePickerFormat.Time;
            dateFor.Location = new Point(201, 132);
            dateFor.Name = "dateFor";
            dateFor.Size = new Size(193, 27);
            dateFor.TabIndex = 4;
            // 
            // btnConfirm
            // 
            btnConfirm.Dock = DockStyle.Fill;
            btnConfirm.Location = new Point(3, 89);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(192, 37);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // labmanager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(tableLayoutPanel);
            Controls.Add(btnShowAmount);
            Controls.Add(btnHighlight);
            Controls.Add(menuStrip1);
            Controls.Add(clearButton);
            Controls.Add(LogBox);
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "labmanager";
            Text = "labmanager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox LogBox;
        private Button clearButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem labsToolStripMenuItem;
        private ToolStripMenuItem lab1ToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Button btnHighlight;
        private Button btnShowAmount;
        private TableLayoutPanel tableLayoutPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateSince;
        private DateTimePicker dateFor;
        private Button btnConfirm;
    }
}