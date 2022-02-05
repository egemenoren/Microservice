using MongoDB.Driver;
using ProjectMS.Sourcing.Data.Interface;
using ProjectMS.Sourcing.Entities;
using ProjectMS.Sourcing.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMS.Sourcing.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _context;
        public BidRepository(ISourcingContext context)
        {
            _context = context;
        }
        public async Task<List<Bids>> GetBidsByAuctionId(string id)
        {
            FilterDefinition<Bids> filter = Builders<Bids>.Filter.Eq(x => x.Id, id);
            List<Bids> bids = await _context.Bids.Find(filter).ToListAsync();
            bids = bids.OrderByDescending(x => x.CreatedAt)
                .GroupBy(x => x.SellerUserName)
                .Select(x => new Bids
                {
                    AuctionId = x.FirstOrDefault().AuctionId,
                    Price = x.FirstOrDefault().Price,
                    CreatedAt = x.FirstOrDefault().CreatedAt,
                    SellerUserName = x.FirstOrDefault().SellerUserName,
                    ProductId = x.FirstOrDefault().ProductId,
                    Id=x.FirstOrDefault().Id
                }).ToList();
            return bids;

        }

        public async Task<Bids> GetWinnerBid(string id)
        {
            List<Bids> bids = await GetBidsByAuctionId(id);
            return bids.OrderByDescending(x => x.Price).FirstOrDefault();
        }

        public async Task SendBid(Bids bid)
        {
            await _context.Bids.InsertOneAsync(bid);
        }
    }
}
