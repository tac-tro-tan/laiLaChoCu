using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Carts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using laiLaChoCu.Entities;

namespace laiLaChoCu.Services
{
    public interface ICartServices
    {
        Task<List<CartResponse>> Get(Guid id,int page, int pageSize);
        Task<CartResponse> GetByID(int id);
        Task<int> countAll(Guid id);
        Task<CartResponse> Add(CartRequest cartRequest);
        Task<CartResponse> Delete(int id);
    }
    public class CartServices : ICartServices
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        public CartServices(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<CartResponse> Add(CartRequest cartRequest)
        {
            Cart cart = new Cart(cartRequest.AccountId,cartRequest.ItemId);
            cart.Create = DateTime.Now;
            this.dataContext.Add(cart);
            await dataContext.SaveChangesAsync();
            return mapper.Map<Cart,CartResponse>(cart);
        }

        public async Task<int> countAll(Guid id)
        {
            var total = await dataContext.Carts.Where(x=>x.AccountId==id).CountAsync();

            return total;
        }

        public async Task<CartResponse> Delete(int id)
        {
            Cart cart = dataContext.Carts.Where(x => x.Id == id).FirstOrDefault();
            if(cart != null)
            {
                this.dataContext.Remove(cart);
                await dataContext.SaveChangesAsync();
            }
            return mapper.Map<Cart, CartResponse>(cart);
        }

        public async Task<List<CartResponse>> Get(Guid id, int page, int pageSize)
        {
            var list = await dataContext.Carts.Where(x=>x.AccountId ==id).Skip(page*pageSize).Take(pageSize).ToListAsync();
            return mapper.Map<List<Cart>,List<CartResponse>>(list);
        }

        public async Task<CartResponse> GetByID(int id)
        {
            var cart = await dataContext.Carts.Where(x => x.Id == id).FirstOrDefaultAsync();
            return mapper.Map<Cart, CartResponse>(cart);
        }
    }
}
