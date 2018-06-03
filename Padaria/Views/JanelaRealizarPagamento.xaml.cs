using Padaria.Data.Context;
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
    /// Interaction logic for JanelaRealizarPagamento.xaml
    /// </summary>
    public partial class JanelaRealizarPagamento : Window
    {
        public JanelaRealizarPagamento()
        {
            InitializeComponent();
        }

        private void btnPagarClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)DataContext;
            var db = new PadariaContext();

            decimal PrecoTotal = decimal.Parse(main.valuePrecoTotal.Content.ToString());
            decimal ValorPago = decimal.Parse(txValorPago.Text);
            decimal ValorTroco = 0;
            DateTime DataPagamento = DateTime.Now;

            int compraId = int.Parse(main.valueCompra.Content.ToString());

            var Compra = db.Compras.Find(compraId);
            if(ValorPago >= PrecoTotal)
            {
                ValorTroco = ValorPago - PrecoTotal;
                Compra.PrecoTotal = PrecoTotal;
                Compra.ValorPago = ValorPago;
                Compra.ValorTroco = ValorTroco;
                Compra.DataPagamento = DataPagamento;
                db.SaveChanges();
                MessageBox.Show("Pagamento Efetuado, Troco: R$"+ValorTroco, "Troco");
                Close();
                JanelaInserirComanda janela = new JanelaInserirComanda();
                janela.Show();
                janela.DataContext = main;
                main.dgCompraProdutos.ItemsSource = null;
                main.valueComanda.Content = null;
                main.valueCompra.Content = null;
                main.valueData.Content = DateTime.Now.ToString("dd/MM/yyyy");
                main.valuePrecoTotal.Content = null;
            }
            else
            {
                MessageBox.Show("Valor Insuficiente!", "Aviso");
            }
        }
    }
}
