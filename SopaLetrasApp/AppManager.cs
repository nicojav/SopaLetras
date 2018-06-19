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
    public class AppManager : IAppManager
    {
        private char[,] matriz;
        private IPalabrasManager palabrasManager = new PalabrasManager();
        private Dictionary<string, EnumTipoPalabra> oPalabras = new Dictionary<string, EnumTipoPalabra>(400000, StringComparer.Ordinal);
        private List<Coordenadas> oPosiciones = new List<Coordenadas>();
        private IBuscadorManager buscadorManager;     

        public string getPosiciones(string palabra)
        {
            InicializarMatriz();
            oPalabras = palabrasManager.CargarPalabrasABuscar(new string[] { palabra });
            buscadorManager = new BuscadorManager(oPalabras);
            oPosiciones = buscadorManager.GetPosiciones(matriz);

            return ConstruirResponse(); 
        }
        
        private void InicializarMatriz()
        {
            matriz = palabrasManager.CargarMatriz(new string[] { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" });
        
        }


        private string ConstruirResponse()
        {
            string response = "";

            //Armo el response con las coordenadas encontradas
            foreach (Coordenadas coord in oPosiciones)
            {
                response += string.Format("{{{0},{1}}},", coord.x, coord.y);
            }

            return response.Remove(response.Length-1);
        }
            
    }
}
