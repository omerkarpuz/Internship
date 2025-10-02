using Dapper.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2T252BE\\MSSQL2022;initial Catalog=omrstaj_Dapper;integrated security=true");

        private async void btnListele_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Tbl_Product";
            var values=await connection.QueryAsync<ResultProductDto>(query);
            dataGridView1.DataSource = values;

        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Tbl_Product (ProductName, ProductPrice, ProductStock, ProductCategory) VALUES (@ProductName, @ProductPrice, @ProducStock, @ProductCategory)";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", txtProductName.Text);
            parameters.Add("@ProductPrice", Convert.ToDecimal(txtProductPrice.Text));
            parameters.Add("@ProducStock", Convert.ToInt32(txtProductStock.Text));
            parameters.Add("@ProductCategory", txtProductCategory.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Product added successfully.");

            // Clear the input fields after adding the product
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtProductStock.Clear();
            txtProductCategory.Clear();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Tbl_Product WHERE ProductId = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", Convert.ToInt32(txtProductId.Text));
            connection.Execute(query, parameters);
            MessageBox.Show("Product deleted successfully.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Tbl_Product SET ProductName = @ProductName, ProductPrice = @ProductPrice, ProductStock = @ProductStock, ProductCategory = @ProductCategory WHERE ProductId = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", Convert.ToInt32(txtProductId.Text));
            parameters.Add("@ProductName", txtProductName.Text);
            parameters.Add("@ProductPrice", Convert.ToDecimal(txtProductPrice.Text));
            parameters.Add("@ProductStock", Convert.ToInt32(txtProductStock.Text));
            parameters.Add("@ProductCategory", txtProductCategory.Text);
            connection.Execute(query, parameters);
            MessageBox.Show("Product updated successfully.");
            // Clear the input fields after updating the product
            Timer timer = new Timer();
            timer.Interval = 2000; // 2 seconds
            txtProductId.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtProductStock.Clear();
            txtProductCategory.Clear();

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query = "SELECT Count(*) FROM Tbl_Product";
            var productTotalCount=await connection.QueryFirstOrDefaultAsync<int>(query);
            lblTotProdCount.Text = productTotalCount.ToString();
 
            string query2 = "SELECT ProductName from Tbl_Product where ProductPrice=(SELECT Max(ProductPrice) FROM Tbl_Product)";
            var lblMaxProductPrice=await connection.QueryFirstOrDefaultAsync<string>(query2);
            lblExpProd.Text = lblMaxProductPrice.ToString();

            string query3= "select count(distinct(ProductCategory)) from Tbl_Product";
            var distinctProductCat= await connection.QueryFirstOrDefaultAsync<int>(query3);
            lblCategoryCount.Text = distinctProductCat.ToString();
        }
    }
}
