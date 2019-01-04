using System.Collections.Generic;
using System.Threading.Tasks;
using GiftShop.Models;
using GiftShopMVC.Models;

namespace GiftShopMVC.Services
{
    public interface IGiftRepository
    {
        Task<IEnumerable<GiftViewModel>> GetGifts();
        Task<IEnumerable<GiftViewModel>> GetGenderGift(int id);
        Task AddGift(GiftViewModel gift);
    }
}