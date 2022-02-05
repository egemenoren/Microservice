using MongoDB.Driver;
using ProjectMS.Sourcing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMS.Sourcing.Data.Interface
{
    public interface ISourcingContext
    {
        IMongoCollection<Auction> Auctions { get; }
        IMongoCollection<Bids> Bids { get; }
    }
}
