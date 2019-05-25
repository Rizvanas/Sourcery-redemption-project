using AutoMapper;
using My_IKS.Data.Domain;
using My_IKS.Data.DTO.General;
using My_IKS.Data.DTO.Requests;
using My_IKS.Data.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_IKS.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterRequest, User>().AfterMap((src, dest) => 
            {
                if (dest.Location == null)
                    dest.Location = "Unknown";
            });

            CreateMap<User, UserIntroResponse>().AfterMap((src, dest) =>
            {
                if (dest.SkillTitles == null)
                    dest.SkillTitles = new List<string>();
                if(dest.GoalTitles == null)
                    dest.GoalTitles = new List<string>();
            });

            CreateMap<User, UserSkillsResponse>()
                .ForMember(dest => dest.Skills, opt => opt
                .MapFrom(src => src.UserSkills.Select(s => new
                {
                    s.Skill.SkillId,
                    s.Skill.Title,
                    s.Skill.Level
                })));

            CreateMap<User, UserGoalsResponse>()
                .ForMember(dest => dest.Goals, (IMemberConfigurationExpression<User, UserGoalsResponse, IEnumerable<Object>> opt) => opt
                .MapFrom(src => src.Goals.Select(g => new
                {
                    g.GoalId,
                    g.Title,
                    g.Description,
                    g.Requests
                })));

            CreateMap<User, UserRequestsResponse>().ForMember(dest => dest.Goals, opt => opt.MapFrom(src => src.Goals.Select(g => new
            {
                g.GoalId,
                g.Title,
                g.Description,
                g.Requests
            })));

            CreateMap<SkillUpdateRequest, UserSkill>()
                .ForAllMembers(o => o.Condition((src, dest, member) => member != null));

            CreateMap<GoalUpdateRequest, Goal>()
                .ForAllMembers(o => o.Condition((src, dest, member) => member != null));

            CreateMap<UserProfile, User>()
                .ForAllMembers(o => o.Condition((src, dest, member) => member != null));

            CreateMap<UserLoginRequest, User>();
            CreateMap<User, NonActiveUserResponse>();
            CreateMap<User, UserProfile>();
            CreateMap<FilterRequest, Filter>();
        }
    }
}
