using MongoDB.Driver;
using ProjectMS.Sourcing.Data.Interface;
using ProjectMS.Sourcing.Entities;
using ProjectMS.Sourcing.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMS.Sourcing.Data
{
    public class SourcingContext : ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Auctions = database.GetCollection<Auction>(nameof(Auction));
            Bids = database.GetCollection<Bids>(nameof(Bids));

            SourcingContextSeed.SeedData(Auctions);
        }

        public IMongoCollection<Auction> Auctions { get; }
        public IMongoCollection<Bids> Bids { get; }
    }
}
