using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.pudgeDataSetTableAdapters;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        productsTableAdapter metahook = new productsTableAdapter();
        order_TableAdapter meathook = new order_TableAdapter();
       

        public MainWindow()
        {
            InitializeComponent();
            Daubi.ItemsSource = meathook.GetData();
            box.ItemsSource = metahook.GetData();
            box.DisplayMemberPath = "Id_products";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            meathook.InsertQuery ((int)(box.SelectedItem as DataRowView).Row[0], Convert.ToInt32(Texbx1.Text), Convert.ToInt32(Texbx2.Text));
            Daubi.ItemsSource = meathook.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();

            
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (Daubi.SelectedItem as DataRowView).Row[0];
                meathook.DeleteQuery(Convert.ToInt32(id));
                Daubi.ItemsSource = meathook.GetData();
            }
            catch {
                MessageBox.Show("ОШИБКА!!!");           
            }

        }
    }
   
}
