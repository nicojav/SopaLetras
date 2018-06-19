using System;
using SopaLetras.Lib.Enum;
using SopaLetras.Lib.Entities;
using System.Collections.Generic;

namespace SopaLetras.Lib
{
    public interface IBuscadorManager
    {
        List<Coordenadas> GetPosiciones(char[,] matriz);
    }
}
