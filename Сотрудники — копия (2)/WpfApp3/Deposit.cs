using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3.Model
{
    public class Deposit : DependencyObject
    {
        public string DeposAcc
        {
            get { return (string)GetValue(DeposAccProperty); }
            set { SetValue(DeposAccProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeposAccProperty =
            DependencyProperty.Register("DeposAcc", typeof(string), typeof(Deposit), new PropertyMetadata(string.Empty));

        public int Amount
        {
            get { return (int)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(int), typeof(Deposit), new PropertyMetadata(0));
        public string Currency
        {
            get { return (string)GetValue(CurrencyProperty); }
            set { SetValue(CurrencyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrencyProperty =
            DependencyProperty.Register("Currency", typeof(string), typeof(Deposit), new PropertyMetadata(string.Empty));
        public int Rate
        {
            get { return (int)GetValue(RateProperty); }
            set { SetValue(RateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Agreement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RateProperty =
            DependencyProperty.Register("Rate", typeof(int), typeof(Deposit), new PropertyMetadata(0));
        public DateTime Limit
        {
            get { return (DateTime)GetValue(LimitProperty); }
            set { SetValue(LimitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LimitProperty =
            DependencyProperty.Register("Limitation", typeof(DateTime), typeof(Deposit), new PropertyMetadata(DateTime.Today));
    }
}
