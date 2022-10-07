using AutoMapper;
using TrainerCalender.Models;
using TrainerCalender.Models.Dto;

namespace TrainerCalender
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<SkillDto, Skill>();
                config.CreateMap<Skill, SkillDto>();

                config.CreateMap<CourseDto, Course>();
                config.CreateMap<Course, CourseDto>();

                config.CreateMap<TrainerCourseDto, TrainerCourse>();
                config.CreateMap<TrainerCourse, TrainerCourseDto>();

                config.CreateMap<ScheduleDto, Schedule>();
                config.CreateMap<Schedule, ScheduleDto>();

                config.CreateMap<UserDto, User>();
                config.CreateMap<User, UserDto>();
            }
            );
            return mappingConfig;
        }

    }
}
