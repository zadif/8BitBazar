using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Bit_Bazaar
{
    public  class  User
    {
        [BsonId] public ObjectId Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("number")]
        public double Number { get; set;  }

        [BsonElement("gender")]
        public string Gender { get; set; }

       

        [BsonElement("email")]
        public string Email { get; set; }

        public List<string> Sell { get; set; }
        public List<string> Buy { get; set; }
        public User(string nam,string pass,double num,string gen, string ema)
        {
            Username = nam;
            Password = pass;
            Number = num;
            Gender = gen;
            Email = ema;
            Sell = new List<string>();
            Buy = new List<string>();
        }
    }
}
