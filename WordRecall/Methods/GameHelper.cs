using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WordRecall.Methods
{
    public class GameHelper
    {
        string[] allWords;
        public GameHelper()
        {
            allWords = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "engmix.txt");
        }

        public List<string> GetWords(int total)
        {
            List<string> words = new List<string>();
            Random rnd = new Random();
            for (int i = 0; i < total; i++)
            {
                words.Add(allWords[rnd.Next(allWords.Length)]);
            }
            return words;
        }

        public string GetGoodGreet()
        {
            Random rnd = new Random();
            return goodGreet[rnd.Next(goodGreet.Length)];
        }

        public string GetNotGoodGreet()
        {
            Random rnd = new Random();
            return notGoodGreet[rnd.Next(notGoodGreet.Length)];
        }

        private string[] goodGreet = { "Good job", "Nice", "Great" };
        private string[] notGoodGreet = { "Nope", "Try again", "Sorry, try again","That's not the word" };
    }

    public enum ConversationState
    {
        initialGame,
        initialMessage,
        theGame,
        endGame,
        submitScore,
    }

    public class InputModel
    {
        public string Input { get; set; }
    }
}
