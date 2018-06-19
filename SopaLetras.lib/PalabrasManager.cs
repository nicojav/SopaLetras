using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SopaLetras.Lib.Enum;
using SopaLetras.Lib.Interfaces;


namespace SopaLetras.Lib
{
    public class PalabrasManager : IPalabrasManager
    {
        Dictionary<string, EnumTipoPalabra> oPalabras = new Dictionary<string, EnumTipoPalabra>(400000, StringComparer.Ordinal);
        
        
        /// <summary>
        /// Guarda en un Dictionary las palabras a Buscar por el Usuario 
        /// </summary>
        /// <param name="palabrasABuscar"></param>
        /// <returns></returns>
        public Dictionary<string, EnumTipoPalabra> CargarPalabrasABuscar(string[] palabrasABuscar)
        {
            foreach(string palabra in palabrasABuscar){

                for (int i = 1; i <= palabra.Length; i++)
                {
                    string substring = palabra.Substring(0, i);
                    EnumTipoPalabra value;
                    if (oPalabras.TryGetValue(substring, out value))
                    {
                        // Si la palabra es completa
                        if (i == palabra.Length)
                        {
                            // Si solo la palabraParcial se guarda.
                            if (value == EnumTipoPalabra.PalabraParcial)
                            {
                                // Upgrade type.
                                oPalabras[substring] = EnumTipoPalabra.PalabraSemiCompleta;
                            }
                        }
                        else
                        {
                            // Si no es palabra completa y solo se guarda palabraParcial.
                            if (value == EnumTipoPalabra.PalabraCompleta)
                            {
                                oPalabras[substring] = EnumTipoPalabra.PalabraSemiCompleta;
                            }
                        }
                    }
                    else
                    {
                        // Verifico si es palabra completa.
                        if (i == palabra.Length)
                        {
                            oPalabras.Add(substring, EnumTipoPalabra.PalabraCompleta);
                        }
                        else
                        {
                            oPalabras.Add(substring, EnumTipoPalabra.PalabraParcial);
                        }
                    }
                }  


            }

            return oPalabras;

        }

        /// <summary>
        /// Arma la Matriz de coordenadas a partir del input de palabras
        /// </summary>
        /// <param name="palabrasInput"></param>
        /// <returns></returns>
        public char[,] CargarMatriz(string[] palabrasInput)
        {
            int altura = palabrasInput.Length;
            int ancho = palabrasInput[0].Length;
            char[,] matriz = new char[altura, ancho];
            for (int i = 0; i < ancho; i++)
            {
                for (int a = 0; a < altura; a++)
                {
                   matriz[a, i] = palabrasInput[a][i];
                }
            }

            return matriz;
        }






        
    }
}
