using SistemaNotas.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaNotas.Models.BD
{
    public class CD_Estudiante
    {

        public object IniciarSesion(string correo, string contrasena)
        {
            using (SqlConnection connection = new SqlConnection(ConexionBD.cn))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SistemaNotas.IniciarSesion", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@contrasena", contrasena);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read(); // Assuming there's only one matching record

                        if (reader.FieldCount > 1) // If more than 1 field, it's a professor
                        {
                            Profesores profesor = new Profesores
                            {
                                IdProfesor = Convert.ToInt32(reader["idProfesor"]),
                                Nombre = reader["NombreProfesor"].ToString(),
                                Apellidos = reader["ApellidosProfesor"].ToString(),
                                Correo = reader["CorreoProfesor"].ToString(),
                                Contrasena = reader["ContrasenaProfesor"].ToString(),
                                IdRol = Convert.ToInt32(reader["idRol"]),
                            };
                            return profesor;
                        }
                        else // Otherwise, it's a student
                        {
                            Estudiantes estudiante = new Estudiantes
                            {
                                IdEstudiante = Convert.ToInt32(reader["idEstudiante"]),
                                Nombre = reader["NombreEstudiante"].ToString(),
                                Apellidos = reader["ApellidosEstudiante"].ToString(),
                                Correo = reader["CorreoEstudiante"].ToString(),
                                Contrasena = reader["ContrasenaEstudiante"].ToString(),
                                IdRol = Convert.ToInt32(reader["idRol"]),
                            };
                            return estudiante;
                        }
                    }
                    else
                    {
                        return "0";
                    }
                }
                catch (Exception)
                {
                    // Handle exception appropriately
                    return "Error al iniciar sesion.";
                }
            }
        }

        public static List<Entidades.VistaNotas> CargarNotasEstudiante(int idEstudiante)
        {
            try
            {
                List<Entidades.VistaNotas> Notas = new List<Entidades.VistaNotas>();
                string spName = "VerNotasEstudiante";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idEstudiante", idEstudiante),
                };
                Conexion iConexion = new Conexion();
                DataTable dtNotas = iConexion.ExecuteSPWithDT(spName, null);

                if (dtNotas != null && dtNotas.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtNotas.Rows)
                    {
                        Entidades.VistaNotas a = new Entidades.VistaNotas
                        {
                            Identificador = Convert.ToInt32(fila[0]),
                            IdMateria = Convert.ToInt32(fila[1]),
                            NombreMateria = fila[2].ToString(),
                            NombreProfesor = fila[3].ToString() + " " + fila[4].ToString(),
                            NombreEstudiante = fila[5].ToString() + " " + fila[6].ToString(),
                            Estado = fila[7].ToString(),
                            Nota = Convert.ToDouble(fila[8].ToString())
                        };

                        Notas.Add(a);
                    }
                }
                return Notas;
            }
            catch (Exception)
            {
                throw new Exception("No se pudieron cargar las notas del estudiante");
            }
        }
    }
}