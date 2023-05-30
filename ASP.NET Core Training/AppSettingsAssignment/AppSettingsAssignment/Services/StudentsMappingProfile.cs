using AppSettingsAssignment.DataModels;
using AppSettingsAssignment.ViewModels.Request;
using AppSettingsAssignment.ViewModels.Response;
using AutoMapper;

namespace AppSettingsAssignment.Services
{
    public class StudentsMappingProfile : Profile
    {
        public StudentsMappingProfile() : base() 
        {
            SetupMapping();     
        }
        private void SetupMapping() 
        {
            CreateMap<StudentsDataModel, StudentResponse>().ReverseMap();
            CreateMap<StudentsDataModel, AddStudentRequest>().ReverseMap();
        }
    }
}
