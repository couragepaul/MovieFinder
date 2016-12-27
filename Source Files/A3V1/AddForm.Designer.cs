namespace A3V1
{
    partial class AddForm
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseFormLabel
            // 
            this.baseFormLabel.Location = new System.Drawing.Point(35, 9);
            this.baseFormLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.baseFormLabel.Size = new System.Drawing.Size(147, 13);
            this.baseFormLabel.Text = "Enter details about the movie:";
            // 
            // confirmButton
            // 
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // actorTextBox
            // 
            this.actorTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // yearTextBox
            // 
            this.yearTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // directorTextBox
            // 
            this.directorTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Margin = new System.Windows.Forms.Padding(3);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddForm
            // 
            this.AcceptButton = this.confirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(234, 281);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddForm";
            this.Text = "Add Movie";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
