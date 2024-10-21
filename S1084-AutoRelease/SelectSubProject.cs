using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace S1084_AutoRelease
{
    public partial class SelectSubProject : Form
    {
        public string selectedSubProject = "";

        public SelectSubProject(XmlDocument db)
        {
            InitializeComponent();

            SubProjectsComboBox.Items.Clear();

            foreach (XmlNode node in db.GetElementsByTagName("SoftwareProjects")[0])
                SubProjectsComboBox.Items.Add(node.Name);
        }

        private void SubProjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSubProject = SubProjectsComboBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
