using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserLogGenerator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void buttonGenerateKey_Click(object sender, RoutedEventArgs e)
        {
            if (textUsername.Text.ToString().Equals(""))
            {
                MessageBox.Show("Username not defined");
                return;
            }
            if (textPassword.Text.ToString().Equals(""))
            {
                MessageBox.Show("Password not defined");
                return;
            }
            if (textKey.Text.ToString().Equals(""))
            {
                MessageBox.Show("Key not defined");
                return;
            }
            string stringToCrypted = textUsername.Text.ToString() + ":" + textPassword.Text.ToString();
            string text = textKey.Text.ToString();
            var RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
            RSA.FromXmlString(text);

            byte[] machainechiffre = RSA.Encrypt(Encoding.Unicode.GetBytes(stringToCrypted), false);
            System.IO.File.WriteAllBytes(@"logNewUser.info", machainechiffre);
            MessageBox.Show("logNewUser.info généré");
        }
    }
}
