using System;

namespace TombolaGame_Project {
    internal class Program {
        private static void Main(string[] args) {
            var board = new Billboard(6);
            // List<Card> cards = new List<Card>(6);


            // for (int i = 0; i < 6; i++) {
            //     cards.Add(new Card());
            // }

            // for (int i = 0; i < 90; i++) {
            //     int extractedNum = board.Extract();
            //     Console.WriteLine(extractedNum);
            //     for (int j = 0; j < 6; j++) {
            //         if (cards[j].NumberExtracted(extractedNum)) {
            //             string result = cards[j].CheckResult();
            //             Console.WriteLine("  -La cartella numero: "+j+" ha fatto: "+result);
            //             if (string.Compare(result, "Tombola") == 0) {
            //                 i = 90;
            //                 j = 6;
            //             }
            //         }
            //     }
            // }

            Console.ReadKey();
        }
    }
}