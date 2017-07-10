using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;

namespace Testiranje.ModelTests
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void PositionNotEqualNull()
        {
            var testPozicija = new Pozicija(0, 0);
            Pozicija nullSeat = null;

            Assert.IsFalse(testPozicija.Equals(nullSeat));
        }
    }
}
