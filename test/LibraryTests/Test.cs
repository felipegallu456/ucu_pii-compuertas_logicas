using NUnit.Framework;
using Ucu.Poo.Exercise;

namespace LibraryTests
{
    public class Tests
    {
        
        // not
        
        [Test]
        public void TestNotTrueEsFalse()
        {
            Valor v = new Valor(true);
            Compuerta compuertaNot = new Compuerta("NOT", v);

            Assert.That(compuertaNot.evaluar(), Is.False);
        }

        [Test]
        public void TestNotFalseEsTrue()
        {
            Valor v = new Valor(false);
            Compuerta compuertaNot = new Compuerta("NOT", v);

            Assert.That(compuertaNot.evaluar(), Is.True);
        }

        
        // and
        
        [Test]
        public void TestAndTrueTrueEsTrue()
        {
            Valor v1 = new Valor(true);
            Valor v2 = new Valor(true);
            Compuerta compuertaAnd = new Compuerta("AND", v1, v2);

            Assert.That(compuertaAnd.evaluar(), Is.True);
        }

        [Test]
        public void TestAndTrueFalseEsFalse()
        {
            Valor v1 = new Valor(true);
            Valor v2 = new Valor(false);
            Compuerta compuertaAnd = new Compuerta("AND", v1, v2);

            Assert.That(compuertaAnd.evaluar(), Is.False);
        }

        [Test]
        public void TestAndFalseTrueEsFalse()
        {
            Valor v1 = new Valor(false);
            Valor v2 = new Valor(true);
            Compuerta compuertaAnd = new Compuerta("AND", v1, v2);

            Assert.That(compuertaAnd.evaluar(), Is.False);
        }

        [Test]
        public void TestAndFalseFalseEsFalse()
        {
            Valor v1 = new Valor(false);
            Valor v2 = new Valor(false);
            Compuerta compuertaAnd = new Compuerta("AND", v1, v2);

            Assert.That(compuertaAnd.evaluar(), Is.False);
        }

        
        // OR
        
        [Test]
        public void TestOrTrueTrueEsTrue()
        {
            Valor v1 = new Valor(true);
            Valor v2 = new Valor(true);
            Compuerta compuertaOr = new Compuerta("OR", v1, v2);

            Assert.That(compuertaOr.evaluar(), Is.True);
        }

        [Test]
        public void TestOrTrueFalseEsTrue()
        {
            Valor v1 = new Valor(true);
            Valor v2 = new Valor(false);
            Compuerta compuertaOr = new Compuerta("OR", v1, v2);

            Assert.That(compuertaOr.evaluar(), Is.True);
        }

        [Test]
        public void TestOrFalseTrueEsTrue()
        {
            Valor v1 = new Valor(false);
            Valor v2 = new Valor(true);
            Compuerta compuertaOr = new Compuerta("OR", v1, v2);

            Assert.That(compuertaOr.evaluar(), Is.True);
        }

        [Test]
        public void TestOrFalseFalseEsFalse()
        {
            Valor v1 = new Valor(false);
            Valor v2 = new Valor(false);
            Compuerta compuertaOr = new Compuerta("OR", v1, v2);

            Assert.That(compuertaOr.evaluar(), Is.False);
        }
    }
}