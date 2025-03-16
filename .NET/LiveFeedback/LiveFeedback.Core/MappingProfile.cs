using LiveFeedback.Core.DTOs;
using LiveFeedback.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace LiveFeedback.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<MyImage, MyImageDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(i => i.Id))); // מיפוי מזהים בלבד

            CreateMap<QuestionDTO, Question>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());
            //יציג את כל הפרטים
   //         CreateMap<Question, QuestionDTO>()
   //.ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
   //.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
        }
    }
}
