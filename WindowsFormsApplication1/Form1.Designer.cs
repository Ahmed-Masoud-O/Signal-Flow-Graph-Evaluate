namespace WindowsFormsApplication1
{
    partial class mainFrame
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
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.EvaluateButton = new System.Windows.Forms.Button();
            this.EndNodeButton = new System.Windows.Forms.Button();
            this.DisConnectButton = new System.Windows.Forms.Button();
            this.NodeButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PathButton = new System.Windows.Forms.Button();
            this.StartNodeButton = new System.Windows.Forms.Button();
            this.Input = new System.Windows.Forms.TextBox();
            this.TF = new System.Windows.Forms.RichTextBox();
            this.loop = new System.Windows.Forms.ListView();
            this.path = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonsPanel.BackColor = System.Drawing.Color.Green;
            this.ButtonsPanel.Controls.Add(this.EvaluateButton);
            this.ButtonsPanel.Controls.Add(this.EndNodeButton);
            this.ButtonsPanel.Controls.Add(this.DisConnectButton);
            this.ButtonsPanel.Controls.Add(this.NodeButton);
            this.ButtonsPanel.Controls.Add(this.DeleteButton);
            this.ButtonsPanel.Controls.Add(this.PathButton);
            this.ButtonsPanel.Controls.Add(this.StartNodeButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(-1, 1);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(1324, 44);
            this.ButtonsPanel.TabIndex = 0;
            this.ButtonsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonsPanel_Paint);
            // 
            // EvaluateButton
            // 
            this.EvaluateButton.BackColor = System.Drawing.Color.GreenYellow;
            this.EvaluateButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EvaluateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.EvaluateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.EvaluateButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EvaluateButton.Location = new System.Drawing.Point(1061, 10);
            this.EvaluateButton.Margin = new System.Windows.Forms.Padding(2);
            this.EvaluateButton.Name = "EvaluateButton";
            this.EvaluateButton.Size = new System.Drawing.Size(74, 27);
            this.EvaluateButton.TabIndex = 12;
            this.EvaluateButton.Text = "Evaluate";
            this.EvaluateButton.UseVisualStyleBackColor = false;
            this.EvaluateButton.Click += new System.EventHandler(this.EvaluateButton_Click);
            // 
            // EndNodeButton
            // 
            this.EndNodeButton.BackColor = System.Drawing.Color.GreenYellow;
            this.EndNodeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EndNodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.EndNodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.EndNodeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EndNodeButton.Location = new System.Drawing.Point(1240, 10);
            this.EndNodeButton.Margin = new System.Windows.Forms.Padding(2);
            this.EndNodeButton.Name = "EndNodeButton";
            this.EndNodeButton.Size = new System.Drawing.Size(74, 27);
            this.EndNodeButton.TabIndex = 11;
            this.EndNodeButton.Text = "EndNode";
            this.EndNodeButton.UseVisualStyleBackColor = false;
            this.EndNodeButton.Click += new System.EventHandler(this.EndNodeButton_Click);
            // 
            // DisConnectButton
            // 
            this.DisConnectButton.BackColor = System.Drawing.Color.GreenYellow;
            this.DisConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DisConnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DisConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.DisConnectButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DisConnectButton.Location = new System.Drawing.Point(641, 10);
            this.DisConnectButton.Margin = new System.Windows.Forms.Padding(2);
            this.DisConnectButton.Name = "DisConnectButton";
            this.DisConnectButton.Size = new System.Drawing.Size(74, 27);
            this.DisConnectButton.TabIndex = 8;
            this.DisConnectButton.Text = "DisConnect";
            this.DisConnectButton.UseVisualStyleBackColor = false;
            // 
            // NodeButton
            // 
            this.NodeButton.BackColor = System.Drawing.Color.GreenYellow;
            this.NodeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.NodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.NodeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NodeButton.Location = new System.Drawing.Point(14, 10);
            this.NodeButton.Margin = new System.Windows.Forms.Padding(2);
            this.NodeButton.Name = "NodeButton";
            this.NodeButton.Size = new System.Drawing.Size(74, 27);
            this.NodeButton.TabIndex = 6;
            this.NodeButton.Text = "Node";
            this.NodeButton.UseVisualStyleBackColor = false;
            this.NodeButton.Click += new System.EventHandler(this.NodeButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.GreenYellow;
            this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.DeleteButton.Location = new System.Drawing.Point(101, 10);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(90, 27);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete Node";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click_1);
            // 
            // PathButton
            // 
            this.PathButton.BackColor = System.Drawing.Color.GreenYellow;
            this.PathButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PathButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PathButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.PathButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PathButton.Location = new System.Drawing.Point(552, 10);
            this.PathButton.Margin = new System.Windows.Forms.Padding(2);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(74, 27);
            this.PathButton.TabIndex = 9;
            this.PathButton.Text = "Path";
            this.PathButton.UseVisualStyleBackColor = false;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // StartNodeButton
            // 
            this.StartNodeButton.BackColor = System.Drawing.Color.GreenYellow;
            this.StartNodeButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StartNodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StartNodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.StartNodeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StartNodeButton.Location = new System.Drawing.Point(1162, 10);
            this.StartNodeButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartNodeButton.Name = "StartNodeButton";
            this.StartNodeButton.Size = new System.Drawing.Size(74, 27);
            this.StartNodeButton.TabIndex = 10;
            this.StartNodeButton.Text = "StartNode";
            this.StartNodeButton.UseVisualStyleBackColor = false;
            this.StartNodeButton.Click += new System.EventHandler(this.StartNodeButton_Click);
            // 
            // Input
            // 
            this.Input.Enabled = false;
            this.Input.Location = new System.Drawing.Point(-1, 566);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(1324, 20);
            this.Input.TabIndex = 1;
            this.Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            // 
            // TF
            // 
            this.TF.Enabled = false;
            this.TF.Location = new System.Drawing.Point(820, 618);
            this.TF.Name = "TF";
            this.TF.Size = new System.Drawing.Size(503, 98);
            this.TF.TabIndex = 2;
            this.TF.Text = "";
            // 
            // loop
            // 
            this.loop.Location = new System.Drawing.Point(416, 619);
            this.loop.Name = "loop";
            this.loop.Size = new System.Drawing.Size(398, 97);
            this.loop.TabIndex = 3;
            this.loop.UseCompatibleStateImageBehavior = false;
            this.loop.View = System.Windows.Forms.View.List;
            this.loop.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // path
            // 
            this.path.FullRowSelect = true;
            this.path.Location = new System.Drawing.Point(-1, 618);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(411, 97);
            this.path.TabIndex = 4;
            this.path.UseCompatibleStateImageBehavior = false;
            this.path.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 602);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Forward Paths";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(601, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Loops";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1054, 602);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Transfere Function";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Input";
            // 
            // mainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1327, 718);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.path);
            this.Controls.Add(this.loop);
            this.Controls.Add(this.TF);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.ButtonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainFrame";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signal Flow Graph";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.mainFrame_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMoved);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button EndNodeButton;
        private System.Windows.Forms.Button DisConnectButton;
        private System.Windows.Forms.Button NodeButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.Button StartNodeButton;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Button EvaluateButton;
        internal System.Windows.Forms.RichTextBox TF;
        private System.Windows.Forms.ListView loop;
        private System.Windows.Forms.ListView path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

