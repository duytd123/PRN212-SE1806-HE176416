using System.Windows;
using BusinessObjects;
using Services;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountService iAccountService;

        public LoginWindow()
        {
            InitializeComponent();

            // Initialize the account service
            iAccountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve account details using the provided username
            AccountMember account = iAccountService.GetAccountById(txtUser.Text);

            // Check if account exists and credentials match
            if (account != null && account.MemberPassword.Equals(txtPass.Password) && account.MemberRole == 1)
            {
                // Hide the login window and show the main window
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                // Show an error message if credentials are incorrect
                MessageBox.Show("You do not have permission.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the login window
            this.Close();
        }
    }
}
