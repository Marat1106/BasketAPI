using Basket.API.Data.Interface;
using Basket.API.Entities;
using Basket.API.Repository.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketCardContext _context;

        public BasketRepository(IBasketCardContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> DeleteBasketCard(string id)
        {
            return await _context.Redis.KeyDeleteAsync(id);
        }

        public async Task<BasketCard> GetBasketCard(string name)
        {
            var basket = await _context.Redis.StringGetAsync(name);
            if (basket.IsNullOrEmpty)
            {
                return null;
            }
            try
            {
                return JsonConvert.DeserializeObject<BasketCard>(basket);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async  Task<BasketCard> UpdateBasketCard(BasketCard basketCard)
        {
            var updated = await _context.Redis.StringSetAsync(basketCard.Username, JsonConvert.SerializeObject(basketCard));
            if (!updated)
            {
                return null;
            }

            return await GetBasketCard(basketCard.Username);
        }
    }
}
