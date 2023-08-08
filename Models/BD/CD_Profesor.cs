using System;
using System.Collections.Generic;
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
        //public List<Entidades.VistaNotas> CargarNotasEstudiantes()
        //{ 
            
        //}
        
    }
}