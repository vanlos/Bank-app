using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3
{
    public class Client : DependencyObject
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Client), new PropertyMetadata(string.Empty));

        public string SName
        {
            get { return (string)GetValue(SNameProperty); }
            set { SetValue(SNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SNameProperty =
            DependencyProperty.Register("SName", typeof(string), typeof(Client), new PropertyMetadata(string.Empty));
        public string Patron
        {
            get { return (string)GetValue(PatronProperty); }
            set { SetValue(PatronProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PatronProperty =
            DependencyProperty.Register("Patron", typeof(string), typeof(Client), new PropertyMetadata(string.Empty));
        public int Agreement
        {
            get { return (int)GetValue(AgreementProperty); }
            set { SetValue(AgreementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Agreement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgreementProperty =
            DependencyProperty.Register("Agreement", typeof(int), typeof(Client), new PropertyMetadata(0));
        public int PassId
        {
            get { return (int)GetValue(PassIdProperty); }
            set { SetValue(PassIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PassIdProperty =
            DependencyProperty.Register("PassId", typeof(string), typeof(Client), new PropertyMetadata(string.Empty));
        public int PassSeries
        {
            get { return (int)GetValue(PassSeriesProperty); }
            set { SetValue(PassSeriesProperty, value); }
        }
        public static readonly DependencyProperty PassSeriesProperty =
             DependencyProperty.Register("PassSeries", typeof(string), typeof(Client), new PropertyMetadata(string.Empty));
        public string Account
        {
            get { return (string)GetValue(AccountProperty); }
            set { SetValue(AccountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountProperty =
            DependencyProperty.Register("Account", typeof(string), typeof(Client), new PropertyMetadata(string.Empty));


    }
}
