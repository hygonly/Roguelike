using ExcelToJson.Manager;

namespace ExcelToJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in Managers.Convert.GetExcelFiles())
                listBox1.Items.Add(item.Name);

            excelPathBox.Text = Managers.InI.GetValue(Utils.Defines.InIKeyType.ExcelPath);
            clientJsonBox.Text = Managers.InI.GetValue(Utils.Defines.InIKeyType.ClientJsonPath);
            clientSourceBox.Text = Managers.InI.GetValue(Utils.Defines.InIKeyType.ClientSourcePath);
            serverJsonBox.Text = Managers.InI.GetValue(Utils.Defines.InIKeyType.ServerJsonPath);
            serverSourceBox.Text = Managers.InI.GetValue(Utils.Defines.InIKeyType.ServerSourcePath);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in Managers.Convert.GetExcelFiles())
                listBox1.Items.Add(item.Name);
        }

        private void excelPath_TextChanged(object sender, EventArgs e)
        {
            Managers.InI.SetValue(Utils.Defines.InIKeyType.ExcelPath, excelPathBox.Text);
        }

        private void clientJsonBox_TextChanged(object sender, EventArgs e)
        {
            Managers.InI.SetValue(Utils.Defines.InIKeyType.ClientJsonPath, clientJsonBox.Text);
        }

        private void clientSourceBox_TextChanged(object sender, EventArgs e)
        {
            Managers.InI.SetValue(Utils.Defines.InIKeyType.ClientSourcePath, clientSourceBox.Text);
        }

        private void serverJsonBox_TextChanged(object sender, EventArgs e)
        {
            Managers.InI.SetValue(Utils.Defines.InIKeyType.ServerJsonPath, serverJsonBox.Text);
        }

        private void serverSourceBox_TextChanged(object sender, EventArgs e)
        {
            Managers.InI.SetValue(Utils.Defines.InIKeyType.ServerSourcePath, serverSourceBox.Text);
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            Managers.Convert.Clear();
            bool build = Managers.Convert.BuildExcelDataToClient();
            if (build == true)
                MessageBox.Show("¿Ï·á");
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
