using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3.Model
{
    public class Card : DependencyObject
    {
        public string CardAcc
        {
            get { return (string)GetValue(CardAccProperty); }
            set { SetValue(CardAccProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardAccProperty =
            DependencyProperty.Register("CardAcc", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));

        public string CardNum
        {
            get { return (string)GetValue(CardNumProperty); }
            set { SetValue(CardNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardNumProperty =
            DependencyProperty.Register("CardNum", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));
        public string SecCode
        {
            get { return (string)GetValue(SecCodeProperty); }
            set { SetValue(SecCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecCodeProperty =
            DependencyProperty.Register("SecCode", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));
        public DateTime CardLimit
        {
            get { return (DateTime)GetValue(CardLimitProperty); }
            set { SetValue(CardLimitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PassSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardLimitProperty =
            DependencyProperty.Register("CardLimitation", typeof(DateTime), typeof(Card), new PropertyMetadata(DateTime.Today));
        public int CardAmount
        {
            get { return (int)GetValue(CardAmountProperty); }
            set { SetValue(CardAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardAmountProperty =
            DependencyProperty.Register("CardAmount", typeof(int), typeof(Card), new PropertyMetadata(0));

        public string AlAcc
        {
            get { return (string)GetValue(AlAccProperty); }
            set { SetValue(AlAccProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patron.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlAccProperty =
            DependencyProperty.Register("AlAcc", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));
    }
}
