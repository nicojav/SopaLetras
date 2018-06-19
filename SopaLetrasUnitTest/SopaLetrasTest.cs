using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SopaLetrasApp;


namespace SopaLetrasUnitTest
{
    [TestClass]
    public class SopaLetrasTest
    {
        IAppManager app = new AppManager();
        
        [TestMethod]
        public void CalculaCorrectamenteCoordenadasTELEFE()
        {
            var posiciones = app.getPosiciones("TELEFE");
            Assert.AreEqual("{6,0},{6,1},{6,2},{6,3},{6,4},{6,5}", posiciones);
        }

        [TestMethod]
        public void CalculaCorrectamenteCoordenadasVIACOM()
        {
            var posiciones = app.getPosiciones("VIACOM");
            Assert.AreEqual("{0,2},{1,2},{2,2},{3,2},{4,2},{5,2}", posiciones);
        }

        [TestMethod]
        public void CalculaCorrectamenteCoordenadasJAVA()
        {
            var posiciones = app.getPosiciones("JAVA");
            Assert.AreEqual("{1,1},{2,2},{3,3},{4,4}", posiciones);
        }

    }
}
