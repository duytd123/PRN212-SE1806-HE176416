using ManageHotel.Data;
using ManageHotel.Service;
using Microsoft.Extensions.Configuration;
using WPFApp.Model;
using WPFApp.Repository;
using WPFApp.View;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly LoginService _loginService;

        public Login()
        {
            InitializeComponent();

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configurationBuilder.Build();

            var customerContext = new DAOContext();
            var customerRepo = new CustomerRepository(customerContext);
            _loginService = new LoginService(configuration, customerRepo);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = Mail.Text;
            string password = Password.Password; 

            string role = _loginService.Authenticate(email, password);
            if (role == "Admin")
            {
                MessageBox.Show("Welcome Admin!");
                Admin adminWindow = new();
                adminWindow.Show();
                this.Close();
            }
            else if (role == "Customer")
            {
                Customer cus = _loginService.GetCustomerByEmailAndPassword(email, password);
                CustomerWindow customer = new CustomerWindow(cus);
                customer.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email or password incorrect!");
            }
        }
    }
}
