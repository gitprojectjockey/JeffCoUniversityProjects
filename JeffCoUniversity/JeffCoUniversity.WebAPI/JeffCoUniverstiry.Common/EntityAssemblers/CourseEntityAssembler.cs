using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Inbound;

namespace JeffCoUniversity.Common.EntityAssemblers
{
    public sealed class CourseEntityAssembler : EntityAssembler<Course, CourseWithInstructorsIn>
    {
        public override Course AssembleEntity(CourseWithInstructorsIn source)
        {
            return AutoMapper.Mapper.Map<CourseWithInstructorsIn, Course>(source);
        }
    }
}
