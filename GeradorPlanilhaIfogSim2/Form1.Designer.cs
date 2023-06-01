namespace GeradorPlanilhaIfogSim2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            cbPlanilhas = new ComboBox();
            panel1 = new Panel();
            lblVersion = new Label();
            btnNew = new Button();
            label2 = new Label();
            txtNameFile = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            btnGerar = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Planilhas";
            // 
            // cbPlanilhas
            // 
            cbPlanilhas.FormattingEnabled = true;
            cbPlanilhas.Location = new Point(112, 19);
            cbPlanilhas.Name = "cbPlanilhas";
            cbPlanilhas.Size = new Size(240, 23);
            cbPlanilhas.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblVersion);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 423);
            panel1.Name = "panel1";
            panel1.Size = new Size(467, 27);
            panel1.TabIndex = 2;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Dock = DockStyle.Right;
            lblVersion.Location = new Point(424, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Padding = new Padding(0, 5, 5, 0);
            lblVersion.Size = new Size(43, 20);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "label2";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(368, 19);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 3;
            btnNew.Text = "Novo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome Arquivo:";
            // 
            // txtNameFile
            // 
            txtNameFile.Enabled = false;
            txtNameFile.Location = new Point(112, 54);
            txtNameFile.Name = "txtNameFile";
            txtNameFile.Size = new Size(240, 23);
            txtNameFile.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(112, 95);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 280);
            textBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 98);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 7;
            label3.Text = "Saída IFogSim2:";
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(277, 381);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(75, 23);
            btnGerar.TabIndex = 8;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 450);
            Controls.Add(btnGerar);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(txtNameFile);
            Controls.Add(label2);
            Controls.Add(btnNew);
            Controls.Add(panel1);
            Controls.Add(cbPlanilhas);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Gerador de Planilha";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbPlanilhas;
        private Panel panel1;
        private Label lblVersion;
        private Button btnNew;
        private Label label2;
        private TextBox txtNameFile;
        private TextBox textBox1;
        private Label label3;
        private Button btnGerar;
    }
}