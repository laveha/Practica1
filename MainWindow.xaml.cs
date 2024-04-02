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
            if (OsnDgr.SelectedItem != null)
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow window = new ClientsWindow();
            window.Show();
        }

        //EF

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    var osnov = new Practica1para.Osnovnaya ();
        //    osnov.PlaceTatu = PLaceTbx.Text;
        //    osnov.Client_ID = (ClientsCbx.SelectedItem as Clients).ID_Client;

        //    db.Osnovnaya.Add (osnov);
        //    db.SaveChanges();

        //    db.Osnovnaya.Add(new Osnovnaya());
        //    OsnDgr.ItemsSource = db.Osnovnaya.ToList();
        //}

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    if (OsnDgr.SelectedItem != null)
        //    {
        //        var osnov = OsnDgr.SelectedItem as Osnovnaya;
        //        osnov.PlaceTatu = PLaceTbx.Text;
        //        osnov.Client_ID = (ClientsCbx.SelectedItem as Clients).ID_Client;

        //        db.SaveChanges ();

        //        OsnDgr.ItemsSource = db.Osnovnaya.ToList();

        //    }
        //}

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    if (OsnDgr.SelectedItem != null)
        //    {
        //        var osnov = OsnDgr.SelectedItem as Osnovnaya;
        //        db.Osnovnaya.Remove (osnov);
        //        db.SaveChanges();

        //        OsnDgr.ItemsSource = db.Osnovnaya.ToList();

        //    }
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            osn.InsertOsn (Convert.ToInt32(ClientsCbx.SelectedValue), PLaceTbx.Text);
            OsnDgr.ItemsSource = osn.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (OsnDgr.SelectedItem != null)
            {
                var idosn = Convert.ToInt32((OsnDgr.SelectedItem as DataRowView).Row[0]);
                osn.UpdateOsn(Convert.ToInt32(ClientsCbx.SelectedValue), PLaceTbx.Text, idosn);
                OsnDgr.ItemsSource = osn.GetData();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (OsnDgr.SelectedItem != null)
            {
                var idosn = Convert.ToInt32((OsnDgr.SelectedItem as DataRowView).Row[0]);
                osn.DeleteOsn(idosn);
                OsnDgr.ItemsSource = osn.GetData();
            }
        }
    }
}