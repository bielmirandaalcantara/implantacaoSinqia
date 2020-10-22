using Microsoft.Win32;
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

            string chave = BuscarChaveVariavel();

            if (string.IsNullOrWhiteSpace(chave))
            {
                MessageBox.Show("A chave não foi gravada no ambiente");
                return;
            }

            _cripto.Key = chave;
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

            GravarChaveVariavel();            
            
        }

        private void GravarChaveVariavel()
        {
            string chave = txtChave.Text;
            if (string.IsNullOrWhiteSpace(chave))
            {
                MessageBox.Show("Chave inválida");
                return;
            }            

            try
            {
                Environment.SetEnvironmentVariable(ConstantesVariavel.CHAVESINQIA, chave, EnvironmentVariableTarget.Machine);
                MessageBox.Show("Chave gravada");
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

        private string BuscarChaveVariavel()
        {
            var chave = Environment.GetEnvironmentVariable(ConstantesVariavel.CHAVESINQIA, EnvironmentVariableTarget.Machine);
            return chave;
        }

        private void GravarChaveRegistroWindows()
        {
            RegistryKey rk0 = null;
            RegistryKey rk3264 = null;
            RegistryKey rk1 = null;
            RegistryKey rk2 = null;
            RegistryKey chaveIntegracao = null;

            try
            {
                bool is64 = System.Environment.Is64BitOperatingSystem;

                if (string.IsNullOrWhiteSpace(txtChave.Text))
                {
                    MessageBox.Show("Chave inválida");
                    return;
                }

                rk0 = Registry.LocalMachine.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel0, true);
                if (rk0 == null)
                    throw new Exception("Chave level 0 não encontrada no registro do Windows.");

                if (is64)
                {
                    rk3264 = rk0.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel64Bit, true);
                    if (rk3264 == null)
                        throw new Exception("Chave level 32-64 não encontrada no registro do Windows.");
                }
                else rk3264 = rk0;

                rk1 = rk0.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel1, true);
                if (rk1 == null) rk1 = rk0.CreateSubKey(ConstantesRegistro.SubChaveIntegradorLevel1);

                rk2 = rk1.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel2, true);
                if (rk2 == null) rk2 = rk1.CreateSubKey(ConstantesRegistro.SubChaveIntegradorLevel2);

                chaveIntegracao = rk2.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel3, true);
                if (chaveIntegracao == null) chaveIntegracao = rk2.CreateSubKey(ConstantesRegistro.SubChaveIntegradorLevel3);

                chaveIntegracao.SetValue(ConstantesRegistro.ChaveSelecao, txtChave.Text);

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
            finally
            {
                if (chaveIntegracao != null) chaveIntegracao.Close();
                if (rk2 != null) rk2.Close();
                if (rk1 != null) rk1.Close();
                if (rk3264 != null) rk3264.Close();
                if (rk0 != null) rk0.Close();
            }
        }

        private string BuscarChaveRegistroWindows()
        {
            
            string chave = string.Empty;
            
            RegistryKey rk0 = null;
            RegistryKey rk3264 = null;
            RegistryKey rk1 = null;
            RegistryKey rk2 = null;
            RegistryKey chaveIntegracao = null;

            try
            {
                bool is64 = System.Environment.Is64BitOperatingSystem;

                rk0 = Registry.LocalMachine.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel0, true);
                if (rk0 == null)
                    throw new Exception("Chave level 0 não encontrada no registro do Windows.");

                if (is64)
                {   
                    rk3264 = rk0.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel64Bit, true);
                    if (rk3264 == null)
                        throw new Exception("Chave level 32-64 não encontrada no registro do Windows.");
                }
                else rk3264 = rk0;

                rk1 = rk3264.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel1, true);
                if (rk1 == null) return chave;

                rk2 = rk1.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel2, true);
                if (rk2 == null) return chave;

                chaveIntegracao = rk2.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel3, true);
                if (chaveIntegracao == null) return chave;

                chave = chaveIntegracao.GetValue(ConstantesRegistro.ChaveSelecao).ToString();

            }
            catch (UnauthorizedAccessException erro)
            {
                MessageBox.Show("Não tem permissão de acesso: " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no gravação da chave do serviço: " + erro.Message);
            }
            finally
            {
                if(chaveIntegracao != null) chaveIntegracao.Close();
                if(rk2 != null) rk2.Close();
                if(rk1 != null) rk1.Close();
                if(rk3264 != null) rk3264.Close();
                if(rk0 != null) rk0.Close();
            }
            
            return chave;
        }

        private void FrmCriptografia_Load(object sender, EventArgs e)
        {
            string chave = BuscarChaveVariavel();
            txtChave.Text = chave;
        }
    }
}
