﻿using System;
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
using StudioPilates.DAL;
using StudioPilates.Model;

namespace StudioPilates.View
{
    /// <summary>
    /// Interação lógica para frmCadAluno.xam
    /// </summary>
    public partial class frmCadAluno : Window
    {
        private Aluno a = new Aluno();

        public frmCadAluno()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Deseja remover o registro?", "Cadastro de Aluno",
               MessageBoxButton.YesNo, MessageBoxImage.Question) ==
               MessageBoxResult.Yes)
            {
                if (AlunoDAO.RemoverAluno(a))
                {
                    MessageBox.Show("Aluno removido com sucesso", "Cadastra Aluno", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Aluno não removido!", "Cadastra Aluno", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DesabilitarBotoes();
            }
            else
            {
                DesabilitarBotoes();
            }

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Deseja alterar o registro?", "Cadastro de Aluno",
               MessageBoxButton.YesNo, MessageBoxImage.Question) ==
               MessageBoxResult.Yes)
            {

                a.Nome = txtNome.Text;
                a.Sobrenome = txtSobrenme.Text;
                a.CPF = txtCPF.Text;
                a.Celular = txtCeular.Text;
                a.Telefone = txtTelefone.Text;
                a.AvaliacaoFisica = txtAvaliacaoFisica.Text;
                a.Endereco = txtEndereco.Text;
                a.Email = txtEmail.Text;


                if (AlunoDAO.AlterarAluno(a))
                {
                    MessageBox.Show("Aluno alterado com sucesso", "Cadastra Aluno", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Aluno não alterado!", "Cadastra Aluno", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DesabilitarBotoes();
            }
            else
            {
                DesabilitarBotoes();
            }

        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            a = new Aluno();
            
            a.Nome = txtNome.Text;
            a.Sobrenome = txtSobrenme.Text;
            a.CPF = txtCPF.Text;
            a.Nasc = dtNasc.Text;
            a.Celular = txtCeular.Text;
            a.Telefone = txtTelefone.Text;
            a.AvaliacaoFisica = txtAvaliacaoFisica.Text;
            a.Endereco = txtEndereco.Text;
            a.Email = txtEmail.Text;


            if (AlunoDAO.AdicionarAluno(a))
            {
                MessageBox.Show("Gravado com sucesso!", "Cadastro de Aluno",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível gravar!", "Cadastro de Aluno",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtNome.Text = "";
            txtNome.Focus();
        }

        private void btnBuscarCPFAluno_Click(object sender, RoutedEventArgs e)
        {
            a = new Aluno();
            if (!string.IsNullOrEmpty(txtBuscarAluno.Text))
            {
                a.CPF = txtBuscarAluno.Text;
                a = AlunoDAO.VerificaAlunoPorCPF(a);
                if (a != null)
                {
                    txtNome.Text = a.Nome;
                    txtSobrenme.Text = a.Sobrenome;
                    txtCPF.Text = a.CPF;
                    txtCeular.Text = a.Celular;
                    txtTelefone.Text = a.Telefone;
                    txtAvaliacaoFisica.Text = a.AvaliacaoFisica;
                    txtEndereco.Text = a.Endereco;
                    txtEmail.Text = a.Email;
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Aluno não encontrado!", "Cadastro de Aluno",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o campo da busca", "Cadastro de Aluno",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    


    public void HabilitarBotoes()
        {
            btnAlterar.IsEnabled = true;
            btnRemover.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            btnGravar.IsEnabled = false;
        }

        public void DesabilitarBotoes()
        {
            btnAlterar.IsEnabled = false;
            btnRemover.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnGravar.IsEnabled = true;
           
        }
    }
}
