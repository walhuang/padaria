using Padaria.Data.Context;
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
    /// Interaction logic for JanelaAlterarQuantidade.xaml
    /// </summary>
    public partial class JanelaAlterarQuantidade : Window
    {
        public JanelaAlterarQuantidade()
        {
            InitializeComponent();
        }

        private void btnQuantidadeClick(object sender, RoutedEventArgs e)
        {
            int quantidade = int.Parse(txQuantidade.Text);

            var db = new PadariaContext();
            MainWindow main = (MainWindow)DataContext;

            int compraId = int.Parse(main.valueCompra.Content.ToString());

            CompraProdutosViewModel rowdata = (CompraProdutosViewModel)main.dgCompraProdutos.SelectedItem;
            var registro = db.CompraProdutos.Find(rowdata.CompraProdutoId);
            registro.QuantidadeProduto = quantidade;
            registro.ValorTotal = quantidade * rowdata.Preco;
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
            main.txStatus.Text = "Produto Atualizado na Comanda!";
            Close();
            }
    }
}
