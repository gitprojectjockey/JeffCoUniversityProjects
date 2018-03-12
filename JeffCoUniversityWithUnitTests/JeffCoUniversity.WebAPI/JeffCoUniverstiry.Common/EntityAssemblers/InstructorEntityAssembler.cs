using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Inbound;

namespace JeffCoUniversity.Common.EntityAssemblers
{
    public sealed class InstructorEntityAssembler : EntityAssembler<Instructor, InstructorWithCoursesIn>
    {
        public override Instructor AssembleEntity(InstructorWithCoursesIn source)
        {
           return AutoMapper.Mapper.Map<InstructorWithCoursesIn, Instructor>(source);
        }
    }
}
