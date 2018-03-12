using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Outbound;

namespace JeffCoUniversity.Common.DTOAssemblers
{
    public sealed class InstructorDTOAssembler : DTOAssembler<InstructorOut,Instructor>
    {
        public override InstructorOut AssembleDTO(Instructor source)
        {
            return AutoMapper.Mapper.Map<Instructor, InstructorOut>(source);
        }
    }
}
