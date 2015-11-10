using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo {
    /// <summary>
    /// Clase que representa un jugador
    /// </summary>
    public class DatosJugador {
        private string nombre;
        private string fecha;
        private int puntaje;
        private String dificultad;

        /// <summary>
        /// Constructor vacio que sirve para crear el objeto cuando recontruido desde el archivo JSON
        /// </summary>
        public DatosJugador() {

        }

        /// <summary>
        /// Contructor de la clase DatosJugador que recive nombre del jugador y dificultad de juego
        /// </summary>
        /// <param name="nombre">Nombre del jugador</param>
        /// <param name="dificultad">Dificultad de Juego</param>
        public DatosJugador(string nombre, String dificultad) {
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.puntaje = 0;
        }

        /// <summary>
        /// Metodo ToString de la clase DatosJugador
        /// </summary>
        /// <returns>Retorna una representacion en forma de cadena de texto de la clase</returns>
        public override string ToString() {
            return nombre + "   " + dificultad + "  " + puntaje + " " + fecha;
        }

        /// <summary>
        /// Aumenta el puntaje del jugador
        /// </summary>
        /// <param name="puntos">Numero de puntos a aumentar</param>
        /// <returns>Retorna el numero de puntos actual del jugador</returns>
        public int aumentarPuntaje(int puntos) {
            puntaje = puntaje + puntos;
            return puntaje;
        }

        /// <summary>
        /// Accesor y mutador de el atributo Dificultad
        /// </summary>
        public String Dificultad {
            get { return dificultad; }
            set { dificultad = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Fecha
        /// </summary>
        public string Fecha {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Puntaje
        /// </summary>
        public int Puntaje {
            get { return puntaje; }
            set { puntaje = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Nombre
        /// </summary>
        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
