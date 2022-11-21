using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.ModelViews;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly MedicalHistoriesContext dbContext;

        private readonly IMapper mapper;

        public HistoryService(MedicalHistoriesContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;

            this.mapper = mapper;
        }

        public async Task<int> AddNewHistory(HistoryPostView historyPost)
        {
            var history = mapper.Map<HistoryPostView, History>(historyPost);

            var actualLastId = dbContext.Histories
                .Select(h => h.Id)
                .Max();

            history.Id = actualLastId + 1;

            await dbContext.Histories
                .AddAsync(history);

            await dbContext.
                SaveChangesAsync();

            return history.Id;
        }

        public async Task DeleteHistory(int id)
        {
            var history = await dbContext.Histories
                .FirstAsync(h=>h.Id.Equals(id));

            dbContext.Histories.Remove(history);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<HistoryGetView>> GetAllHistories()
        {
            var histories = await dbContext.Histories
                .ToListAsync();

            var historyviews = histories
                .Select(h=>mapper.Map<History, HistoryGetView>(h))
                .ToList();

            return historyviews;
        }

        public async Task<HistoryGetView> GetHistoryById(int id)
        {
            var history = await dbContext.Histories
                .SingleAsync(h => h.Id == id);
         
            var view = mapper.Map<History, HistoryGetView>(history);

            return view;
        }

        public async Task<bool> IsIdExist(int id)
        {
            var history = await dbContext.Histories
                .FirstOrDefaultAsync(h => h.Id.Equals(id));

            return history == null ? false : true;
        }

        public async Task<HistoryGetView> UpdateHistory(HistoryUpdateView historyUpdate, int id)
        {
            var updatingHistory = await dbContext.Histories
                .SingleAsync(h => h.Id.Equals(id));

            mapper.Map(historyUpdate, updatingHistory);

            await dbContext.SaveChangesAsync();

            var view = mapper.Map<History, HistoryGetView>(updatingHistory);

            return view;
        }
    }
}
