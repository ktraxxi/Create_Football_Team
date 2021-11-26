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
    class Player
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public string name;
        public string surname;
        public int number;
        public string currentTeam;

        public Player(string name, string surname, int number, string currentTeam)
        {
            this.name = name;
            this.surname = surname;
            this.number = number;
            this.currentTeam = currentTeam;
        }
        public static void AddPlayer(Player player)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Players_Football_Teams");
            var collection = database.GetCollection<Player>("Players");
            collection.InsertOne(player);
        }
        public static void ListBoxUpdate(ListBox listBox)
        {
            listBox.Items.Clear();
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Players_Football_Teams");
            var collection = database.GetCollection<Player>("Players");

            var listPlayers = collection.Find(x => true).ToList();
            foreach (var item in listPlayers)
            {
                listBox.Items.Add(item);
            }
        }
    }
}
