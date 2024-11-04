﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace _8_Bit_Bazaar
{
    internal class Arcade
    {

        [BsonId] public ObjectId Id { get; set; }
        [BsonElement("cname")]
        public string CName { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("year")]
        public double Year { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("games")]
        public string Games { get; set; }

        [BsonElement("user")]
        public string User { get; set; }
        public Arcade(string nam, string mode, double yea, double price, string desc,string gam, string user)
        {
            CName = nam;
            Model = mode;
            Year = yea;
            Price = price;
            Description = desc;
            Games = gam;
            User = user;
        }
    }
}