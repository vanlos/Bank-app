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
using Npgsql;
using WpfApp3.Model;
using System.Data;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
   
    public partial class NewClient : Window
    {
        public NewClient()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = new ViewModel();
            int a;
            if (v.Clients.Count == 0)
            {
                a = 296789;
            }
            else
            {
                a = v.Clients[v.Clients.Count - 1].Agreement + 1;
            }
            v.Name = NameBox.Text;
            v.SName = SNameBox.Text;
            v.Patron = PatronBox.Text;
            v.PassId = IdBox.Text;
            v.PassSeries = SeriesBox.Text;
            v.Account = AccountBox.Text;
            string query = "insert into client values(" + a + ",'" + v.Name + "','" + v.SName + "','" + v.Patron + "','" +
                               v.PassId + "','" + v.PassSeries + "','" + v.Account + "')";
            string query2 = "insert into accounts (account) values(" + "'" + v.Account + "')";
            v.com  = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            v.com = new NpgsqlCommand(query2, v.con);
            NpgsqlDataReader r2 = v.com.ExecuteReader();
            r2.Close();
            v.AllClients();
            Close();
        }
    }
}
