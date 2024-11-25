using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace HollyWay
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string connectionString = "Server=DESKTOP-IUGPTQJ\\SHOP;Database=HollyWay;Trusted_Connection=True;TrustServerCertificate=True";
        internal  MatPlatas MatPlatas= new MatPlatas();
        internal VideoCards VideoCards = new VideoCards();
        public Window1()
        {
            
            InitializeComponent();
        }
        private void AddMatPlat(object sender, RoutedEventArgs e)
        {
            string price = PriceInput.Text;
            string count = CoutInput.Text;
            string currency = (CurrencySelector.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(count) || string.IsNullOrWhiteSpace(currency))
            {
                MessageBox.Show("Please Write in all Currency", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(price, out int pr) || !int.TryParse(count, out int co))
            {
                MessageBox.Show("Write a number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            try
            {
                // Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для вставки данных в таблицу HollyWay
                    string query = "INSERT INTO MatPLatas (FirmaName, Price, Cout) " +
                                   "VALUES (@FirmaName, @Price, @Cout)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Передача параметров в SQL-запрос
                        command.Parameters.AddWithValue("@FirmaName", currency);
                        command.Parameters.AddWithValue("@Price", pr);
                        command.Parameters.AddWithValue("@Cout", co);

                        // Выполнение запроса
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Great! You Added New MatPLat", "Good Job", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearInputs(); // Очистка полей после успешной записи
                        }
                        else
                        {
                            MessageBox.Show("Error something there are not OK", "Please write correct answere", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        MatPlatas.FirmaName = currency;
                        MatPlatas.Price = pr;
                        MatPlatas.Cout = co;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something Wrong: {ex.Message}", "Error" , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputs()
        {
            PriceInput.Text = string.Empty;
            CoutInput.Text = string.Empty;
            CurrencySelector.SelectedIndex = -1;
        }


        private void AddVideoCards(object sender, RoutedEventArgs e)
        {
            string price = PricesInput.Text;
            string count = CoutsInput.Text;
            string currency = (CurrencySelection.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(count) || string.IsNullOrWhiteSpace(currency))
            {
                MessageBox.Show("Please Write in all Currency", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(price, out int pr) || !int.TryParse(count, out int co))
            {
                MessageBox.Show("Write a number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            try
            {
                // Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для вставки данных в таблицу HollyWay
                    string query = "INSERT INTO VideoCards (FirmaName, Price, Cout) " +
                                   "VALUES (@FirmaName, @Price, @Cout)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Передача параметров в SQL-запрос
                        command.Parameters.AddWithValue("@FirmaName", currency);
                        command.Parameters.AddWithValue("@Price", pr);
                        command.Parameters.AddWithValue("@Cout", co);

                        // Выполнение запроса
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Great! You Added New MatPLat", "Good Job", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearInput(); // Очистка полей после успешной записи
                        }
                        else
                        {
                            MessageBox.Show("Error something there are not OK", "Please write correct answere", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something Wrong: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            VideoCards.FirmaName = currency;
            VideoCards.Price = pr;
            VideoCards.Cout = co;
        }

        private void ClearInput()
        {
            PricesInput.Text = string.Empty;
            CoutsInput.Text = string.Empty;
            CurrencySelection.SelectedIndex = -1;
        }



        
    }
}
