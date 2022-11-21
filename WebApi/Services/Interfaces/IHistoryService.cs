using WebApi.Models;
using WebApi.ModelViews;

namespace WebApi.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<HistoryGetView>> GetAllHistories();
        Task<HistoryGetView> GetHistoryById(int id);
        Task<int> AddNewHistory(HistoryPostView historyPost);
        Task DeleteHistory(int id);
        Task<HistoryGetView> UpdateHistory(HistoryUpdateView historyUpdate, int id);
        Task<bool> IsIdExist(int id);
    }
}
