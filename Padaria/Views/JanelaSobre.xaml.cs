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
    /// Interaction logic for JanelaSobre.xaml
    /// </summary>
    public partial class JanelaSobre : Window
    {
        public JanelaSobre()
        {
            InitializeComponent();
        }

        private void okSobreClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
