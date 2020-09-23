using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
