using WebApi.ModelViews;

namespace WebApi.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorGetView>> GetAllDoctors();
        Task<DoctorGetView> GetDoctorById(int id);
        Task<int> AddNewDoctor(DoctorPostView doctorPost);
        Task DeleteDoctor(int id);
        Task<DoctorGetView> UpdateDoctor(DoctorUpdateView doctorUpdate, int id);
        Task<bool> IsIdExist(int id);
    }
}
