using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace QuanLyQuanNet
{
    public class DataProvider
    {
        // Singleton thread-safe
        private static readonly Lazy<DataProvider> instance = new Lazy<DataProvider>(() => new DataProvider());

        public static DataProvider Instance => instance.Value;

        // Connection string nên đặt vào app.config hoặc file cấu hình riêng
        private readonly string connectionString = @"Data Source=DESKTOP-QVMA3G7\SQLEXPRESS;Initial Catalog=QuanLyQuanNet3;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"; // Đây là chuỗi dùng để biết được các thông tin database để kết nối
        private DataProvider() { }

        /// <summary>
        /// Thực thi câu truy vấn trả về bảng dữ liệu (SELECT)
        /// </summary>

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Nếu có parameters thì add vào command
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ExecuteQuery] Error: {ex.Message}");
                throw;
            }

            return result;
        }


        /// <summary>
        /// Thực thi câu truy vấn không trả kết quả (INSERT, UPDATE, DELETE)
        /// </summary>
        public int ExecNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                

               
            }
            return result;
        }



        /// <summary>
        /// Thực thi câu truy vấn trả về một giá trị duy nhất (vd: COUNT(*), MAX, MIN...)
        /// </summary>
        public object ExecuteScalar(string query)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ExecuteScalar] Error: {ex.Message}");
                throw;
            }
        }

        internal int? ExecuteScalar(string query, object value)
        {
            throw new NotImplementedException();
        }
    }
}
