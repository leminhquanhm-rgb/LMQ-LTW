using System.Data;
using Microsoft.Data.SqlClient;

namespace BanHang.Classes
{
    public class DataBaseProcess
    {
        string strConnect =
     "Data Source=.;" +
     "Initial Catalog=BanHang;" +
     "Integrated Security=True;" +
     "TrustServerCertificate=True";

        SqlConnection sqlConnect = null;

        // Hàm mở kết nối
        private void OpenConnect()
        {
            sqlConnect = new SqlConnection(strConnect);

            if (sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }

        // Hàm đóng kết nối
        private void CloseConnect()
        {
            if (sqlConnect != null &&
                sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }

        // Hàm thực thi câu lệnh SELECT
        // trả về một DataTable
        public DataTable DataReader(string sql)
        {
            DataTable dtBang = new DataTable();

            OpenConnect();

            SqlDataAdapter sqldataAdapter =
                new SqlDataAdapter(sql, sqlConnect);

            sqldataAdapter.Fill(dtBang);

            CloseConnect();

            return dtBang;
        }

        // Hàm thực hiện INSERT, UPDATE, DELETE
        public void DataChange(string sql)
        {
            OpenConnect();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandText = sql;

            sqlCommand.ExecuteNonQuery();

            CloseConnect();

            sqlCommand.Dispose();
        }
    }
}