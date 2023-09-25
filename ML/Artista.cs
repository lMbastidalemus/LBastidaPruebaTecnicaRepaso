﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Artista
    {
        public int IdArtista { get; set; }
        public string NombreArtistico { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento{ get; set; }
        public List<object> Artistas { get; set; }
    }
}
