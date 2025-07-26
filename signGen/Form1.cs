namespace signGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string selectedExePath = "null";
        private string hash = "";

        private void a(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedExePath))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "sha256.exe"; // Name of your compiled C++ program
                process.StartInfo.Arguments = "\"" + selectedExePath + "\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                hash = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                textBox2.Text = hash;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file";
                ofd.Filter = "Executable Files (*.exe)|*.exe"; // You can change this to restrict file types

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedExePath = ofd.FileName;
                    textBox1.Text = selectedExePath;
                    Button1.Enabled = true;
                    MessageBox.Show("Selected file: " + selectedExePath);
                    // You can now use filePath for further processing
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file";
                ofd.Filter = "Executable Files (*.exe)|*.exe"; // You can change this to restrict file types

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedExePath = ofd.FileName;
                    textBox1.Text = selectedExePath;
                    Button1.Enabled = true;
                    MessageBox.Show("Selected file: " + selectedExePath);
                    // You can now use filePath for further processing
                }
            }
        }
    }
}
