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
using System.Threading;
using WpfApp3.Model;
using Npgsql;
using System.Data;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для NewAccount.xaml
    /// </summary>
   

public partial class NewAccount : Window
    {
        public NewAccount()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
       
        private void DepButton_Click(object sender, RoutedEventArgs e)
        {
            depDate.IsEnabled = true;
            Compl2Button.IsEnabled = true;
            rateBox.IsEnabled = true;
            sumBox.IsEnabled = true;
            CardButton.IsEnabled = false;
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            cardDate.IsEnabled = true;
            Compl1Button.IsEnabled = true;
            DepButton.IsEnabled = false;
            
        }

        private void Compl1Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            string code = r.Next(100, 999).ToString();
            string cardnum = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                cardnum += r.Next(0, 9).ToString();
            }
            string CardAcc = string.Empty;
            for (int i = 0; i < 20; i++)
            {
                CardAcc += r.Next(0, 9).ToString();
            }
            DateTime dt = (DateTime)cardDate.SelectedDate;
            dt.AddYears(4);
            ViewModel v = new ViewModel();
            string query = "insert into card values('" + CardAcc + "','" + cardnum + "','" + code + "','"
                + dt  +"'," + 300 +")";
            v.com = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            string query3 = "select from accounts card_account where account ='" + AccBox.Text + "'";
            v.com = new NpgsqlCommand(query3, v.con);
            NpgsqlDataReader reader3 = v.com.ExecuteReader();
            reader3.Close();
            if (query3 == null)
            {
                string query2 = "Update accounts set card_account ='" + CardAcc + "' where account = '" + AccBox.Text + "'";
                v.com = new NpgsqlCommand(query2, v.con);
                NpgsqlDataReader r2 = v.com.ExecuteReader();
                r2.Close();
            }
            else
            {
                string query4 = "insert into accounts (account, card_account) values('" + AccBox.Text 
                    + "','" + CardAcc + "')";
                v.com = new NpgsqlCommand(query4, v.con);
                NpgsqlDataReader reader4 = v.com.ExecuteReader();
                reader4.Close();
            }
            Close();
        }

        private void Compl2Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel v = new ViewModel();
            Random r = new Random();
            string depacc = string.Empty;
            for (int i = 0; i < 20; i++)
            {
                depacc += r.Next(0, 9).ToString();
            }
            int Amount =  int.Parse(sumBox.Text);
            string Currency = cur.Text;
            int Rate = int.Parse(rateBox.Text);
            DateTime dt = (DateTime)depDate.SelectedDate;
            string query = "insert into deposit values('" + depacc + "'," + Amount + ",'" + Currency + "',"
              + Rate + ",'" + dt + "')";
           
            v.com = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            string query4 = "insert into accounts (account, depos_account) values('" + AccBox.Text
                    + "','" + depacc + "')";
            v.com = new NpgsqlCommand(query4, v.con);
            NpgsqlDataReader reader4 = v.com.ExecuteReader();
            reader4.Close();
            v.AllDeposits();
            Close();
        }
    }
}
