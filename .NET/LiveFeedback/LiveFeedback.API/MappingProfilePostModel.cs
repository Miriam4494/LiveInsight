using LiveFeedback.Core.DTOs;
using LiveFeedback.API.PostModels;
using AutoMapper;
using LiveFeedback.Core.Entities;

namespace LiveFeedback.API
{
    public class MappingProfilePostModel:Profile
    {



        public MappingProfilePostModel()
        {
            //CreateMap<UserPostModel, UserDTO>().ReverseMap();
            //CreateMap<Feedback, FeedbackDTO>().ReverseMap();
            //CreateMap<Role, RoleDTO>().ReverseMap();
            //CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<PermissionPostModel, PermissionDTO>();
            CreateMap<RolePostModel, RoleDTO>();
            CreateMap<QuestionPostModel, QuestionDTO>();
            CreateMap<FeedbackPostModel, FeedbackDTO>();
            CreateMap<UserPostModel, UserDTO>();
            CreateMap<MyImagePostModel, MyImageDTO>();
            CreateMap<UserPostModel, User>()
    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // לא להעביר את הסיסמה ל-User

            CreateMap<User, UserDTO>();

            //CreateMap<MyImage, MyImageDTO>().ReverseMap();



            //CreateMap<Permission, PermissionDTO>();
            //CreateMap<Role, RoleDTO>();
            //CreateMap<Question, QuestionDTO>();
            //CreateMap<Feedback, FeedbackDTO>();
            //CreateMap<User, UserDTO>();
            //CreateMap<MyImage, MyImageDTO>();
        }
    }
}
