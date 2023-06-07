

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
        string fileName = string.Empty;

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
                cbPlanilhas.SelectedIndex = 0;
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
            ep.Clear();
            if (newFile)
            {
                if (string.IsNullOrWhiteSpace(txtNameFile.Text))
                {
                    verify = false;
                    ep.SetError(txtNameFile, "Digite nome do arquivo que deseja salvar os dados da simulação");
                }
                else
                {
                    fileName = txtNameFile.Text;
                }
            }
            else
            {
                if (cbPlanilhas.SelectedItem.ToString() == "Selecione")
                {
                    verify = false;
                    ep.SetError(cbPlanilhas, "Escolha qual arquivo deseja salvar os dados da simulação");
                }
                else
                {
                    fileName = cbPlanilhas.SelectedItem.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(txtSaida.Text))
            {
                verify = false;
                ep.SetError(txtSaida, "Escreva a saída do simulador");
            }

            return verify;
        }

        private void SucessMessage(string message)
        {
            MessageBox.Show(message, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                if (VerifyNameSheet())
                {
                    SheetService.GeranateSheet(fileName, txtSaida.Text);

                    SucessMessage("Planilha gerada com sucesso");
                }
                else
                {
                    WarningMessage("Preencha todas as informações restantes");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message + Environment.NewLine + "Verifique os dados da saída do simulador");
            }
           
        }

        private void cbPlanilhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPlanilhas.SelectedItem.ToString() != "Selecione")
            {
                ChangeWriteOldSheet();
            }
        }

        #endregion




    }
}