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
                            //IdEstudianteProfesorMateria = Convert.ToInt32(reader["IdEstudianteProfesorMateria"]),
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

    }
}