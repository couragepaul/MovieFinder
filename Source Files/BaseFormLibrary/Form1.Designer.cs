namespace BaseFormLibrary
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
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.actorTextBox = new System.Windows.Forms.TextBox();
            this.genreLabel = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.actorLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.directorLabel = new System.Windows.Forms.Label();
            this.directorTextBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.ratingComboBox = new System.Windows.Forms.ComboBox();
            this.baseFormLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(87, 63);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(107, 20);
            this.titleTextBox.TabIndex = 1;
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(34, 169);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(41, 13);
            this.ratingLabel.TabIndex = 9;
            this.ratingLabel.Text = "Rating:";
            // 
            // actorTextBox
            // 
            this.actorTextBox.Location = new System.Drawing.Point(87, 89);
            this.actorTextBox.Name = "actorTextBox";
            this.actorTextBox.Size = new System.Drawing.Size(107, 20);
            this.actorTextBox.TabIndex = 2;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(34, 143);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(39, 13);
            this.genreLabel.TabIndex = 8;
            this.genreLabel.Text = "Genre:";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(87, 115);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(57, 20);
            this.yearTextBox.TabIndex = 3;
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Items.AddRange(new object[] {
            "Action",
            "Adventure",
            "Animation",
            "Comedy",
            "Crime",
            "Drama",
            "History",
            "Mystery",
            "Romance",
            "Sci-fi",
            "Short",
            "Thriller",
            "War",
            "Western"});
            this.genreComboBox.Location = new System.Drawing.Point(87, 141);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(107, 21);
            this.genreComboBox.TabIndex = 4;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(34, 117);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(32, 13);
            this.yearLabel.TabIndex = 6;
            this.yearLabel.Text = "Year:";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(38, 235);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // actorLabel
            // 
            this.actorLabel.AutoSize = true;
            this.actorLabel.Location = new System.Drawing.Point(34, 90);
            this.actorLabel.Name = "actorLabel";
            this.actorLabel.Size = new System.Drawing.Size(35, 13);
            this.actorLabel.TabIndex = 4;
            this.actorLabel.Text = "Actor:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(119, 235);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(34, 65);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 13);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Title:";
            // 
            // directorLabel
            // 
            this.directorLabel.AutoSize = true;
            this.directorLabel.Location = new System.Drawing.Point(34, 40);
            this.directorLabel.Name = "directorLabel";
            this.directorLabel.Size = new System.Drawing.Size(47, 13);
            this.directorLabel.TabIndex = 16;
            this.directorLabel.Text = "Director:";
            // 
            // directorTextBox
            // 
            this.directorTextBox.Location = new System.Drawing.Point(87, 37);
            this.directorTextBox.Name = "directorTextBox";
            this.directorTextBox.Size = new System.Drawing.Size(107, 20);
            this.directorTextBox.TabIndex = 0;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(34, 194);
            this.lengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(43, 13);
            this.lengthLabel.TabIndex = 18;
            this.lengthLabel.Text = "Length:";
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(87, 192);
            this.lengthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(57, 20);
            this.lengthTextBox.TabIndex = 6;
            // 
            // ratingComboBox
            // 
            this.ratingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ratingComboBox.FormattingEnabled = true;
            this.ratingComboBox.Items.AddRange(new object[] {
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.ratingComboBox.Location = new System.Drawing.Point(87, 167);
            this.ratingComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ratingComboBox.Name = "ratingComboBox";
            this.ratingComboBox.Size = new System.Drawing.Size(57, 21);
            this.ratingComboBox.TabIndex = 5;
            // 
            // baseFormLabel
            // 
            this.baseFormLabel.AutoSize = true;
            this.baseFormLabel.Location = new System.Drawing.Point(84, 9);
            this.baseFormLabel.Name = "baseFormLabel";
            this.baseFormLabel.Size = new System.Drawing.Size(57, 13);
            this.baseFormLabel.TabIndex = 22;
            this.baseFormLabel.Text = "Base Form";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 281);
            this.Controls.Add(this.baseFormLabel);
            this.Controls.Add(this.ratingComboBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.directorTextBox);
            this.Controls.Add(this.actorTextBox);
            this.Controls.Add(this.directorLabel);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.actorLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.confirmButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label actorLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label directorLabel;
        private System.Windows.Forms.Label lengthLabel;
        protected System.Windows.Forms.Label baseFormLabel;
        protected System.Windows.Forms.Button confirmButton;
        protected System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.TextBox titleTextBox;
        protected System.Windows.Forms.TextBox actorTextBox;
        protected System.Windows.Forms.TextBox yearTextBox;
        protected System.Windows.Forms.ComboBox genreComboBox;
        protected System.Windows.Forms.TextBox directorTextBox;
        protected System.Windows.Forms.TextBox lengthTextBox;
        protected System.Windows.Forms.ComboBox ratingComboBox;
    }
}

