using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ITParkApp
{
    class Team
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public string teamName;
        public List<Player> sqwad;

        public Team(string teamName, List<Player> sqwad)
        {
            this.teamName = teamName;
            this.sqwad = sqwad;
        }
        public static void AddTeam(Team team)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Players_Football_Teams");
            var collection = database.GetCollection<Team>("Teams");
            collection.InsertOne(team);
        }
        public static void TeamListBoxUpdate(ListBox listBox)
        {
            listBox.Items.Clear();
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Players_Football_Teams");
            var collection = database.GetCollection<Team>("Teams");

            var listTeams = collection.Find(x => true).ToList();
            foreach (var item in listTeams)
            {
                listBox.Items.Add(item.teamName);
            }
        }
    }
}
