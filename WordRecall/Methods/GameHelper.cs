using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WordRecall.Methods
{
    public class GameHelper
    {
        
        public GameHelper()
        {
            
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
        private string[] allWords = { "usage", "reassure", "jabbering", "unbalances", "help", "cappuccino", "quadriceps", "emulsifiers", "slashes", "kurd", "wets", "redness", "awash", "revolting", "wrongdoing", "chapels", "ilexes", "solids", "bisque", "impermissibly", "overcapitalised", "carib", "dunvegan", "smackers", "glossary", "hummingbird", "glaringly", "flageolet", "somme", "backlight",
        "pumpkin", "harsher", "county", "disciplined", "dimmer", "waterfalls", "tad", "ears", "pressurize", "fungous", "assurances", "poleaxe", "clapping", "doughnuts", "volumetric", "festinating", "scorer", "fossilisation", "anapest", "closer", "fives", "cortical", "perennials", "farina", "enfolded", "bulkily", "sedimentary", "astragal", "coextensive", "floc",
        "disavowals", "elizabeth", "favourite", "morays", "flagrant", "videos", "warranter", "geometer", "ramifications", "flexibility", "dingiest", "archangel", "alkalizing", "immodest", "spanked", "angled", "appeaser", "demister", "lustrous", "botanical", "reforming", "doughtier", "waxes", "atonement", "anodises", "redistributing", "lades", "tempera", "alms", "spruceness", "ghosted", "jogged", "federalize", "duodena", "griping", "pluck", "irreproducible", "etymologists", "alehouse", "arraigned", "prodders", "exhibitionist", "superstructures", "facias", "stygian", "quaintest", "redcoats", "surfaced", "tottering", "overpays", "wigmaker", "deodorizers", "fetes", "hypnoses", "cabdriver", "pentateuch", "giantesses", "stout", "phantasmagorias", "dwarves", "chessboards", "cocket", "surveillance", "chilliness", "roofing", "schmucks", "accruals", "mastered", "redrafts", "quiescent", "agriculturally", "immolating", "puts", "sockeye", "reedited", "scabies", "uninclosed", "unhallowed", "deviant", "justificators", "aetiology", "brag", "handouts", "spontaneously", "doone", "waterhouse", "recondite", "durum", "pockmark", "unavailable", "brickyards", "calculable", "dogma", "bolivians", "customer", "subcontractors", "ostriches", "scats", "accruing", "secludes", "wailed", "suntan", "arbitrageur", "offensiveness", "accompany", "flounders", "fuzzed", "itemise", "exaggerated", "grahams", "treatment", "anaesthesiology", "fistulae", "squatter", "haemophiliac", "nerdy", "skyways", "macho", "dive", "leviable"};
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
