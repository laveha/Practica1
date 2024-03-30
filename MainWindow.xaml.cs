using System;
using System.Collections.Generic;
using System.Data;
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
using Practica1para.TatSaloonUchTableAdapters;

namespace Practica1para
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataSet
        OsnovnayaTableAdapter osn = new OsnovnayaTableAdapter();
        ClientsTableAdapter clients = new ClientsTableAdapter();

        //EF
        UchPracticaEntities db = new UchPracticaEntities();
        public MainWindow()
        {
            InitializeComponent();
            //DataSet
            OsnDgr.ItemsSource = osn.GetData();
            ClientsCbx.ItemsSource = clients.GetData();

            //EF
            //OsnDgr.ItemsSource = db.Osnovnaya.ToList();
            //ClientsCbx.ItemsSource = db.Clients.ToList();
        }

        private void OsnDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataSet
            var dannye = (OsnDgr.SelectedItem as DataRowView).Row;
            PLaceTbx.Text = dannye[2].ToString();
            ClientsCbx.SelectedValue = Convert.ToInt32(dannye[1]);

            //EF
            //var dannye = OsnDgr.SelectedItem as Osnovnaya;
            //PLaceTbx.Text = dannye.PlaceTatu;
            //ClientsCbx.SelectedItem = dannye.Clients;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow window = new ClientsWindow();
            window.Show();
        }
    }
}