using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordRecall.Methods
{
    public class FirestoreHelper
    {
        string projectId;
        FirestoreDb database;
        public FirestoreHelper()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", AppDomain.CurrentDomain.BaseDirectory + "/aksldmalsd.json");
            projectId = "wordrecall-4a3da";
            database = FirestoreDb.Create(projectId);
        }

        public async void AddItem(UserScoreModel counter)
        {
            try
            {
                CollectionReference reference = database.Collection("scores");
                await reference.AddAsync(counter);
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<UserScoreModel>> GetAllUserScore()
        {
            Query antriQuery = database.Collection("scores").OrderByDescending("score");
            List<UserScoreModel> result = new List<UserScoreModel>();
            QuerySnapshot antriSnap = await antriQuery.GetSnapshotAsync();
            foreach (DocumentSnapshot snap in antriSnap.Documents)
            {
                if (snap.Exists)
                {
                    UserScoreModel antrian = snap.ConvertTo<UserScoreModel>();
                    antrian.id = snap.Id;
                    result.Add(antrian);
                }
            }
            return result;
        }
    }

    [FirestoreData]
    public class UserScoreModel
    {
        public string id { get; set; }
        [FirestoreProperty]
        public int generatedId { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public int score { get; set; } = 0;
    }
}
