using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SopaLetras.Lib;
using SopaLetras.Lib.Entities;
using SopaLetras.Lib.Enum;

namespace SopaLetras.Lib
{
    public class BuscadorManager : IBuscadorManager
    {
        private Dictionary<string, char[,]> oLetrasEncontradas = new Dictionary<string, char[,]>(StringComparer.Ordinal);
        private List<Coordenadas> oPosiciones = new List<Coordenadas>();
        private Dictionary<string, EnumTipoPalabra> _oPalabras;

        public BuscadorManager(Dictionary<string, EnumTipoPalabra> oPalabras)
        {
            _oPalabras = oPalabras;
        }


        public List<Coordenadas> GetPosiciones(char[,] matriz)
        {
            int _altura = matriz.GetLength(0);
            int _ancho = matriz.GetLength(1);

            // Empieza por cada cuadro del 2D array.
            for (int i = 0; i < _ancho; i++)
            {
                for (int a = 0; a < _altura; a++)
                {
                    // Busca en todas las direcciones.
                    for (int d = 0; d < 8; d++)
                    {
                        GetPosicionesEnMatriz(matriz, i, a, _ancho, _altura, "", d);
                    }
                }
            }

            return oPosiciones;
        }


        private void GetPosicionesEnMatriz(char[,] array,
        int i,
        int a,
        int ancho,
        int altura,
        string build,
        int direction)
        {
            // Para evitar salirse de la matriz
            if (i >= ancho ||
                i < 0 ||
                a >= altura ||
                a < 0)
            {
                return;
            }
            // Get letra.
            char letra = array[a, i];
            // Append.
            string pass = build + letra;
            // Para ver si es una palabra completa.
            EnumTipoPalabra value;
            
            if (_oPalabras.TryGetValue(pass, out value))
            {
                // Se encarga de todas las palabras completas
                if (value == EnumTipoPalabra.PalabraCompleta ||
                    value == EnumTipoPalabra.PalabraSemiCompleta)
                {
                    // No mostrar la misma palabra una vez encontrada.
                    if (!oLetrasEncontradas.ContainsKey(pass))
                    {
                        oLetrasEncontradas.Add(pass, array);
                        oPosiciones.Add(new Coordenadas { x = a, y = i, letra = letra });
                        return;
                    }

                   
                }
                // Se encarga de todas las palabras parciales.
                if (value == EnumTipoPalabra.PalabraParcial ||
                    value == EnumTipoPalabra.PalabraSemiCompleta)
                {

                    if (!oPosiciones.Exists(element => element.x == a && element.y == i) &&
                            !oLetrasEncontradas.ContainsKey(pass))
                    {
                        oLetrasEncontradas.Add(pass, array);
                        oPosiciones.Add(new Coordenadas { x = a, y = i, letra = letra });
                    }
                    // Continua con una direccion.
                    switch (direction)
                    {
                        case 0:
                            GetPosicionesEnMatriz(array, i + 1, a, ancho, altura, pass, direction);
                            break;
                        case 1:
                            GetPosicionesEnMatriz(array, i, a + 1, ancho, altura, pass, direction);
                            break;
                        case 2:
                            GetPosicionesEnMatriz(array, i + 1, a + 1, ancho, altura, pass, direction);
                            break;
                        case 3:
                            GetPosicionesEnMatriz(array, i - 1, a, ancho, altura, pass, direction);
                            break;
                        case 4:
                            GetPosicionesEnMatriz(array, i, a - 1, ancho, altura, pass, direction);
                            break;
                        case 5:
                            GetPosicionesEnMatriz(array, i - 1, a - 1, ancho, altura, pass, direction);
                            break;
                        case 6:
                            GetPosicionesEnMatriz(array, i - 1, a + 1, ancho, altura, pass, direction);
                            break;
                        case 7:
                            GetPosicionesEnMatriz(array, i + 1, a - 1, ancho, altura, pass, direction);
                            break;
                    }
                }
            }
        }




    }
}
