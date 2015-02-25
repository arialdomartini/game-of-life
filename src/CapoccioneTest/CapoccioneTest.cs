using System;
using SharpTestsEx;
using Gioco;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Gioco
{
    public class CapoccioneTest
    {
        [Test]
        public void arrenditi_restituisce_la_sequenza_segreta_di_fabbrica()
        {
            var sut = new Capoccione();

            var actual = sut.Arrenditi();

            actual.Should().Be("Game over! La Sequenza Segreta era: RVGGN");
        }

        [Test]
        public void mastro_imposta_la_sequenza_segreta() {
            var sut = new Capoccione();

            sut.ImpostaSequenzaSegreta("RVGGG");
            var actual = sut.Arrenditi();

            actual.Should().Be("Game over! La Sequenza Segreta era: RVGGG");
        }

        [Test]
        public void mastro_non_imposta_sequenza_di_fabbrica() {
            var sut = new Capoccione();
            try {

                sut.ImpostaSequenzaSegreta("RVGGN");
                Assert.Fail();
            }
            catch (ArgumentException) {
  
            }
            catch(Exception)
            {
                Assert.Fail();

            }
  
        }

   
        [TestCase("RVVNV")]
        [TestCase("RGVNG")]
        [TestCase("NNVNV")]
        public void scommessa_azzeccata_quando_le_sequenze_coincidono(string sequenzaSegreta)
        {
            var sut = new Capoccione();
            sut.ImpostaSequenzaSegreta(sequenzaSegreta);

            var actual = sut.Scommetti(sequenzaSegreta);

            actual.Should().Be("Bravone!");
        }

        [TestCase("RVVNV", "NNNNN")]
        [TestCase("RGVNG", "GNVGR")]
        [TestCase("NNVNV", "RRRNN")]
        public void scommessa_azzeccata_quando_le_sequenze_coincidono(string sequenzaSegreta, string tentativo)
        {
            var sut = new Capoccione();
            sut.ImpostaSequenzaSegreta(sequenzaSegreta);

            var actual = sut.Scommetti(tentativo);

            actual.Should().Be("Nada!");
        }

        [Test]
        public void dopo_scommessa_azzeccata_il_gioco_termina()
        {
            var sut = new Capoccione();
            sut.ImpostaSequenzaSegreta("RVVRN");
            sut.Scommetti("RVVRN");

            try {
                sut.Scommetti("NNNNN");

            }
                catch (ApplicationException) {

                }
                catch(Exception)
                {
                    Assert.Fail();

                }

        }

        [Test]
        public void dodici_scommesse_sbagliate_di_fila_terminano_il_gioco()
        {
            var sut = new Capoccione();
            sut.ImpostaSequenzaSegreta("RVVRN");

            for(int i=0; i<11; i++)
            {
                sut.Scommetti("NNNNN");
            }

            var actual = sut.Scommetti("NNNNN");

            actual.Should().Be("Game over");

        }

        [Test]
        public void e_possibile_scommettere_dopo_aver_reimpostato_la_sequenza_segreta()
        {
            var sut = new Capoccione();
            sut.ImpostaSequenzaSegreta("RVVRN");
            sut.Scommetti("NNNNN");

            sut.ImpostaSequenzaSegreta("RVGVV");

            sut.Scommetti("NNNNN");
        }
    }

}

