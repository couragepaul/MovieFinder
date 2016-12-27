using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A3V1
{
    public partial class getCommentForm : Form
    {
        public getCommentForm()
        {
            InitializeComponent();

            String comment = GlobalData.selectedMovie.getComment();

            if (comment == null)
                commentTextBox.Text = "No comment.";
            else
                commentTextBox.Text = comment;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
