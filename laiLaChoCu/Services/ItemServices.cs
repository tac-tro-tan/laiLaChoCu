using laiLaChoCu.Helpers;
using laiLaChoCu.Models.Items;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using laiLaChoCu.Entities;
using AutoMapper.Configuration.Conventions;

namespace laiLaChoCu.Services
{
    public interface IItemServices
    {
        Task<List<ItemResponse>> GetAll(SearchRequest searchRequest);
        Task<List<ItemResponse>> GetAll(CartRequet cartRequet);
        Task<List<ItemResponse>> GetArea(SearchRequest searchRequest);
        Task<List<ItemResponse>> GetTopic(SearchRequest searchRequest);
        Task<List<ItemResponse>> Get(Request request);
        Task<List<ItemResponse>> GetPay(Request request);
        Task<List<ItemResponse>> GetPrice(PriceRequest priceRequest);
        Task<ItemResponse> GetByID(int id);
        Task<int> countAll(string keyWord);
        Task<int> countAll(Guid id);
        Task<int> countArea(string keyWord);
        Task<int> countTopic(string keyWord);
        Task<int> countAll();
        Task<int> countPay();
        Task<int> countPrice(int price1,int price2);
        Task<ItemResponse> Add(ItemRequest itemRequest);
        Task<ItemResponse> Update(int id, ItemRequest itemRequest);
        Task<ItemResponse> Delete(int id);
        Task<ItemResponse> Pay(int id);
        Task<List<ItemResponse>> GetQc(Request request);
        Task<int> countQc();
        Task<ItemResponse> quangcao(int id);
        Task<ItemResponse> Cancel(int id);
    }
    public class ItemServices : IItemServices
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ItemServices(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ItemResponse> Add(ItemRequest itemRequest)
        {
            Item newItem = new Item(itemRequest.AccountId, itemRequest.Name, itemRequest.Topic, itemRequest.Area, itemRequest.Price,itemRequest.Address,itemRequest.Phone, itemRequest.Describe,itemRequest.Image);

            newItem.Status = Enums.StatusEnum.APPROVED;
           // newItem.Created = DateTime.Now;
            this._dataContext.Items.Add(newItem);
            await _dataContext.SaveChangesAsync();
    
            return _mapper.Map<Item, ItemResponse>(newItem);
        }

        public async Task<ItemResponse> Cancel(int id)
        {
            Item exist = _dataContext.Items.Where(x => x.Id == id).FirstOrDefault();
            if (exist != null)
            {
                exist.Status = Enums.StatusEnum.APPROVED;
                this._dataContext.Update(exist);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Item, ItemResponse>(exist);
        }

        public async Task<int> countAll(string keyWord)
        {
            var total = await _dataContext.Items.Where(x => x.Name.Contains(keyWord ?? "")).CountAsync();

            return total;
        }

        public async Task<int> countAll()
        {
            var total = await _dataContext.Items.CountAsync();

            return total;
        }

        public async Task<int> countAll(Guid id)
        {
            var total = await _dataContext.Items.Where(x => x.AccountId == id).CountAsync();

            return total;
        }
        public async Task<int> countArea(string keyWord)
        {
            var total= await _dataContext.Items.Where(x => x.Area.Contains(keyWord ?? "")).CountAsync();

            return total;
        }

        public async Task<int> countPay()
        {
            var total = await _dataContext.Items.Where(x=>x.Status==Enums.StatusEnum.PAY).CountAsync();

            return total; 
        }

        public async Task<int> countPrice(int price1, int price2)
        {
            var total = await _dataContext.Items.Where(x=>x.Price >= price1 && x.Price <= price2).CountAsync();

            return total;
        }

        public async Task<int> countQc()
        {
            var total = await _dataContext.Items.Where(x => x.Status == Enums.StatusEnum.DRAFT).CountAsync();

            return total;
        }

        public async Task<int> countTopic(string keyWord)
        {
         var total = await _dataContext.Items.Where(x => x.Topic.Contains(keyWord ?? "")).CountAsync();

        return total;
        }


        public async Task<ItemResponse> Delete(int id)
        {
            Item exist = _dataContext.Items.Where(x => x.Id == id).FirstOrDefault();
            if (exist != null)
            {
                this._dataContext.Items.Remove(exist);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Item, ItemResponse>(exist);
        }

        public async Task<List<ItemResponse>> Get(Request request)
        {
            var list = await _dataContext.Items
                .Skip(request.page * request.pageSize).Take(request.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetAll(SearchRequest searchRequest)
        {
            var list = await _dataContext.Items.Where(x => x.Name.Contains(searchRequest.keyWord ?? ""))
               .Skip(searchRequest.page * searchRequest.pageSize).Take(searchRequest.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetAll(CartRequet cartRequet)
        {
            var list = await _dataContext.Items.Where(x=>x.AccountId== cartRequet.Id)
               .Skip(cartRequet.page * cartRequet.pageSize).Take(cartRequet.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }
            public async Task<List<ItemResponse>> GetArea(SearchRequest searchRequest)
        {
            var list = await _dataContext.Items.Where(x => x.Area.Contains(searchRequest.keyWord ?? "") )
               .Skip(searchRequest.page * searchRequest.pageSize).Take(searchRequest.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<ItemResponse> GetByID(int id)
        {
            var exist = await _dataContext.Items.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Item, ItemResponse>(exist);
        }

        public async Task<List<ItemResponse>> GetPay(Request request)
        {
            var list = await _dataContext.Items.Where(x => x.Status == Enums.StatusEnum.PAY)
               .Skip(request.page * request.pageSize).Take(request.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetPrice(PriceRequest priceRequest)
        {
            var list = await _dataContext.Items.Where(x => x.Price >= priceRequest.Price1 && x.Price <= priceRequest.Price2)
               .Skip(priceRequest.page * priceRequest.pageSize).Take(priceRequest.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetQc(Request request)
        {
            var list = await _dataContext.Items.Where(x => x.Status == Enums.StatusEnum.DRAFT)
              .Skip(request.page * request.pageSize).Take(request.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetTopic(SearchRequest searchRequest)
        {
            var list = await _dataContext.Items.Where(x => x.Topic.Contains(searchRequest.keyWord ?? ""))
               .Skip(searchRequest.page * searchRequest.pageSize).Take(searchRequest.pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<ItemResponse> Pay(int id)
        {
            Item exist = _dataContext.Items.Where(x => x.Id == id).FirstOrDefault();
            if(exist != null)
            {
                exist.Status = Enums.StatusEnum.PAY;
                exist.PayTime = DateTime.Now;
                this._dataContext.Update(exist);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Item, ItemResponse>(exist);
        }

        public async Task<ItemResponse> quangcao(int id)
        {
            Item exist = _dataContext.Items.Where(x => x.Id == id).FirstOrDefault();
            if (exist != null)
            {
                exist.Status = Enums.StatusEnum.DRAFT;
                exist.PayTime = DateTime.Now;
                this._dataContext.Update(exist);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Item, ItemResponse>(exist);
        }

        public async Task<ItemResponse> Update(int id, ItemRequest itemRequest)
        {
            Item exist = _dataContext.Items.Where(x => x.Id == id).FirstOrDefault();
            if(exist != null)
            {
                exist.AccountId = itemRequest.AccountId;
                exist.Name = itemRequest.Name;
                exist.Topic = itemRequest.Topic;
                exist.Area = itemRequest.Area;
                exist.Price = itemRequest.Price;
                exist.Phone = itemRequest.Phone;
                exist.Address = itemRequest.Address;
                exist.Describe = itemRequest.Describe;
                exist.Image = itemRequest.Image;
                this._dataContext.Update(exist);
                await _dataContext.SaveChangesAsync(); 
            }
            return _mapper.Map<Item, ItemResponse>(exist);
        }
    }
}
