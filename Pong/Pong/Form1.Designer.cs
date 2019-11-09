namespace Pong
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gamingPanel = new System.Windows.Forms.Panel();
            this.timerButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gamingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamingPanel
            // 
            this.gamingPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.gamingPanel.Controls.Add(this.button1);
            this.gamingPanel.Controls.Add(this.timerButton);
            this.gamingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamingPanel.Location = new System.Drawing.Point(0, 0);
            this.gamingPanel.Name = "gamingPanel";
            this.gamingPanel.Size = new System.Drawing.Size(900, 600);
            this.gamingPanel.TabIndex = 0;
            // 
            // timerButton
            // 
            this.timerButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.timerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.timerButton.FlatAppearance.BorderSize = 0;
            this.timerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.timerButton.Location = new System.Drawing.Point(0, 0);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(900, 126);
            this.timerButton.TabIndex = 2;
            this.timerButton.TabStop = false;
            this.timerButton.Text = "0 : 0\r\n3";
            this.timerButton.UseVisualStyleBackColor = false;
            this.timerButton.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowText;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(0, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(900, 474);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.gamingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.gamingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamingPanel;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button timerButton;
    }
}

