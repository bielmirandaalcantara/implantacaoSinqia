using System;
using System.Windows.Forms;

namespace Sinqia.CoreBank.Criptografia.App
{
    public partial class FrmCriptografia : Form
    {
        Criptografia _cripto;
        public FrmCriptografia()
        {
            InitializeComponent();
            _cripto = new Criptografia();
        }

        private void btnCriptografar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string textoACriptografar = txtTexto.Text;
            string chaveCriptografada = txtChave.Text;

            _cripto.Key = chaveCriptografada;
            string textoCriptografado = _cripto.Encrypt(textoACriptografar);
            txtTextoCripto.Text = textoCriptografado;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                MessageBox.Show("É obrigatório o texto para criptografar");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtChave.Text))
            {
                MessageBox.Show("É obrigatório a chave para criptografar");
                return false;
            }

            return true;
        }

        private void salvarChave_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Sinqia.CoreBank.Registro");
                var KeyChave = key.CreateSubKey("chaveIntegrador");
                KeyChave.SetValue("Chave", txtChave.Text);
                KeyChave.Close();
                key.Close();
                MessageBox.Show("Chave gravada com Sucesso!");
            }
            catch (UnauthorizedAccessException erro)
            {
                MessageBox.Show("Não tem permissão de acesso: " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no gravação da chave do serviço: " + erro.Message);
            }
        }
    }
}
