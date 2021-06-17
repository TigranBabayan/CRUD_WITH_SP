using Microsoft.Data.SqlClient;
using CRUD_WITH_SP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;

namespace CRUD_WITH_SP.Models
{
    public class ProductRepository : IProduct
    {

     
        string connectionString = @"Data Source=DESKTOP-UL1IF6B;Initial Catalog=CrudWithSp;Integrated Security=True";

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product();
                    product.Id = Convert.ToInt32(reader["Id"].ToString());
                    product.ProductName = reader["ProductName"].ToString();
                    product.Manufacturer = reader["Manufacturer"].ToString();
                    product.ProductCount = Convert.ToInt32(reader["ProductCount"].ToString());
                    product.Price = Convert.ToDecimal(reader["Price"].ToString());
                    products.Add(product);
                }
                reader.Close();
                connection.Close();
            }
            return products;

        }

        public Product GetById(int productId)
        {
            var product = new Product();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetProductById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", productId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product.Id = Convert.ToInt32(reader["Id"].ToString());
                    product.ProductName = reader["ProductName"].ToString();
                    product.Manufacturer = reader["Manufacturer"].ToString();
                    product.ProductCount = Convert.ToInt32(reader["ProductCount"].ToString());
                    product.Price = Convert.ToDecimal(reader["Price"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            return product;
        }

        public void Insert(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateNewProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Manufacturer", product.Manufacturer);
                cmd.Parameters.AddWithValue("@ProductCount", product.ProductCount);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }

        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Manufacturer", product.Manufacturer);
                cmd.Parameters.AddWithValue("@ProductCount", product.ProductCount);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
