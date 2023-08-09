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
        public static List<Entidades.VistaNotas> CargarNotasEstudiantes()
        {
            try
            {
                List<Entidades.VistaNotas> Notas = new List<Entidades.VistaNotas>();
                string spName = "VerNotasEstudiantes";

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
                throw new Exception("No se pudo cargar las notas de los estudiantes");
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