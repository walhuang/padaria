using Padaria.Data.Context;
using Padaria.Models;
using Padaria.ViewModels;
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
using System.Windows.Shapes;

namespace Padaria.Views
{
    /// <summary>
    /// Interaction logic for JanelaLogin.xaml
    /// </summary>
    public partial class JanelaRemoverProduto : Window
    {
        public JanelaRemoverProduto()
        {
            InitializeComponent();
        }

        private void btnEntrarClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)DataContext;
            int compraId = int.Parse(main.valueCompra.Content.ToString());
            string login = tbLogin.Text;
            string senha = tbSenha.Text;

            CompraProdutosViewModel rowdata = (CompraProdutosViewModel)main.dgCompraProdutos.SelectedItem;

            
            var db = new PadariaContext();
            try
            {
                var registro = db.Usuarios.Where(x => x.Login == login && x.Senha == senha).First();
                if (registro != null)
                {
                    if(registro.isAdministrador == true)
                    {
                        CompraProduto compraProduto = db.CompraProdutos.Find(rowdata.CompraProdutoId);
                        db.CompraProdutos.Remove(compraProduto);
                        db.SaveChanges();

                        var CompraProdutos = db.CompraProdutos.Where(x => x.CompraId == compraId).ToList();
                        List<CompraProdutosViewModel> listViewModel = new List<CompraProdutosViewModel>();
                        foreach (var cp in CompraProdutos)
                        {
                            var Produto = db.Produtos.Where(x => x.ProdutoId == cp.ProdutoId).First();
                            CompraProdutosViewModel viewModel = new CompraProdutosViewModel();
                            viewModel.CompraProdutoId = cp.CompraProdutoId;
                            viewModel.CodigoBarra = Produto.CodigoBarra;
                            viewModel.Nome = Produto.Nome;
                            viewModel.Preco = Produto.Preco;
                            viewModel.QuantidadeProduto = cp.QuantidadeProduto;
                            viewModel.ValorTotal = cp.ValorTotal;
                            listViewModel.Add(viewModel);
                        }
                        main.valuePrecoTotal.Content = listViewModel.Sum(item => item.ValorTotal);
                        main.dgCompraProdutos.ItemsSource = listViewModel;
                        main.txStatus.Text = "Produto Removido!";
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuário fornecido não é um Administrador!", "Status Autenticação");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Usuário não encontrado!", "Status Autenticação");
            }
        }
    }
}
