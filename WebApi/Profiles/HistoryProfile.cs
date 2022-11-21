using AutoMapper;
using WebApi.Models;
using WebApi.ModelViews;

namespace WebApi.Profiles
{
    public class HistoryProfile: Profile
    {
        public HistoryProfile()
        {
            CreateMap<History, HistoryGetView>()
                .ReverseMap();


            CreateMap<History, HistoryPostView>()
                .ReverseMap();

            CreateMap<HistoryUpdateView, History>()
                .ForMember(h => h.Id, e => e.UseDestinationValue())
                .ForMember(h => h.PatientFullName, e => e.UseDestinationValue())
                .ForMember(h => h.PatientContacts, e => e.MapFrom(s => s.PatientContacts))
                .ForMember(h => h.Department, e => e.MapFrom(s => s.Department))
                .ForMember(h => h.Treatment, e => e.MapFrom(s => s.Treatment))
                .ForMember(h => h.Diagnosis, e => e.MapFrom(s => s.Diagnosis));
        }
    }
}
