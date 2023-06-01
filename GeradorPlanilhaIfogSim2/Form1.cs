

using GeradorPlanilhaIFogSim2.Domain;
using GeradorPlanilhaIFogSim2.Domain.Service;

namespace GeradorPlanilhaIfogSim2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeVariable();
        }

        #region Variables

        bool newFile = false;

        #endregion

        #region Proprieties

        #endregion

        #region Methods

        private void InitializeVariable()
        {
            lblVersion.Text = $"Versão: {Constants.Version}";
            IniciarComboBox();
        }

        private void IniciarComboBox()
        {
            List<string> files = FileService.ListFolder(Constants.SheetsPath);

            if (files.Count > 0)
            {
                cbPlanilhas.Enabled = true;
                cbPlanilhas.Items.Clear();
                cbPlanilhas.Items.Add("Selecione");
                cbPlanilhas.Items.AddRange(files.ToArray());
            }
            else
            {
                cbPlanilhas.Enabled = false;
                ChangeGenerateNewSheet();
            }


        }

        private void ChangeGenerateNewSheet()
        {
            newFile = true;
            txtNameFile.Enabled = true;
        }

        private void ChangeWriteOldSheet()
        {
            newFile = false;
            txtNameFile.Enabled = false;
        }

        private bool VerifyNameSheet()
        {
            bool verify = true;
            if (newFile)
            {
                if(string.IsNullOrWhiteSpace(txtNameFile.Text))
                {
                    verify = false;
                    WarningMessage("Digite nome do arquivo que deseja salvar os dados da simulação");
                }
            }
            else
            {
                if (cbPlanilhas.Items[cbPlanilhas.SelectedIndex].ToString() == "Selecione")
                {
                    verify = false;
                    WarningMessage("Escolha qual arquivo deseja salvar os dados da simulação");
                }
            }

            return verify;
        }

        private void SucessMessage(string message)
        {
            MessageBox.Show(message,"Sucess",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void WarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            ChangeGenerateNewSheet();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if(VerifyNameSheet())
            {
                
            }
        }

        #endregion



    }
}