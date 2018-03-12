using JeffCoUniversity.Domain.Entities;
using JeffCoUniversity.DTO.Outbound;
using System.Collections.Generic;

namespace JeffCoUniversity.Common.DTOAssemblers
{
    public sealed class InstructorsDTOAssembler : DTOAssembler<IEnumerable<InstructorOut>, IEnumerable<Instructor>>
    {
        public override IEnumerable<InstructorOut> AssembleDTO(IEnumerable<Instructor> source)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Instructor>, IEnumerable<InstructorOut>>(source);
        }
    }
}
