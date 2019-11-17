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
       
        public NpgsqlConnection con { get; set; }
        public NpgsqlCommand com { get; set; }
        public byte[] Bytes;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "insert into client values(" +  NameBox.Text + ",'" + SNameBox.Text + "','" + PatronBox.Text + "','" +
                               IdBox.Text + "','" + SeriesBox.Text + "','" + AccountBox.Text + "',@bytes)";

            com = new NpgsqlCommand(query, con);
            com.Parameters.Add(
                    new NpgsqlParameter() { ParameterName = "@bytes", DbType = DbType.Binary, Value = Bytes }
                    );
            NpgsqlDataReader reader = com.ExecuteReader();
           
        }
    }
}
