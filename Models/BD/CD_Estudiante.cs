using SistemaNotas.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
namespace SistemaNotas.Models.BD
{
    public class CD_Estudiante
    {
<<<<<<< HEAD
        
=======
        //public object IniciarSesion(string correo, string contrasena)
        //{
        //    using (SqlConnection connection = new SqlConnection(Conexion.cn))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            SqlCommand command = new SqlCommand("SistemaNotas.IniciarSesion", connection);
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@correo", correo);
        //            command.Parameters.AddWithValue("@contrasena", contrasena);

        //            SqlDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                reader.Read(); // Assuming there's only one matching record

        //                if (reader.FieldCount > 1) // If more than 1 field, it's a professor
        //                {
        //                    Profesor profesor = new Profesor
        //                    {
        //                        Id = Convert.ToInt32(reader["Id"]),
        //                        Nombre = reader["Nombre"].ToString(),
        //                        // Populate other properties...
        //                    };
        //                    return profesor;
        //                }
        //                else // Otherwise, it's a student
        //                {
        //                    Estudiante estudiante = new Estudiante
        //                    {
        //                        Id = Convert.ToInt32(reader["Id"]),
        //                        Nombre = reader["Nombre"].ToString(),
        //                        // Populate other properties...
        //                    };
        //                    return estudiante;
        //                }
        //            }
        //            else
        //            {
        //                return "0";
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            // Handle exception appropriately
        //            return "Error occurred during login.";
        //        }
        //    }
        //}
>>>>>>> ec40fc0d9538ae3b2374576cd53a8e1916aa526b
    }
}