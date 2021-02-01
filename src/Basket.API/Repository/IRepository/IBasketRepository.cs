using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repository.IRepository
{
    public interface IBasketRepository
    {
        Task<BasketCard> GetBasketCard(string name);
        Task<BasketCard> UpdateBasketCard(BasketCard basketCard);
        Task<bool> DeleteBasketCard(string id);
    }
}
