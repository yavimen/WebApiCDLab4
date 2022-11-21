using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.ModelViews;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class DoctorService: IDoctorService
    {
        private readonly MedicalHistoriesContext dbContext;

        private readonly IMapper mapper;

        public DoctorService(MedicalHistoriesContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;

            this.mapper = mapper;
        }

        public async Task<int> AddNewDoctor(DoctorPostView doctorPost)
        {
            var doctor = mapper.Map<DoctorPostView, Doctor>(doctorPost);

            var actualLastId = dbContext.Doctors
                .Select(d => d.Id)
                .Max();

            doctor.Id = actualLastId + 1;

            await dbContext.Doctors
                .AddAsync(doctor);

            await dbContext.
                SaveChangesAsync();

            return doctor.Id;
        }

        public async Task DeleteDoctor(int id)
        {
            var doctors = await dbContext.Doctors
                .FirstAsync(d => d.Id.Equals(id));

            dbContext.Doctors.Remove(doctors);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<DoctorGetView>> GetAllDoctors()
        {
            var doctors = await dbContext.Doctors
                .ToListAsync();

            var doctorviews = doctors
                .Select(d => mapper.Map<Doctor, DoctorGetView>(d))
                .ToList();

            return doctorviews;
        }

        public async Task<DoctorGetView> GetDoctorById(int id)
        {
            var doctor = await dbContext.Doctors
                .SingleAsync(d => d.Id == id);

            var view = mapper.Map<Doctor, DoctorGetView>(doctor);

            return view;
        }

        public async Task<bool> IsIdExist(int id)
        {
            var doctor = await dbContext.Doctors
                .FirstOrDefaultAsync(h => h.Id.Equals(id));

            return doctor == null ? false : true;
        }

        public async Task<DoctorGetView> UpdateDoctor(DoctorUpdateView doctorUpdate, int id)
        {
            var updatingDoctor = await dbContext.Doctors
                .SingleAsync(d => d.Id.Equals(id));

            mapper.Map(doctorUpdate, updatingDoctor);

            await dbContext.SaveChangesAsync();

            var view = mapper.Map<Doctor, DoctorGetView>(updatingDoctor);

            return view;
        }
    }
}
