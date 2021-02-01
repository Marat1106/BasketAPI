using Basket.API.Entities;
using Basket.API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BasketCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCard>> GetBasketCard(string name)
        {
            var basketCard = await _repository.GetBasketCard(name);
            return Ok(basketCard ?? new BasketCard(name));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCard>> UpdateGroup(BasketCard basketCard)
        {
            var updatedBasketCard= await _repository.UpdateBasketCard(basketCard);
            return Ok(updatedBasketCard);
        }

        [HttpDelete("{name}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteBasketCard(string id)
        {
            return Ok(await _repository.DeleteBasketCard(id));
        }
    }
}
