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

namespace IntroductionToCSharp
{
    /// <summary>
    /// Interaction logic for LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {
        public LandingWindow()
        {
            InitializeComponent();
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            Members addMember = new Members();
            BlankPanel.Children.Clear();
            BlankPanel.Children.Add(addMember);
          


        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            upMemWPF addMember = new upMemWPF();
            BlankPanel.Children.Clear();
            BlankPanel.Children.Add(addMember);
            
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            isDeleteWPF delMember = new isDeleteWPF();
            BlankPanel.Children.Clear();
            BlankPanel.Children.Add(delMember);
        }
    }
}

