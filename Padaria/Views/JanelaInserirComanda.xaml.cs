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
    /// Interaction logic for JanelaInserirComanda.xaml
    /// </summary>
    public partial class JanelaInserirComanda : Window
    {
        public JanelaInserirComanda()
        {
            InitializeComponent();
        }

        private void btnLerComandaClick(object sender, RoutedEventArgs e)
        {
            int comandaId = int.Parse(txComanda.Text);
            var db = new PadariaContext();
            Comanda comanda = db.Comandas.Find(comandaId);
            MainWindow main = (MainWindow)DataContext;
            main.valueComanda.Content = comanda.Codigo;
            try
            {
                //procura a última compra de uma comanda pela data
                Compra ultimaCompra = db.Compras.Where(x => x.ComandaId == comandaId).OrderByDescending(x => x.DataPagamento).First();
                if (ultimaCompra.ValorPago != 0)
                {
                    //nova compra caso a última compra já seja paga no caso com ValorPago != 0
                    Compra novaCompra = new Compra();
                    novaCompra.ValorPago = 0;
                    novaCompra.ValorTroco = 0;
                    novaCompra.PrecoTotal = 0;
                    novaCompra.CompraId = comandaId;
                    novaCompra.DataPagamento = DateTime.Now;
                    novaCompra.ComandaId = int.Parse(main.valueComanda.Content.ToString());
                    db.Compras.Add(novaCompra);
                    db.SaveChanges();
                    main.valueCompra.Content = novaCompra.CompraId;
                    main.valuePrecoTotal.Content = 0;
                    main.txStatus.Text = "Nova Compra Detectada!";
                    Close();
                }
                else
                {
                    //mostra os produtos na tela
                    main.valueCompra.Content = ultimaCompra.CompraId;
                    var CompraProdutos = db.CompraProdutos.Where(x => x.CompraId == ultimaCompra.CompraId).ToList();
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
                    main.txStatus.Text = "Compra Detectada!";
                    Close();
                }
            }
            catch
            {
                //nova compra caso a comanda seja nova e não tenha compras
                Compra novaCompra = new Compra();
                novaCompra.ValorPago = 0;
                novaCompra.ValorTroco = 0;
                novaCompra.PrecoTotal = 0;
                novaCompra.CompraId = comandaId;
                novaCompra.DataPagamento = DateTime.Now;
                novaCompra.ComandaId = int.Parse(main.valueComanda.Content.ToString());
                db.Compras.Add(novaCompra);
                db.SaveChanges();
                main.valueCompra.Content = novaCompra.CompraId;
                main.valuePrecoTotal.Content = 0;
                main.txStatus.Text = "Nova Comanda Detectada!";
                Close();
            }
        }
    }
}
