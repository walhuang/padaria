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

namespace Padaria
{
    /// <summary>
    /// Interaction logic for JanelaVerComandas.xaml
    /// </summary>
    public partial class JanelaVerComandas : Window
    {
        public JanelaVerComandas()
        {
            InitializeComponent();
        }

        private void btnSairClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new PadariaContext();

            List<VerComandasViewModel> listViewModel = new List<VerComandasViewModel>();

            var Compras = db.Compras.OrderBy(x => x.DataPagamento).ToList();
           
            foreach (var c in Compras)
            {
                VerComandasViewModel viewModel = new VerComandasViewModel();
                viewModel.DataPagamento = c.DataPagamento;
                viewModel.ComandaId = c.ComandaId;
                viewModel.CompraId = c.CompraId ;
                viewModel.ValorPago = c.ValorPago;
                viewModel.ValorTroco = c.ValorTroco;
                viewModel.PrecoTotal = c.PrecoTotal;
                listViewModel.Add(viewModel);
            }
            dgVerComandas.ItemsSource = listViewModel;
        }
    }
}
