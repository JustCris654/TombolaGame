using System;
using System.Collections.Generic;
using System.Linq;

namespace TombolaGame_Project {
    public class Billboard {
        private readonly Dictionary<int, bool> billboard;

        private readonly List<Card> cards; /*fai una lista con le cartelle
                                                genera casualmente i numeri per le singole cartelle
                                                facendo attenzione che non si ripetano poi gestisci 
                                                le cartelle dalla classe Billboard dato che nella 
                                                tombola senza il tabellone non possono esistere 
                                                le cartelle*/

        private readonly List<int> extractedNums;
        private readonly Random rnd;

        public Billboard(int numCards) {
            rnd = new Random();
            extractedNums = new List<int>(90);

            billboard = new Dictionary<int, bool>(90);
            for (var i = 1; i <= 90; i++) billboard.Add(i, true);

            cards = new List<Card>(numCards);
            var cardNums = new List<int>(15);

            for (var i = 0; i < numCards; i++) {
                for (var j = 0; j < 15; j++) cardNums.Add(GenerateNumber());

                cards.Add(new Card(cardNums));
            }

            extractedNums.Clear();
        }


        public List<int> GetExtractedNums() {
            return extractedNums;
        }

        //genera numero casuali non ripetuti.
        //Si appoggia ad una lista che poi verrà utilizzata quindi questo metodo non puo essere usato se non nel costruttore
        private int GenerateNumber() {
            while (true) {
                var num = rnd.Next(1, 91);
                if (!extractedNums.Contains(num)) {
                    extractedNums.Add(num);
                    return num;
                }
            }
        }

        //Estrae un numero casuale tra 1 e 90 e che non sia già stato estratto
        //Se tutti i numeri sono già stati estratti restituisce -1
        public int Extract() {
            if (IsCompleted()) return -1;
            while (true) {
                var extractedNum = rnd.Next(1, 91);
                if (!billboard[extractedNum]) continue;
                billboard[extractedNum] = false;
                extractedNums.Add(extractedNum);
                return extractedNum;
            }
        }

        //Restituisce true se tutti i numeri sono estratti e false in caso contrario
        public bool IsCompleted() {
            return billboard.All(x => x.Value != true);
        }

        //Stampa tutte le estrazioni fin'ora effettuate
        public void PrintExtractions() {
            foreach (var k in billboard.Where(k => !k.Value)) Console.Write(k.Key + " - ");
        }

        //Crea una stringa con i numeri del tabellone estratti o degli asterischi per i numero non estratti
        //formattata come un vero tabellone
        public override string ToString() {
            var billBoardToPrint = "";

            for (var i = 0; i < 9; i++) {
                for (var j = 1; j <= 10; j++)
                    if (!billboard[i * 10 + j]) {
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