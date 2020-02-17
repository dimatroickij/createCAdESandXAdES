namespace SignatureMaker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CADeSButton = new System.Windows.Forms.Button();
            this.XADeSButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CADeSButton
            // 
            resources.ApplyResources(this.CADeSButton, "CADeSButton");
            this.CADeSButton.Name = "CADeSButton";
            this.CADeSButton.UseVisualStyleBackColor = true;
            this.CADeSButton.Click += new System.EventHandler(this.CADeSButton_Click);
            // 
            // XADeSButton
            // 
            resources.ApplyResources(this.XADeSButton, "XADeSButton");
            this.XADeSButton.Name = "XADeSButton";
            this.XADeSButton.UseVisualStyleBackColor = true;
            this.XADeSButton.Click += new System.EventHandler(this.XADeSButton_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.XADeSButton);
            this.Controls.Add(this.CADeSButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CADeSButton;
        private System.Windows.Forms.Button XADeSButton;
    }
}

