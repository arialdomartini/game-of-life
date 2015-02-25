using System;

namespace Gioco
{
    public class Capoccione
    {
        int _numeroDiScommesseSbagliate = 0;

        bool giocoTerminatoConSuccesso = false;
        string _sequenzaSegreta;
        const string SequenzaSegretaDiFabbrica = "RVGGN";

        public Capoccione()
        {
            _sequenzaSegreta = SequenzaSegretaDiFabbrica;
        }

        public String Arrenditi() 
        {
            return String.Format("Game over! La Sequenza Segreta era: {0}", _sequenzaSegreta);
        }

        public string Scommetti(string sequenzaTentativo)
        {
            if (giocoTerminatoConSuccesso)
            {
                throw new ApplicationException();
            }


            if (sequenzaTentativo == _sequenzaSegreta)
            {
                giocoTerminatoConSuccesso = true;
                return "Bravone!";        
            }
                
            _numeroDiScommesseSbagliate++;
            if(_numeroDiScommesseSbagliate == 12)
            {
                return "Game over";
            }
            
            return "Nada!";
        }

        public void ImpostaSequenzaSegreta(string sequenzaSegreta)
        {
            giocoTerminatoConSuccesso = false;
            if(sequenzaSegreta == SequenzaSegretaDiFabbrica)
            {
                throw new ArgumentException();
            }
            _sequenzaSegreta = sequenzaSegreta;
        }
    }
}
