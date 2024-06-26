﻿using System;
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
            ClientsTbx.Text = dannye.Surname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cl = new Practica1para.Clients();
            cl.Surname = ClientsTbx.Text;
            

            db.Clients.Add(cl);
            db.SaveChanges();

            db.Clients.Add(new Clients());
            ClientsDgr.ItemsSource = db.Clients.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ClientsDgr.SelectedItem != null)
            {
                var cl = ClientsDgr.SelectedItem as Clients;
                cl.Surname = ClientsTbx.Text;

                db.SaveChanges();

                ClientsDgr.ItemsSource = db.Clients.ToList();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ClientsDgr.SelectedItem != null)
            {
                var cl = ClientsDgr.SelectedItem as Clients;
                db.Clients.Remove(cl);
                db.SaveChanges();

                ClientsDgr.ItemsSource = db.Clients.ToList();

            }
        }
    }
}
