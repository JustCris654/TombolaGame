using System;

namespace TombolaGame_Project {
    internal class Program {
        private static void Main(string[] args) {
            
            Console.WriteLine("                                                        " +
                              "\n       _____ _____ _____ _____ _____ __    _____    _ " +
                              "\n      |_   _|     |     | __  |     |  |  |  _  |  | |_ _ _ " +
                              "\n        | | |  |  | | | | __ -|  |  |  |__|     |  | . | | |" +
                              "\n        |_| |_____|_|_|_|_____|_____|_____|__|__|  |___|_  |" +
                              "\n                                                       |___|" +
                              "\n " +
                              "\n       _____     _     _   _            _____             _ " +
                              "\n      |     |___|_|___| |_|_|___ ___   |   __|___ ___ ___|_|___ " +
                              "\n      |   --|  _| |_ -|  _| | .'|   |  |__   |  _| .'| . | |   |" +
                              "\n      |_____|_| |_|___|_| |_|__,|_|_|  |_____|___|__,|  _|_|_|_|" +
                              "\n                                                     |_| \n  ");
            
            Console.WriteLine("Numero cartelle minimo: 1\nNumero cartelle massimo: 6");
            var board = new Billboard(GetCardNum("Inserisci numero cartelle: "));
            Console.WriteLine("La cartella numero " +  StartGame(board)+" ha vinto!!!");

            Console.ReadKey();
        }


        private static int StartGame(Billboard billboard) {
            for (int i = 0; i < 90 || billboard.IsCompleted(); i++) {

                int numExtracted = billboard.Extract();
                if(numExtracted==-1) continue;
                
                for (int j = 0; j < billboard.cardNum; j++) {
                    string result = billboard.CardResult(billboard.Cards[j], numExtracted);
                    if (result != "") {
                        Console.WriteLine("La scheda numero "+(j+1)+" ha fatto: "+ result);
                        if (result == "Tombola") return j+1;
                    }
                }
            }
            

            return 0;
        }
        
        
        private static int GetCardNum(string text) {
            while (true) {
                Console.Write(text);
                int num = Int32.Parse(Console.ReadLine());
                if (num > 0 && num <= 6) {
                    return num;
                }
            }
        }
    }
}