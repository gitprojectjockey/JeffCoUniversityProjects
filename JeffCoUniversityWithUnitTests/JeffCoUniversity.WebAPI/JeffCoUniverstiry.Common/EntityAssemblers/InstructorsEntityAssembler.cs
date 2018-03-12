using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Inbound;
using System.Collections.Generic;

namespace JeffCoUniversity.Common.EntityAssemblers
{
    public sealed class InstructorsEntityAssembler : EntityAssembler<IEnumerable<Instructor>, IEnumerable<InstructorWithCoursesIn>>
    {
        public override IEnumerable<Instructor> AssembleEntity(IEnumerable<InstructorWithCoursesIn> source)
        {
            return AutoMapper.Mapper.Map<IEnumerable<InstructorWithCoursesIn>, IEnumerable<Instructor>>(source);
        }
    }
}
