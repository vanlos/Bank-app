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
    /// Логика взаимодействия для TransWindow.xaml
    /// </summary>
    public partial class TransWindow : Window
    {
        public TransWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CardBu.IsEnabled = true;
            CardBox.IsEnabled = true;
            AmBox1.IsEnabled = true;
            SecBox.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DepBu.IsEnabled = true;
            DepBox.IsEnabled = true;
            AmBox2.IsEnabled = true;
            SecBox.IsEnabled = true;
        }

        private void CardBu_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = new ViewModel();
            Random r = new Random();
            int amount = int.Parse(AmBox1.Text);
            string opCode = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                opCode += r.Next(0, 9).ToString();
            }
            string secCode = SecBox.Text;
            string query = "Begin;" +
                " Update card set amount = amount - " + amount +
                " where card_account = (select a.card_account from accounts a " +
                " join card c on a.card_account = c.card_account where a.account = '" + AccBox1.Text + 
                "' and c.sec_code = '" + secCode + "' );"
                + "Update card set amount = amount + " + amount + " where card_num = '" + CardBox.Text + "';"
                + "insert into operations values ('" + opCode + "', 'Перевод на карту' ,'" + 58873517 + "','" + NameBox.Text 
                + "','" + SNameBox.Text + "','" + AccBox1.Text + "', CURRENT_DATE);"
                + "Commit;";
            v.com = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            v.AllCards();
            Close();
        }

        private void DepBu_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = new ViewModel();
            Random r = new Random();
            int amount = int.Parse(AmBox2.Text);
            string secCode = SecBox.Text;
            string opCode = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                opCode += r.Next(0, 9).ToString();
            }
            string query = "Begin;" +
                " Update card set amount = amount - " + amount +
                " where card_account = (select a.card_account from accounts a " +
                " join card c on a.card_account = c.card_account where a.account = '" + AccBox1.Text +
                "' and c.sec_code = '" + secCode + "' );"
                + "Update deposit set amount = amount + " + amount + " where depos_account = '" + DepBox.Text + "';"
                + "insert into operations values ('" + opCode + "', 'Перевод на вклад' ,'" + 58873517 + "','" + NameBox.Text
                + "','" + SNameBox.Text + "','" + AccBox1.Text + "', CURRENT_DATE);"
                + "Commit;";
            v.com = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            v.AllDeposits();
            Close();
        }
    }
}
