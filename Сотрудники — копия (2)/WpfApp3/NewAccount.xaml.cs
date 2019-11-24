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
            CardAcc.IsEnabled = true;
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
            ViewModel v = new ViewModel();
        string query = "insert into card values('" + CardAcc.Text + "','" + cardnum + "','" + code + "','"
                + cardDate.SelectedDate + "')";
            string query2 = "Update accounts set card_account ='" + CardAcc.Text + "' where account = '" +v.CurrentClient.Account + "'";
            v.com = new NpgsqlCommand(query2, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            v.com = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader r2 = v.com.ExecuteReader();
            r2.Close();
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
            v.DeposAcc = depacc;
            v.Amount =  int.Parse(sumBox.Text);
            v.Currency = (string)cur.SelectedValue; 
            v.Rate = int.Parse(rateBox.Text);
            v.Limit = (DateTime)depDate.SelectedDate;
            string query = "insert into card values('" + v.DeposAcc + "'," + v.Amount + ",'" + v.Currency + "',"
              + v.Rate + ",'" + depDate.SelectedDate + "')";
            string query2 = "Update accounts set depos_account ='" + v.DeposAcc + "' where account = '" + v.CurrentClient.Account + "'";
            v.com = new NpgsqlCommand(query2, v.con);
            NpgsqlDataReader reader = v.com.ExecuteReader();
            reader.Close();
            v.com = new NpgsqlCommand(query, v.con);
            NpgsqlDataReader r2 = v.com.ExecuteReader();
            r2.Close();
            v.AllDeposits();

            Close();
        }
    }
}
