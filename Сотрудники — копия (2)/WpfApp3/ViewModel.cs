﻿using System;
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
        public int Agreement
        {
            get { return (int)GetValue(AgreementProperty); }
            set { SetValue(AgreementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Agreement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgreementProperty =
            DependencyProperty.Register("Agreement", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
        public string PassId
        {
            get { return (string)GetValue(PassIdProperty); }
            set { SetValue(PassIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PassIdProperty =
            DependencyProperty.Register("PassId", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));
        public string PassSeries
        {
            get { return (string)GetValue(PassSeriesProperty); }
            set { SetValue(PassSeriesProperty, value); }
        }
        public static readonly DependencyProperty PassSeriesProperty =
             DependencyProperty.Register("PassSeries", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));
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
        #region ForDeposit
        public string DeposAcc
        {
            get { return (string)GetValue(DeposAccProperty); }
            set { SetValue(DeposAccProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeposAccProperty =
            DependencyProperty.Register("DeposAcc", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));

        public int Amount
        {
            get { return (int)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
        public string Currency
        {
            get { return (string)GetValue(CurrencyProperty); }
            set { SetValue(CurrencyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrencyProperty =
            DependencyProperty.Register("Currency", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));
        public int Rate
        {
            get { return (int)GetValue(RateProperty); }
            set { SetValue(RateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Agreement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RateProperty =
            DependencyProperty.Register("Rate", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
        public DateTime Limit
        {
            get { return (DateTime)GetValue(LimitProperty); }
            set { SetValue(LimitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LimitProperty =
            DependencyProperty.Register("Limitation", typeof(DateTime), typeof(ViewModel), new PropertyMetadata(DateTime.Today));
        #endregion
        #region ForCard
        public string CardAcc
        {
            get { return (string)GetValue(CardAccProperty); }
            set { SetValue(CardAccProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardAccProperty =
            DependencyProperty.Register("CardAcc", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));

        public int CardAmount
        {
            get { return (int)GetValue(CardAmountProperty); }
            set { SetValue(CardAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardAmountProperty =
            DependencyProperty.Register("CardAmount", typeof(int), typeof(ViewModel), new PropertyMetadata(0));
        public string CardNum
        {
            get { return (string)GetValue(CardNumProperty); }
            set { SetValue(CardNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardNumProperty =
            DependencyProperty.Register("CardNum", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));

             public string SecCode
        {
            get { return (string)GetValue(SecCodeProperty); }
            set { SetValue(SecCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecCodeProperty =
            DependencyProperty.Register("SecCode", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));

        public string AlAcc
        {
            get { return (string)GetValue(AlAccProperty); }
            set { SetValue(AlAccProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlAccProperty =
            DependencyProperty.Register("AlAcc", typeof(string), typeof(ViewModel), new PropertyMetadata(string.Empty));
        public DateTime CardLimit
        {
            get { return (DateTime)GetValue(CardLimitProperty); }
            set { SetValue(CardLimitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardLimitProperty =
            DependencyProperty.Register("CardLimitation", typeof(DateTime), typeof(ViewModel), new PropertyMetadata(DateTime.Today));
        #endregion
        #region ForFind

        public string FindAcc
        {
            get { return (string)GetValue(FindAccProperty); }
            set { SetValue(FindAccProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FindPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FindAccProperty =
            DependencyProperty.Register("FindAcc", typeof(string), typeof(ViewModel),
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

        public List<Deposit> Deposits
        {
            get { return (List<Deposit>)GetValue(DepositsProperty); }
            set { SetValue(DepositsProperty, value); }
        }

        public static readonly DependencyProperty DepositsProperty =
           DependencyProperty.Register("Deposits", typeof(List<Deposit>), typeof(ViewModel), new PropertyMetadata(null));
        public Deposit CurrentDeposit
        {
            get { return (Deposit)GetValue(CurrentDepositProperty); }
            set { SetValue(CurrentDepositProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentDepositProperty =
            DependencyProperty.Register("CurrentDeposit", typeof(Deposit), typeof(ViewModel), new PropertyMetadata(null));

        public List<Card> Cards
        {
            get { return (List<Card>)GetValue(CardsProperty); }
            set { SetValue(CardsProperty, value); }
        }

        public static readonly DependencyProperty CardsProperty =
           DependencyProperty.Register("Cards", typeof(List<Card>), typeof(ViewModel), new PropertyMetadata(null));
        public Card CurrentCard
        {
            get { return (Card)GetValue(CurrentCardProperty); }
            set { SetValue(CurrentCardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentCardProperty =
            DependencyProperty.Register("CurrentCard", typeof(Card), typeof(ViewModel), new PropertyMetadata(null));


        public Client CurrentClient
        {
            get { return (Client)GetValue(CurrentClientProperty); }
            set { SetValue(CurrentClientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentClientProperty =
            DependencyProperty.Register("CurrentClient", typeof(Client), typeof(ViewModel), new PropertyMetadata(null));
        public Client CurrentClient1
        {
            get { return (Client)GetValue(CurrentClient1Property); }
            set { SetValue(CurrentClient1Property, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentClient1Property =
            DependencyProperty.Register("CurrentClient1", typeof(Client), typeof(ViewModel), new PropertyMetadata(null));

        public Client CurrentClient2
        {
            get { return (Client)GetValue(CurrentClient2Property); }
            set { SetValue(CurrentClient2Property, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentClient2Property =
            DependencyProperty.Register("CurrentClient2", typeof(Client), typeof(ViewModel), new PropertyMetadata(null));

        public List<string> AccountCollection
        {
            get { return (List<string>)GetValue(AccountCollectionProperty); }
            set { SetValue(AccountCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountCollectionProperty =
            DependencyProperty.Register("AccountCollection", typeof(List<string>), typeof(ViewModel), new PropertyMetadata(null));



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

        public DelegateCommand DeleteDepositCommand
        {
            get { return (DelegateCommand)GetValue(DeleteDepositCommandProperty); }
            set { SetValue(DeleteDepositCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteDepositCommandProperty =
            DependencyProperty.Register("DeleteDepositCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

        public DelegateCommand AddAccCommand
        {
            get { return (DelegateCommand)GetValue(AddAccProperty); }
            set { SetValue(AddAccProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddAccProperty =
            DependencyProperty.Register("AddAcc", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

        public DelegateCommand AddDepositCommand
        {
            get { return (DelegateCommand)GetValue(AddDepositCommandProperty); }
            set { SetValue(AddDepositCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddDepositCommandProperty =
            DependencyProperty.Register("AddDepositCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

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
        public DelegateCommand TransactCommand
        {
            get { return (DelegateCommand)GetValue(TransactCommandProperty); }
            set { SetValue(TransactCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddClientCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TransactCommandProperty =
            DependencyProperty.Register("TransactCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));



        #endregion
        public ViewModel()
        {
            #region Command
            AddClientCommand = new DelegateCommand(AddClient, () => true);
            PayCommand = new DelegateCommand(Pay, () => true);
            DeleteClientCommand = new DelegateCommand(DeleteClient, () => true);
            AddAccCommand = new DelegateCommand(AddAccount, () => true);
            TransactCommand = new DelegateCommand(Transaction, () => true);
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
            CurrentClient1 = new Client();
            CurrentClient2 = new Client();
            Deposits = new List<Deposit>();
            CurrentDeposit = new Deposit();
            Cards = new List<Card>();
            CurrentCard = new Card();
            AccountCollection = new List<string>();
            AllClients();
            AllAccounts();
            AllCards();
            AllDeposits();
        }

        public void Transaction()
        {
            TransWindow t = new TransWindow();
            t.Show();
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

        public void AllAccounts()
        {
            string accountcmd = "select account from client";
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(accountcmd, con);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            AccountCollection = dt.AsEnumerable().Select(r =>  Account = (string)r["account"]).ToList();

            
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
                Agreement = (int)r["bank_agree"],
                Name = (string)r["name"],
                SName = (string)r["sname"],
                Patron = (string)r["patronymic"],
                PassId = (string)r["pass_id"],
                PassSeries = (string)r["pass_series"],
                Account = (string)r["account"],
            }).ToList(); ;
        }

        public void AllDeposits()
        {
            string CmdString =
                "select depos_account, amount, currency, rate, limitation from deposit";

            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(CmdString, con);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            Deposits = dt.AsEnumerable().Select(r => new Deposit
            {
                DeposAcc = (string)r["depos_account"],
                Amount = (int)r["amount"],
                Currency = (string)r["currency"],
                Rate = (int)r["rate"],
                Limit = (DateTime)r["limitation"],
            }).ToList(); ;
        }

        public void AllCards()
        {
            string CmdString =
                "select card_account, card_num, sec_code, limitation, amount from card";

            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(CmdString, con);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            Cards = dt.AsEnumerable().Select(r => new Card
            {
                CardAcc = (string)r["card_account"],
                CardNum = (string)r["card_num"],
                SecCode = (string)r["sec_code"],
                CardAmount = (int)r["amount"],
                CardLimit = (DateTime)r["limitation"],
            }).ToList(); ;
        }
        public void DeleteClient()
        {
            if (CurrentClient != null)
            {   
                string query = "delete from client where bank_agree = " + CurrentClient.Agreement;
                com = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = com.ExecuteReader();
                reader.Close();
                AllClients();
            }
            else
            {
                MessageBox.Show("Выберите клиента!");
            }
        }
        

    }
}