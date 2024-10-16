namespace S1084_AutoRelease
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
           NewProject newProject = new NewProject();
           newProject.Show();
        }
    }
}
