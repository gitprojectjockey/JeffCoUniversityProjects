using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Outbound;

namespace JeffCoUniversity.Common.DTOAssemblers
{
    public sealed class InstructorWithCoursesDTOAssembler : DTOAssembler<InstructorWithCoursesOut, Instructor>
    {
        public override InstructorWithCoursesOut AssembleDTO(Instructor source)
        {
            return AutoMapper.Mapper.Map<Instructor, InstructorWithCoursesOut>(source);
        }
    }
}
