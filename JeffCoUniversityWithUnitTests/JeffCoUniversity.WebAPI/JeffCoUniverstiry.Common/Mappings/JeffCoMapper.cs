using AutoMapper;
using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Inbound;
using JeffCoUniversity.DTO.Outbound;

namespace JeffCoUniversity.Common.Mappings
{
    public static class JeffCoMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                // Outbound DTO Mappings
                config.CreateMap<Instructor, InstructorOut>();
                config.CreateMap<Course, CourseOut>();
                config.CreateMap<Instructor, InstructorWithCoursesOut>();
                
                // Inbound DTO Mappings
                config.CreateMap<InstructorIn, Instructor>()
                .ForMember(dest => dest.Courses, opts => opts.Ignore());
                config.CreateMap<CourseIn, Course>()
                 .ForMember(dest => dest.Instructors, opts => opts.Ignore());

                config.CreateMap<InstructorWithCoursesIn, Instructor>();
            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}



