﻿using laiLaChoCu.Helpers;
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
        Task<List<ItemResponse>> GetAll(string keyWord, int page, int pageSize);
        Task<List<ItemResponse>> GetAll(Guid id, int page, int pageSize);
        Task<List<ItemResponse>> GetArea(string keyWord, int page, int pageSize);
        Task<List<ItemResponse>> GetTopic(string keyWord, int page, int pageSize);
        Task<List<ItemResponse>> Get(int page, int pageSize);
        Task<List<ItemResponse>> GetPay(int page, int pageSize);
        Task<List<ItemResponse>> GetPrice(int price1,int price2,int page, int pageSize);
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

        public async Task<List<ItemResponse>> Get(int page, int pageSize)
        {
            var list = await _dataContext.Items
                .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetAll(string keyWord, int page, int pageSize)
        {
            var list = await _dataContext.Items.Where(x => x.Name.Contains(keyWord ?? ""))
               .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetAll(Guid id, int page, int pageSize)
        {
            var list = await _dataContext.Items.Where(x=>x.AccountId==id)
               .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }
            public async Task<List<ItemResponse>> GetArea(string keyWord, int page, int pageSize)
        {
            var list = await _dataContext.Items.Where(x => x.Area.Contains(keyWord ?? "") )
               .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<ItemResponse> GetByID(int id)
        {
            var exist = await _dataContext.Items.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Item, ItemResponse>(exist);
        }

        public async Task<List<ItemResponse>> GetPay(int page, int pageSize)
        {
            var list = await _dataContext.Items.Where(x => x.Status == Enums.StatusEnum.PAY)
               .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetPrice(int price1, int price2, int page, int pageSize)
        {
            var list = await _dataContext.Items.Where(x => x.Price >= price1 && x.Price <= price2)
               .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<List<ItemResponse>> GetTopic(string keyWord, int page, int pageSize)
        {
            var list = await _dataContext.Items.Where(x => x.Topic.Contains(keyWord ?? ""))
               .Skip(page * pageSize).Take(pageSize).OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<Item>, List<ItemResponse>>(list);
        }

        public async Task<ItemResponse> Pay(int id)
        {
            Item exist = _dataContext.Items.Where(x => x.Id == id).FirstOrDefault();
            if(exist != null)
            {
                exist.Status = Enums.StatusEnum.PAY;
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
