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

        public Player(string name, string surname, int number)
        {
            this.name = name;
            this.surname = surname;
            this.number = number;
        }
        public static void AddPlayer(Player player)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ITParkTeams");
            var collection = database.GetCollection<Player>("Players");
            collection.InsertOne(player);
        }
        public static void ListBoxUpdate(ListBox listBox)
        {
            listBox.Items.Clear();
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ITParkTeams");
            var collection = database.GetCollection<Player>("Players");
            var listUsers = collection.Find(x => true).ToList();
            foreach (var item in listUsers)
            {
                listBox.Items.Add(item.name);
            }

        }
    }
}
