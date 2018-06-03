using Padaria.Data.Context;
using Padaria.Views;
using Padaria.Models;
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
using Padaria.ViewModels;

namespace Padaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string caminho = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + "\\Data\\DataBase";
            AppDomain.CurrentDomain.SetData("DataDirectory", caminho);
            //atribuindo caminho do banco mdf na pasta Data\DataBase
            InitializeComponent();
            Show();
            valueData.Content = DateTime.Now.ToString("dd/MM/yyyy");
            JanelaLogin janela = new JanelaLogin();
            janela.DataContext = this;
            janela.Show();
        }

        private void menuVerComandasClick(object sender, RoutedEventArgs e)
        {
            JanelaVerComandas janela = new JanelaVerComandas();
            janela.Show();
        }
        private void menuSairClick(object sender, RoutedEventArgs e)
        {
            //fecha todas as janelas
            Application.Current.Shutdown();
        }

        private void menuAjudaClick(object sender, RoutedEventArgs e)
        {
            JanelaAjuda janela = new JanelaAjuda();
            janela.Show();
        }

        private void menuSobreClick(object sender, RoutedEventArgs e)
        {
            JanelaSobre janela = new JanelaSobre();
            janela.Show();
        }

        private void btnAdicionarProdutoClick(object sender, RoutedEventArgs e)
        {
            JanelaAdicionarProduto janela = new JanelaAdicionarProduto();
            janela.Show();
            janela.DataContext = this;
        }

        private void btnAlterarQuantidadeClick(object sender, RoutedEventArgs e)
        {
            JanelaAlterarQuantidade janela = new JanelaAlterarQuantidade();
            janela.Show();
            janela.DataContext = this;
        }

        private void btnRemoverProdutoClick(object sender, RoutedEventArgs e)
        {
            JanelaRemoverProduto janela = new JanelaRemoverProduto();
            janela.Show();
            janela.DataContext = this;
        }

        private void btnTerminarAcoesClick(object sender, RoutedEventArgs e)
        {
            JanelaInserirComanda janela = new JanelaInserirComanda();
            janela.Show();
            janela.DataContext = this;
            dgCompraProdutos.ItemsSource = null;
            valueComanda.Content = null;
            valueCompra.Content = null;
            valueData.Content = DateTime.Now.ToString("dd/MM/yyyy");
            valuePrecoTotal.Content = null;
        }

        private void btnRealizarPagamentoClick(object sender, RoutedEventArgs e)
        {
            if(double.Parse(valuePrecoTotal.Content.ToString()) == 0)
            {
                MessageBox.Show("Não é possível efetuar o pagamento quanto o Preço Total é de R$0", "Não Pode");
            }
            else
            {
                JanelaRealizarPagamento janela = new JanelaRealizarPagamento();
                janela.Show();
                janela.DataContext = this;
            }
        }
    }
}
