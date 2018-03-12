using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Outbound;

namespace JeffCoUniversity.Common.DTOAssemblers
{
    public sealed class CourseDTOAssembler : DTOAssembler<CourseOut, Course>
    {
        public override CourseOut AssembleDTO(Course source)
        {
            return AutoMapper.Mapper.Map<Course, CourseOut>(source);
        }
    }
}
