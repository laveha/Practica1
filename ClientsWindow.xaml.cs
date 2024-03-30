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

namespace Practica1para
{
    /// <summary>
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        UchPracticaEntities db = new UchPracticaEntities();
        public ClientsWindow()
        {
            InitializeComponent();
            ClientsDgr.ItemsSource = db.Clients.ToList();
        }

        private void ClientsDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dannye = ClientsDgr.SelectedItem as Clients;
            ClientsTbx.Text = dannye.Number;
        }
    }
}
