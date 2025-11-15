using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_objetos
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int AnioPublicacion { get; set; }

        public Libro(string titulo, string autor, string editorial, int anioPublicacion)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            AnioPublicacion = anioPublicacion;
        }

        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Editorial: {Editorial}, Año: {AnioPublicacion}";
        }
    }
}
