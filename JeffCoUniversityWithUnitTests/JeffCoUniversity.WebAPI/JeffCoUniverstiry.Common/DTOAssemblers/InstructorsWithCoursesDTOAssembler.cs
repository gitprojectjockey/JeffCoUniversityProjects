using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Outbound;
using System.Collections.Generic;

namespace JeffCoUniversity.Common.DTOAssemblers
{
    public sealed class InstructorsWithCoursesDTOAssembler : DTOAssembler<IEnumerable<InstructorWithCoursesOut>, IEnumerable<Instructor>>
    {
        public override IEnumerable<InstructorWithCoursesOut> AssembleDTO(IEnumerable<Instructor> source)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Instructor>, IEnumerable<InstructorWithCoursesOut>>(source);
        }
    }
}
