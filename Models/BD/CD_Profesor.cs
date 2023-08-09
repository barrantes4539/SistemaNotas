using SistemaNotas.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaNotas.Models.BD
{
    public class CD_Profesor
    {
        public void enlazarProfesorMateria(int idMateria, int idProfesor)
        {
            try
            {
                string spName = "spEnlazarProfesorMateria";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idMateria", idMateria),
                    new SqlParameter("@idProfesor", idProfesor)
                };
                Conexion conexion = new Conexion();
                conexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo guardar en enlace de profesor  la base de datos");
            }
        }

        public static List<Entidades.Estudiante_ProfesorMateria> CargarNotasEstudiante(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConexionBD.cn))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SistemaNotas.VerNotasEstudiantes", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Entidades.Estudiante_ProfesorMateria> notas = new List<Entidades.Estudiante_ProfesorMateria>();

                    while (reader.Read())
                    {
                        Entidades.Estudiante_ProfesorMateria nota = new Entidades.Estudiante_ProfesorMateria
                        {
                            IdEstudianteProfesorMateria = Convert.ToInt32(reader["idEstudianteProfesorMateria"]),
                            //IDMateria = Convert.ToInt32(reader["IdMateria"]),
                            NombreMateria = reader["NombreMateria"].ToString(),
                            NombreEstudiante = reader["NombreEstudiante"].ToString() + " " + reader["ApellidosEstudiante"].ToString(),
                            Estado = reader["Estado"].ToString(),
                            Nota = Convert.ToDouble(reader["Nota"])
                        };

                        notas.Add(nota);
                    }

                    return notas;
                }
                catch (Exception)
                {
                    // Handle exception appropriately
                    throw new Exception("No se pudieron cargar las notas del estudiante.");
                }
            }
        }

        public static void ModificarNotaEstudiante(int idEstudianteProfesorMateria, double notaNueva)
        {
            try
            {
                string spName = "ModificarNota";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idEstudianteProfesorMateria", idEstudianteProfesorMateria),
                    new SqlParameter("@nuevaNota", notaNueva),
                };
                Conexion iConexion = new Conexion();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo modificar la nota del estudiante");
            }
        }

        public static Estudiante_ProfesorMateria ObtenerEstudiantePorId(int idEstudianteProfesorMateria)
        {
            using (SqlConnection connection = new SqlConnection(ConexionBD.cn))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SistemaNotas.ObtenerEstudiantePorId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idEstudianteProfesorMateria", idEstudianteProfesorMateria);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Estudiante_ProfesorMateria estudiante = new Estudiante_ProfesorMateria
                        {
                            IdEstudiante = Convert.ToInt32(reader["idEstudiante"]),
                            Estado = reader["Estado"].ToString(),
                            Nota = Convert.ToInt32(reader["Nota"]),
                            // Otros campos del estudiante
                        };

                        return estudiante;
                    }

                    return null; // En caso de que no se encuentre el estudiante con el ID dado
                }
                catch (Exception)
                {
                    // Handle exception appropriately
                    throw new Exception("No se pudo obtener el estudiante por su ID.");
                }
            }
        }

        public static bool ModificarNotasEstudiante(int idEstudiante, string estado, double nota)
        {
            using (SqlConnection connection = new SqlConnection(ConexionBD.cn))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("sp_modificarNotasEstudiante", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.Parameters.AddWithValue("@Nota", nota);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; // Devuelve true si al menos una fila se modificó
                }
                catch (Exception)
                {
                    // Manejar excepción adecuadamente
                    throw new Exception("No se pudo modificar las notas del estudiante.");
                }
            }
        }


    }
}