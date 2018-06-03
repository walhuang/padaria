using Padaria.Data.Context;
using Padaria.Models;
using Padaria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Padaria
{
    /// <summary>
    /// Interaction logic for JanelaAdicionarProduto.xaml
    /// </summary>
    public partial class JanelaAdicionarProduto : Window
    {
        public JanelaAdicionarProduto()
        {
            InitializeComponent();
        }

        private void btnAdicionarProdutoClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)DataContext;
            int produtoId = int.Parse(txAdicionarProduto.Text);
            int compraId = int.Parse(main.valueCompra.Content.ToString());
            int quantidade = int.Parse(txQuantidade.Text);
            var db = new PadariaContext();

            Produto novoProduto = db.Produtos.Where(x => x.ProdutoId == produtoId).First();

            //adiciona no banco o novo registro de compraproduto
            CompraProduto compraProduto = new CompraProduto();
            compraProduto.QuantidadeProduto = quantidade;
            compraProduto.ValorTotal = quantidade * novoProduto.Preco;
            compraProduto.CompraId = compraId;
            compraProduto.ProdutoId = produtoId;
            db.CompraProdutos.Add(compraProduto);
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
        }

        private void btnParaClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
