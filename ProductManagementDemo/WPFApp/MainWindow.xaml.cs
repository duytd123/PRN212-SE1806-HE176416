using BusinessObjects;
using Services;
using System.Windows;
using System.Windows.Automation.Text;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService iProductService;
        private readonly ICatergoryService iCategoryService;

        public MainWindow()
        {
            InitializeComponent();
            iProductService = new ProductService();
            iCategoryService = new CategoryService();
        }

        public void LoadCategoryList()
        {
            try
            {
                var catList = iCategoryService.GetCategories();
                cboCategory.ItemsSource = catList;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error on load list of categories");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        public void LoadProductList()
        {
            try
            {
                var productList = iProductService.GetProducts();
                dgData.ItemsSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error on load list of categories");
            }
            finally
            {
                resetInput();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtUnitsInStock.Text) ||
                    cboCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Parse input values
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Invalid Price.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!short.TryParse(txtUnitsInStock.Text, out short unitsInStock))
                {
                    MessageBox.Show("Invalid Units in Stock.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!int.TryParse(cboCategory.SelectedValue.ToString(), out int categoryId))
                {
                    MessageBox.Show("Invalid Category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Create new product without specifying ProductId
                Product product = new Product
                {
                    ProductName = txtProductName.Text,
                    UnitPrice = price,
                    UnitsInStock = unitsInStock,
                    CategoryId = categoryId
                };

                // Save the product
                iProductService.SaveProduct(product);

                // Reload the product list
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender is DataGrid dataGrid)
                {
                    if (dataGrid.SelectedIndex >= 0)
                    {
                        DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                        if (row != null)
                        {
                            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                            if (RowColumn != null)
                            {
                                string idText = ((TextBlock)RowColumn.Content).Text;
                                if (int.TryParse(idText, out int id))
                                {
                                    Product product = iProductService.GetProductById(id);
                                    if (product != null)
                                    {
                                        txtProductID.Text = product.ProductId.ToString();
                                        txtProductName.Text = product.ProductName;
                                        txtPrice.Text = product.UnitPrice.ToString();
                                        txtUnitsInStock.Text = product.UnitsInStock.ToString();                                    
                                        cboCategory.SelectedValue = product.CategoryId;
                                    }
                                    else
                                    {

                                        MessageBox.Show($"Product with ID {id} not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {

                                    MessageBox.Show($"Invalid product ID: {idText}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {

                                MessageBox.Show("Could not retrieve the cell content.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {

                            MessageBox.Show("Could not retrieve the selected row.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    // Ensure all necessary fields are filled out
                    if (string.IsNullOrEmpty(txtProductName.Text) ||
                        string.IsNullOrEmpty(txtPrice.Text) ||
                        string.IsNullOrEmpty(txtUnitsInStock.Text) ||
                        cboCategory.SelectedValue == null)
                    {
                        MessageBox.Show("Please fill in all fields and select a category.");
                        return;
                    }

                    // Create and populate the product object
                    Product product = new Product
                    {
                        ProductId = Int32.Parse(txtProductID.Text),
                        ProductName = txtProductName.Text,
                        UnitPrice = Decimal.Parse(txtPrice.Text),
                        UnitsInStock = short.Parse(txtUnitsInStock.Text),
                        CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                    };

                    // Update the product
                    iProductService.UpdateProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a Product!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values for Product ID, Price, Units in Stock, and Category.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductId = Int32.Parse(txtProductID.Text);
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                    iProductService.DeleteProduct(product);
                }
                else
                {
                    MessageBox.Show("you must select a Product !");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void resetInput()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedValue = 0;
        }
    }
}

