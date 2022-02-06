using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectMS.Sourcing.Entities;
using ProjectMS.Sourcing.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectMS.Sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;
        public BidController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bids>> SendBid([FromBody] Bids bid)
        {
            await _bidRepository.SendBid(bid);
            return Ok();
        }
        [HttpGet("GetBidsByAuctionId")]
        [ProducesResponseType(typeof(IEnumerable<Bids>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Bids>>> GetBidsByAuctionId(string id)
        {
            IEnumerable<Bids> bids = await _bidRepository.GetBidsByAuctionId(id);
            return Ok(bids);
        }
        [HttpGet("GetWinnerBid")]
        [ProducesResponseType(typeof(Bids), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Bids>>> GetWinnerBid(string id)
        {
            Bids bid = await _bidRepository.GetWinnerBid(id);
            return Ok(bid);
        }
    }
}
