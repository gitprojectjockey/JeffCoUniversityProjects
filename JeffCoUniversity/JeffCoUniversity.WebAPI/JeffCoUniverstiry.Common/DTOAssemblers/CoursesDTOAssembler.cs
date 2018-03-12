using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Outbound;
using System.Collections.Generic;

namespace JeffCoUniversity.Common.DTOAssemblers
{
    public sealed class CoursesDTOAssembler : DTOAssembler<IEnumerable<CourseOut>, IEnumerable<Course>>
    {
        public override IEnumerable<CourseOut> AssembleDTO(IEnumerable<Course> source)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Course>, IEnumerable<CourseOut>>(source);
        }
    }
}
