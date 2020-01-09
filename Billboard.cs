using System;
using System.Collections.Generic;
using System.Linq;

namespace TombolaGame_Project {
    public class Billboard {
        private readonly Dictionary<int, bool> _billboard;

        private readonly List<Card> _cards; /*fai una lista con le cartelle
                                                genera casualmente i numeri per le singole cartelle
                                                facendo attenzione che non si ripetano poi gestisci 
                                                le cartelle dalla classe Billboard dato che nella 
                                                tombola senza il tabellone non possono esistere 
                                                le cartelle*/


        public int cardNum = -1;

        private readonly List<int> _extractedNums;
        private readonly Random _rnd;
        
        
        
        public Billboard(int numCards) {
            cardNum = numCards;
            _rnd = new Random();
            _extractedNums = new List<int>(90);

            _billboard = new Dictionary<int, bool>(90);
            for (var i = 1; i <= 90; i++) _billboard.Add(i, true);

            _cards = new List<Card>(numCards);
            var cardNums = new List<int>(15);

            for (var i = 0; i < numCards; i++) {
                for (var j = 0; j < 15; j++) cardNums.Add(GenerateNumber());     //genero i numeri che poi andranno ad 
                                                                                 //essere inseriti nella cartella
                _cards.Add(new Card(cardNums));                                  //creo la cartella inserendoci i numeri
                cardNums.Clear();                                                //svuoto la lista con i numeri 
            }    

            _extractedNums.Clear();
        }

       


        public List<int> GetExtractedNums() {
            return _extractedNums;
        }

        //genera numero casuali non ripetuti.
        //Si appoggia ad una lista che poi verrà utilizzata quindi questo metodo non puo essere usato se non nel costruttore
        private int GenerateNumber() {
            while (true) {
                var num = _rnd.Next(1, 91);
                if (_extractedNums.Contains(num)) continue;
                _extractedNums.Add(num);
                return num;
            }
        }

        //Estrae un numero casuale tra 1 e 90 e che non sia già stato estratto
        //Se tutti i numeri sono già stati estratti restituisce -1
        public int Extract() {
            if (IsCompleted()) return -1;
            while (true) {
                var extractedNum = _rnd.Next(1, 91);
                if (!_billboard[extractedNum]) continue;
                _billboard[extractedNum] = false;
                _extractedNums.Add(extractedNum);
                return extractedNum;
            }
        }

        //Restituisce true se tutti i numeri sono estratti e false in caso contrario
        public bool IsCompleted() {
            return _billboard.All(x => x.Value != true);
        }

        //Stampa tutte le estrazioni fin'ora effettuate
        public void PrintExtractions() {
            foreach (var k in _billboard.Where(k => !k.Value)) Console.Write(k.Key + " - ");
        }

        //Crea una stringa con i numeri del tabellone estratti o degli asterischi per i numero non estratti
        //formattata come un vero tabellone
        public override string ToString() {
            var billBoardToPrint = "";

            for (var i = 0; i < 9; i++) {
                for (var j = 1; j <= 10; j++)
                    if (!_billboard[i * 10 + j]) {
                        if (i * 10 + j < 10) billBoardToPrint += '0';
                        billBoardToPrint += $"{i * 10 + j} - ";
                    }
                    else {
                        billBoardToPrint += "* - ";
                    }

                billBoardToPrint += "\n";
            }

            return billBoardToPrint;
        }
    }
}