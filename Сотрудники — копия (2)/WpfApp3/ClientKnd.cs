using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3.Model
{
    public class OSMdl : DependencyObject
    {
        
        public string NewElement
        {
            get { return (string)GetValue(NewElementProperty); }
            set { SetValue(NewElementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewElementProperty =
            DependencyProperty.Register("NewElement", typeof(string), typeof(OSMdl), new PropertyMetadata(string.Empty));
    }
}