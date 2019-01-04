using System.Collections.Generic;
using System.Threading.Tasks;
using GiftShop.Models;

namespace GiftShopMVC.Services
{
    public interface IGiftRepository
    {
        Task<IEnumerable<Gift>> GetGifts();
        Task<IEnumerable<Gift>> GetGenderGift(int id);
        Task AddGift(Gift gift);
    }
}