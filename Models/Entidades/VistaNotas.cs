using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaNotas.Models.Entidades
{
    public class VistaNotas
    {
        int _identificador;
        int _idMateria;
        string _nombreProfesor;
        string _apellidosProfesor;
        string _nombreEstudiante;
        string _apellidosEstudiante;
        string _estado;
        float _nota;

        public int Identificador { get => _identificador; set => _identificador = value; }
        public int IdMateria { get => _idMateria; set => _idMateria = value; }
        public string NombreProfesor { get => _nombreProfesor; set => _nombreProfesor = value; }
        public string ApellidosProfesor { get => _apellidosProfesor; set => _apellidosProfesor = value; }
        public string NombreEstudiante { get => _nombreEstudiante; set => _nombreEstudiante = value; }
        public string ApellidosEstudiante { get => _apellidosEstudiante; set => _apellidosEstudiante = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public float Nota { get => _nota; set => _nota = value; }
    }
}