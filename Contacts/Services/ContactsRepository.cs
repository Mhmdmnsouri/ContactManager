using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Contacts.Services
{
    internal class ContactsRepository : IContactsRepository
    {
        private string connection = "Data Source = .; Initial Catalog = Contact_DB; Integrated Security = true";

        public bool Delete(int contactId)
        {
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                string query = "Delete From Contacts where contactId = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", contactId);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                conn.Close();

            }
        }

        public bool Insert(string Name, string Family, int Age, string Mobile, string Email, string Address)
        {
            SqlConnection conn = new SqlConnection(connection);
            try
            {

                string query = "Insert Into Contacts (Name, Family, Age, Mobile, Email, Address) values (@Name ,@Family ,@Age ,@Mobile ,@Email ,@Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Family", Family);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Address", Address);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable Search(string parameter)
        {
            string query = "Select * From Contacts Where Name like @parameter or Family like @parameter";
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");

            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From Contacts";
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int contactid)
        {
            string query = "Select * From Contacts where contactId =" + contactid;
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactId, string Name, string Family, int Age, string Mobile, string Email, string Address)
        {
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                string query = "Update Contacts Set Name=@Name,Family=@Family,Age=@Age,Mobile=@Mobile,Email=@Email,Address=@Address Where contactId=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", contactId);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Family", Family);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Address", Address);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

                conn.Close();
            }

        }
    }
}
