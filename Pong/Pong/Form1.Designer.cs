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
            this.GamingPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.timerButton = new System.Windows.Forms.Button();
            this.GamingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamingPanel
            // 
            this.GamingPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.GamingPanel.Controls.Add(this.timerButton);
            this.GamingPanel.Controls.Add(this.button1);
            this.GamingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamingPanel.Location = new System.Drawing.Point(0, 0);
            this.GamingPanel.Name = "GamingPanel";
            this.GamingPanel.Size = new System.Drawing.Size(800, 450);
            this.GamingPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(308, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 101);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerButton
            // 
            this.timerButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.timerButton.Enabled = false;
            this.timerButton.FlatAppearance.BorderSize = 0;
            this.timerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.timerButton.Location = new System.Drawing.Point(308, 12);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(200, 101);
            this.timerButton.TabIndex = 2;
            this.timerButton.TabStop = false;
            this.timerButton.Text = "3";
            this.timerButton.UseVisualStyleBackColor = false;
            this.timerButton.Visible = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GamingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameForm";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.GamingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GamingPanel;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button timerButton;
    }
}

