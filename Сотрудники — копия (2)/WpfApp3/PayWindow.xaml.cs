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
using WpfApp3.Model;
using Npgsql;
using System.Data;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для PayWindow.xaml
    /// </summary>
    public partial class PayWindow : Window
    {
        public PayWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = new ViewModel();
            Random r = new Random();

            int amount = int.Parse(AmBox.Text);
            string query = "Update card set amount = amount - " + amount + 
                " where card_account = (select a.card_account from accounts a where a.account ='"+ AccBox.Text+"')"
                + "and amount = (select max(amount) from card)";
            v.com = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            v.AllCards();
            Close();
        }
    }
}
