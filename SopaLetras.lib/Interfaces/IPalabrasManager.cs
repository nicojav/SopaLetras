using System;
using SopaLetras.Lib.Enum;
using System.Collections.Generic;

namespace SopaLetras.Lib.Interfaces
{
    public interface IPalabrasManager
    {
       Dictionary<string, EnumTipoPalabra> CargarPalabrasABuscar(string[] palabrasABuscar);
       char[,] CargarMatriz(string[] palabrasInput);
    }
}
