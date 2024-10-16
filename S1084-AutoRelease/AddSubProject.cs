using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S1084_AutoRelease
{
    public partial class AddSubProject : Form
    {
        public string name = "";
        public string subProjectPath = "";

        public AddSubProject()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            name = ProjectNameTextBox.Text;
            subProjectPath = ProjectPathTextBox.Text;

            if (name == "Please enter name")
            {
                MessageBox.Show("Please enter the Sxxxx name for the sub-project");
                return;
            }

            if (subProjectPath == "Please enter path")
            {
                MessageBox.Show("Please enter a valid directory path for the Sxxxx sub-project [C:\\...]");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
