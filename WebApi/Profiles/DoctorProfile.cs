using AutoMapper;
using WebApi.Models;
using WebApi.ModelViews;

namespace WebApi.Profiles
{
    public class DoctorProfile: Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorGetView>();

            CreateMap<DoctorPostView, Doctor>();

            CreateMap<DoctorUpdateView, Doctor>()
                .ForMember(h => h.Id, e => e.UseDestinationValue())
                .ForMember(h => h.Name, e => e.UseDestinationValue())
                .ForMember(h => h.Surname, e => e.UseDestinationValue())
                .ForMember(h => h.Department, e => e.MapFrom(s => s.Department))
                .ForMember(h => h.Position, e => e.MapFrom(s => s.Position));
        }
    }
}
