using ProjectMS.Sourcing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMS.Sourcing.Repositories.Interfaces
{
    public interface IBidRepository
    {
        Task SendBid(Bids bid);
        Task<List<Bids>> GetBidsByAuctionId(string id);
        Task<Bids> GetWinnerBid(string id);
    }
}
