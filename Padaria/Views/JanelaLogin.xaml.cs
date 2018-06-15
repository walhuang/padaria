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
    /// Interaction logic for JanelaLogin.xaml
    /// </summary>
    public partial class JanelaLogin : Window
    {
        public JanelaLogin()
        {
            InitializeComponent();
        }

        private void btnEntrarClick(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string senha = tbSenha.Password;

            var db = new PadariaContext();
            try
            {
                var registro = db.Usuarios.Where(x => x.Login == login && x.Senha == senha).First();
                if (registro != null)
                {
                    MessageBox.Show("Logado!", "Status Login");

                    MainWindow main = (MainWindow)DataContext;
                    main.Funcionario.Content = registro.Nome;
                    Close();

                    JanelaInserirComanda janela = new JanelaInserirComanda();
                    janela.DataContext = main;
                    janela.Show();
                }
            }
            catch
            {
                MessageBox.Show("Usuário não encontrado!", "Status Login");
            }
        }
    }
}
