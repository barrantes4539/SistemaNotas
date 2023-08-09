using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaNotas.Models.Entidades
{
    public class Estudiante_ProfesorMateria
    {
        int _idEstudianteProfesorMateria;
        int _iProfesorMateria;
        int _idEstudiante;
        string _estado;
        double _nota;

        public int IdEstudianteProfesorMateria { get => _idEstudianteProfesorMateria; set => _idEstudianteProfesorMateria = value; }
        public int IProfesorMateria { get => _iProfesorMateria; set => _iProfesorMateria = value; }
        public int IdEstudiante { get => _idEstudiante; set => _idEstudiante = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public double Nota { get => _nota; set => _nota = value; }
    }
}