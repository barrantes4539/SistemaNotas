using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaNotas.Models.Entidades
{
    public class Materias
    {
        int _idMateria;
        string _nombreMateria;
        public int IdMateria { get => _idMateria; set => _idMateria = value; }
        public string NombreMateria { get => _nombreMateria; set => _nombreMateria = value; }
    }
}