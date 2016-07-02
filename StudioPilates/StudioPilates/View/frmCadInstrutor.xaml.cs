using StudioPilates.DAL;
using StudioPilates.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudioPilates.View
{
    /// <summary>
    /// Interação lógica para frmCadAluno.xam
    /// </summary>
    public partial class frmCadInstrutor : Window
    {

        private Instrutor i = new Instrutor();

        public frmCadInstrutor()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            i = new Instrutor();

            i.Nome = txtNome.Text;
            i.Sobrenome = txtSobrenome.Text;
            i.CPF = txtCPF.Text;
            i.Celula = txtCelular.Text;
            i.Telefone = txtTelefone.Text;
            i.Email = txtEmail.Text;
            i.Endereco = txtEndereco.Text;

            if (InstrutorDAO.AdicionarInstrutor(i))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Instrutor",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else {
                MessageBox.Show("Não foi possível gravar!", "Cadastro de Instrutor",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
    }

        private void btnBuscarCPFInstrutor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
