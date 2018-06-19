using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SopaLetras.Lib;
using SopaLetras.Lib.Interfaces;
using SopaLetras.Lib.Enum;
using SopaLetras.Lib.Entities;


namespace SopaLetrasApp
{
    class Program
    {
        //Aplicacion Consola para probar el algoritmo
        #region       
        static void Main(string[] args)
        {

            /*
            IPalabrasManager palabrasManager = new PalabrasManager();
            char[,] matriz = palabrasManager.CargarMatriz(new string[] { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" });
            palabrasManager.CargarPalabrasABuscar(new string[]{"TELEFE"});

            //TEST 
            foreach (var item in StaticLibManager.oPalabras)
            {
                if(item.Value == EnumTipoPalabra.PalabraCompleta)
                    Console.WriteLine("palabras a buscar:" + item.Key);    
            }

            IBuscadorManager buscadorManager = new BuscadorManager();            
            buscadorManager.GetPosiciones(matriz);

            var resultado = StaticLibManager.oPosiciones;//TEST
            
            string response = ""; 
            foreach (Coordenadas coord in StaticLibManager.oPosiciones)
            {
                    response += string.Format( "{{{0},{1}}},",coord.x,coord.y);
                    
                
                //return builder.ToString().TrimEnd(new char[] { ',' });
            }

            Console.WriteLine("Coordenadas : " + response);
            Console.ReadKey();
            */
        }
             
        #endregion

    }
}