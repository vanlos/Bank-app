﻿using System;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для NewAccount.xaml
    /// </summary>
    public class RandomCreditCardNumberGenerator
    {

        public static String[] AMEX_PREFIX_LIST = new[] { "34", "37" };

        public static String[] DINERS_PREFIX_LIST = new[]
                                                       {
                                                        "300",
                                                        "301", "302", "303", "36", "38"
                                                     };

        public static String[] DISCOVER_PREFIX_LIST = new[] { "6011" };

        public static String[] ENROUTE_PREFIX_LIST = new[]
                                                        {
                                                         "2014",
                                                         "2149"
                                                      };

        public static String[] JCB_15_PREFIX_LIST = new[]
                                                       {
                                                        "2100",
                                                        "1800"
                                                     };

        public static String[] JCB_16_PREFIX_LIST = new[]
                                                       {
                                                        "3088",
                                                        "3096", "3112", "3158", "3337", "3528"
                                                     };

        public static String[] MASTERCARD_PREFIX_LIST = new[]
                                                           {
                                                            "51",
                                                            "52", "53", "54", "55"
                                                         };

        public static String[] VISA_PREFIX_LIST = new[]
                                                     {
                                                      "4539",
                                                      "4556", "4916", "4532", "4929", "40240071", "4485", "4716", "4"
                                                   };

        public static String[] VOYAGER_PREFIX_LIST = new[] { "8699" };

        private static String Strrev(String str)
        {
            if (str == null)
                return "";
            String revstr = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                revstr += str[i];
            }
            return revstr;
        }

        /*
        * 'prefix' is the start of the CC number as a string, any number of digits.
        * 'length' is the length of the CC number to generate. Typically 13 or 16
        */

        private static String completed_number(String prefix, int length)
        {
            String ccnumber = prefix;
            // generate digits
            while (ccnumber.Length < (length - 1))
            {
                double rnd = (new Random().NextDouble() * 1.0f - 0f);
                ccnumber += Math.Floor(rnd * 10);
                Thread.Sleep(20);
            }
            // reverse number and convert to int
            String reversedCCnumberString = Strrev(ccnumber);
            var reversedCCnumberList = new List<int>();
            for (int i = 0; i < reversedCCnumberString.Length; i++)
            {
                reversedCCnumberList.Add(Convert.ToInt32(reversedCCnumberString[i].ToString()));
            }
            // calculate sum
            int sum = 0;
            int pos = 0;
            int[] reversedCCnumber = reversedCCnumberList
               .ToArray();
            while (pos < length - 1)
            {
                int odd = reversedCCnumber[pos] * 2;
                if (odd > 9)
                {
                    odd -= 9;
                }
                sum += odd;
                if (pos != (length - 2))
                {
                    sum += reversedCCnumber[pos + 1];
                }
                pos += 2;
            }
            // calculate check digit
            int checkdigit =
               Convert.ToInt32((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10;
            ccnumber += checkdigit;
            return ccnumber;
        }

        public static String[] credit_card_number(String[] prefixList, int length,
                                                  int howMany)
        {
            var result = new Stack<String>();
            for (int i = 0; i < howMany; i++)
            {
                int next = new Random().Next(0, prefixList.Length - 1);
                String ccnumber = prefixList[next - 1];
                result.Push(completed_number(ccnumber, length));
            }
            return result.ToArray();
        }

        public static String[] generateMasterCardNumbers(int howMany)
        {
            return credit_card_number(MASTERCARD_PREFIX_LIST, 16, howMany);
        }

        public static String generateMasterCardNumber()
        {
            return credit_card_number(MASTERCARD_PREFIX_LIST, 16, 1)[0];
        }

        public static string Reverse(string str)
        {
            // convert the string to char array
            char[] charArray = str.ToCharArray();
            int len = str.Length - 1;
            /*
            now this for is a bit unconventional at first glance because there
            are 2 variables that we're changing values of: i++ and len--.
            the order of them is irrelevant. so basicaly we're going with i from 
            start to end of the array. with len we're shortening the array by one
            each time. this is probably understandable.
            */
            for (int i = 0; i < len; i++, len--)
            {
                /*
                now this is the tricky part people that should know about it don't.
                look at the table below to see what's going on exactly here.
                */
                charArray[i] ^= charArray[len];
                charArray[len] ^= charArray[i];
                charArray[i] ^= charArray[len];
            }
            return new string(charArray);
        }

        public static bool isValidCreditCardNumber(String creditCardNumber)
        {
            bool isValid = false;
            try
            {
                String reversedNumber = Reverse(creditCardNumber);
                int mod10Count = 0;
                for (int i = 0; i < reversedNumber.Length; i++)
                {
                    int augend = Convert.ToInt32(reversedNumber[i]);
                    if (((i + 1) % 2) == 0)
                    {
                        String productString = (augend * 2).ToString();
                        augend = 0;
                        for (int j = 0; j < productString.Length; j++)
                        {
                            augend += Convert.ToInt32(productString[j]);
                        }
                    }
                    mod10Count += augend;
                }
                if ((mod10Count % 10) == 0)
                {
                    isValid = true;
                }
            }
            catch
            {
            }
            return isValid;
        }
    }

public partial class NewAccount : Window
    {
        public NewAccount()
        {
            InitializeComponent();
        }

        
    }
}
