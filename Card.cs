using System.Collections.Generic;

namespace TombolaGame_Project {
    public class Card {
        public Dictionary<int, bool>
            card; //numeri della scheda: true se il numero è ancora libero, false se è stato estratto e quindi occupato

        private ushort
            _score; //numeri estratti appartenenti alla scheda, se arriva a 2: ambo  3:terna  4:quaterna 5: cinquina  15:tombola


        //inizializza lo score a 0 e la lista con i numeri casuali generati
        public Card(List<int> cardNums) {
            card = new Dictionary<int, bool>(15);
            _score = 0;
            for (var i = 0; i < 15; i++) card.Add(cardNums[i], true);
        }

        //controlla se un numero estratto appartriene alla cartella e in caso aumenta lo score e setta a false il numero
        public void NumberExtracted(int num) {
            if (card.ContainsKey(num)) {
                card[num] = false;
                _score++;
            }

        }

        //controlla il risultato conseguito e restituisce niente se non si ha raggionto nessun
        //obbiettivo o il nome della vincita se si ha raggiunto un obbiettivo
        public string CheckResult(int num) {
            NumberExtracted(num);
            return _score switch {
                2 => "Ambo",
                3 => "Terna",
                4 => "Quaterna",
                5 => "Cinquina",
                15 => "Tombola",
                _ => ""
            };
        }
    }
}