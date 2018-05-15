using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PruebaTecnica.Dao
{
    public class ProductoDao
    {

        String connectionString = ConfigurationManager.ConnectionStrings["Colegio"].ConnectionString;
      //  SqlConnection con = new SqlConnection(connectionString);

        //public DataSet Show_data() {
        //    String query = "";
        //    SqlCommand sql = new SqlCommand(query, con);
        //    SqlDataAdapter da = new SqlDataAdapter(sql);
        //    DataSet de = new DataSet();
        //    da.Fill(de);
        //   return de;
        //}

        public void CreateTemporaryOrder(int idCliente, int idProducto) {

            int idPedido = getLatOrder();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into pedido (idPedido, idCliente) values (@idPedido, @idCliente)";
                    command.Parameters.AddWithValue("@idPedido", SqlDbType.Int).Value = idPedido;
                    command.Parameters.AddWithValue("@idCliente", SqlDbType.Int).Value =1;
                    command.ExecuteNonQuery();
                }


                using (SqlCommand command = connection.CreateCommand()) {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into productosxpedido (idPedido, idProducto) values (@idPedido,@idProducto)";
                    command.Parameters.AddWithValue("@idPedido", SqlDbType.Int).Value = idPedido;
                    command.Parameters.AddWithValue("@idProducto", SqlDbType.Int).Value = idProducto;
                    command.ExecuteNonQuery();
                }
            }
        }


        public int getLatOrder() {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select Max(idPedido) from pedido";
                    var lastOrder = cmd.ExecuteScalar();

                    return Convert.ToInt32(lastOrder)+1;
                }
            }
        }


    }
}