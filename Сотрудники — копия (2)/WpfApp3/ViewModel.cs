using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Npgsql;
using System.Drawing;


namespace WpfApp3.Model
{
    public class ViewModel : DependencyObject
    {
        #region connect

        public NpgsqlConnection con { get; set; }
        public NpgsqlCommand com { get; set; }

        #endregion
        #region ForClient
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));

        public string SName
        {
            get { return (string)GetValue(SNameProperty); }
            set { SetValue(SNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SNameProperty =
            DependencyProperty.Register("SName", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));
        public string Patron
        {
            get { return (string)GetValue(PatronProperty); }
            set { SetValue(PatronProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PatronProperty =
            DependencyProperty.Register("Patron", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));
        public string Agreement
        {
            get { return (string)GetValue(AgreementProperty); }
            set { SetValue(AgreementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Agreement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgreementProperty =
            DependencyProperty.Register("Agreement", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));
        public int PassId
        {
            get { return (int)GetValue(PassIdProperty); }
            set { SetValue(PassIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PassIdProperty =
            DependencyProperty.Register("PassId", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
        public int PassSeries
        {
            get { return (int)GetValue(PassSeriesProperty); }
            set { SetValue(PassSeriesProperty, value); }
        }
        public static readonly DependencyProperty PassSeriesProperty =
             DependencyProperty.Register("PassSeries", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
        public string Account
        {
            get { return (string)GetValue(AccountProperty); }
            set { SetValue(AccountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountProperty =
            DependencyProperty.Register("Account", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));


        public byte[] Bytes;

        #endregion
        #region ForFind

        public string FindPassword
        {
            get { return (string)GetValue(FindPasswordProperty); }
            set { SetValue(FindPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FindPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FindPasswordProperty =
            DependencyProperty.Register("FindPassword", typeof(string), typeof(ViewModel),
                new PropertyMetadata(string.Empty));

        public string FindKey
        {
            get { return (string)GetValue(FindKeyProperty); }
            set { SetValue(FindKeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FindPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FindKeyProperty =
            DependencyProperty.Register("FindKey", typeof(string), typeof(ViewModel),
                new PropertyMetadata(string.Empty));

        public string FindAgreement
        {
            get { return (string)GetValue(FindAgreementProperty); }
            set { SetValue(FindAgreementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FindAgreement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FindAgreementProperty =
            DependencyProperty.Register("FindAgreement", typeof(string), typeof(ViewModel),
                new PropertyMetadata(string.Empty));
        public string FindName
        {
            get { return (string)GetValue(FindNameProperty); }
            set { SetValue(FindNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FindName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FindNameProperty =
            DependencyProperty.Register("FindName", typeof(string), typeof(ViewModel),
                new PropertyMetadata(string.Empty));

        #endregion
        #region CollectionAndObject
        public List<Client> Clients
        {
            get { return (List<Client>)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        public static readonly DependencyProperty ClientsProperty =
           DependencyProperty.Register("Clients", typeof(List<Client>), typeof(ViewModel), new PropertyMetadata(null));

        public Client CurrentClient
        {
            get { return (Client)GetValue(CurrentPhoneProperty); }
            set { SetValue(CurrentPhoneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPhoneProperty =
            DependencyProperty.Register("CurrentClient", typeof(Client), typeof(ViewModel), new PropertyMetadata(null));


        #endregion
        #region Commands
        public DelegateCommand AddClientCommand
        {
            get { return (DelegateCommand)GetValue(AddClientCommandProperty); }
            set { SetValue(AddClientCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddClientCommandProperty =
            DependencyProperty.Register("AddClientCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

        public DelegateCommand DeleteClientCommand
        {
            get { return (DelegateCommand)GetValue(DeleteClientCommandProperty); }
            set { SetValue(DeleteClientCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteClientCommandProperty =
            DependencyProperty.Register("DeleteClientCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

        public DelegateCommand AddAccCommand
        {
            get { return (DelegateCommand)GetValue(AddAccProperty); }
            set { SetValue(AddAccProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddAccProperty =
            DependencyProperty.Register("AddAcc", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

        public DelegateCommand PayCommand
        {
            get { return (DelegateCommand)GetValue(PayCommandProperty); }
            set { SetValue(PayCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PayCommandProperty =
            DependencyProperty.Register("PayCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

        public DelegateCommand FindCommand
        {
            get { return (DelegateCommand)GetValue(FindCommandProperty); }
            set { SetValue(FindCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FindCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FindCommandProperty =
            DependencyProperty.Register("FindCommand", typeof(DelegateCommand), typeof(ViewModel),
                new PropertyMetadata(null));



        #endregion
        public ViewModel()
        {
            #region Command
            AddClientCommand = new DelegateCommand(AddClient, () => true);
            PayCommand = new DelegateCommand(Pay, () => true);
            DeleteClientCommand = new DelegateCommand(DeleteClient, () => true);
            AddAccCommand = new DelegateCommand(AddAccount, () => true);

            FindCommand = new DelegateCommand(Find, () => true);
            #endregion

            try
            {
                con = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Database=phones;");
                con.Open();
            }
            catch
            {
                MessageBox.Show("Невозможно подключиться к серверу");
                Environment.Exit(0);
            }

            Clients = new List<Client>();
            CurrentClient = new Client();
            AllClients();
        }
        public void Pay()
        {
            PayWindow p = new PayWindow();
            p.Show();
        }
        public void AddClient()
        {
            NewClient nc = new NewClient();
            nc.Show();
            
        }
        public void AddAccount()
        {
            NewAccount na = new NewAccount();
            na.Show();
        }
        public void AllClients()
        {
            string CmdString =
                "select bank_agree,name,sname,patronymic,pass_id,pass_series,account from client";

            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(CmdString, con);
            DataTable dt = new DataTable();

            nda.Fill(dt);
            Clients = dt.AsEnumerable().Select(r => new Client
            {
                Agreement = (string)r["bank_agree"],
                Name = (string)r["name"],
                SName = (string)r["sname"],
                Patron = (string)r["patronymic"],
                PassId = (int)r["pass_id"],
                PassSeries = (int)r["pass_series"],
                Account = (string)r["account"],

            }).ToList(); ;
        }
        public void DeleteClient()
        {
            if (CurrentClient != null)
            {
                string query = "delete from client where bank_agree = " + CurrentClient.Agreement;
                com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
                string query1 = "delete from accounts where account = " + CurrentClient.Account;
                com = new NpgsqlCommand(query1, con);
                NpgsqlDataReader reader1 = com.ExecuteReader();
                AllClients();
            }
            else
            {
                MessageBox.Show("Выберите клиента!");
            }
        }
        public void Find()
        {
            string CmdString = string.Empty;
            
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(CmdString, con);
            DataTable dt_1 = new DataTable();
           
        }
    }
}