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
            DependencyProperty.Register("Name", typeof(string), typeof(Client), new PropertyMetadata(string.Empty));


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



        #endregion 
        #region CollectionAndObject
        
        #endregion
        #region Commands

        

       

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

          
          
  
        }
       
        public void Find()
        {
            string CmdString = string.Empty;
            
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(CmdString, con);
            DataTable dt_1 = new DataTable();
           
        }
    }
}