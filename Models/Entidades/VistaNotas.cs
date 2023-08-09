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
        string _nombreMateria;
        string _nombreProfesor;        
        string _nombreEstudiante;        
        string _estado;
        double _nota;

        public int Identificador { get => _identificador; set => _identificador = value; }
        public int IdMateria { get => _idMateria; set => _idMateria = value; }
        public string NombreProfesor { get => _nombreProfesor; set => _nombreProfesor = value; }      
        public string NombreEstudiante { get => _nombreEstudiante; set => _nombreEstudiante = value; }      
        public string Estado { get => _estado; set => _estado = value; }
        public double Nota { get => _nota; set => _nota = value; }
        public string NombreMateria { get => _nombreMateria; set => _nombreMateria = value; }
    }
}