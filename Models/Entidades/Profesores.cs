using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaNotas.Models.Entidades
{
    public class Profesores
    {
        int _idProfesor;
        string _Nombre;
        string _Apellidos;
        string _Correo;
        string _Contrasena;
        int _idRol;

        public int IdProfesor { get => _idProfesor; set => _idProfesor = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
    }
}