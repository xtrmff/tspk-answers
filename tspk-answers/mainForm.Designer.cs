namespace tspk_answers
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.folderChooseBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Credits = new System.Windows.Forms.TextBox();
            this.discordLogo = new System.Windows.Forms.PictureBox();
            this.sayThankTaxtBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.discordLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // folderChooseBtn
            // 
            this.folderChooseBtn.Location = new System.Drawing.Point(92, 75);
            this.folderChooseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.folderChooseBtn.Name = "folderChooseBtn";
            this.folderChooseBtn.Size = new System.Drawing.Size(100, 25);
            this.folderChooseBtn.TabIndex = 0;
            this.folderChooseBtn.Text = "Выбрать Папку";
            this.folderChooseBtn.UseVisualStyleBackColor = true;
            this.folderChooseBtn.Click += new System.EventHandler(this.fileChooseBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Credits
            // 
            this.Credits.BackColor = System.Drawing.SystemColors.Control;
            this.Credits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Credits.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Credits.Location = new System.Drawing.Point(73, 12);
            this.Credits.Name = "Credits";
            this.Credits.ReadOnly = true;
            this.Credits.Size = new System.Drawing.Size(130, 20);
            this.Credits.TabIndex = 1;
            this.Credits.Text = "Credits: @Extrimoff";
            // 
            // discordLogo
            // 
            this.discordLogo.Image = global::tspk_answers.Properties.Resources._9738_discord_ico;
            this.discordLogo.Location = new System.Drawing.Point(200, 6);
            this.discordLogo.Name = "discordLogo";
            this.discordLogo.Size = new System.Drawing.Size(33, 31);
            this.discordLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.discordLogo.TabIndex = 2;
            this.discordLogo.TabStop = false;
            // 
            // sayThankTaxtBox
            // 
            this.sayThankTaxtBox.BackColor = System.Drawing.SystemColors.Control;
            this.sayThankTaxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sayThankTaxtBox.Location = new System.Drawing.Point(64, 33);
            this.sayThankTaxtBox.Name = "sayThankTaxtBox";
            this.sayThankTaxtBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.sayThankTaxtBox.ShowSelectionMargin = true;
            this.sayThankTaxtBox.Size = new System.Drawing.Size(187, 41);
            this.sayThankTaxtBox.TabIndex = 3;
            this.sayThankTaxtBox.Text = "Поблагодарить автора:\nВТБ: 2200 2404 4455 8627\nQIWI: https://qiwi.com/n/HIPAC407\n" +
    "";
            this.sayThankTaxtBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.sayThankTaxtBox_LinkClicked);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.sayThankTaxtBox);
            this.Controls.Add(this.discordLogo);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.folderChooseBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MagicProgram";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.discordLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button folderChooseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox Credits;
        private System.Windows.Forms.PictureBox discordLogo;
        private System.Windows.Forms.RichTextBox sayThankTaxtBox;
    }
}

