using JeffCoUniversity.Common.EntityAssemblers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeffCoUniversity.Common.Factories
{
    public static class EntityAssemblerFactory<TEntity, TDto> where TEntity : class where TDto : class
    {
        public static EntityAssembler<TEntity, TDto> CreateAssembler()
        {
            if (typeof(TDto).Name == "InstructorWithCoursesIn")
            {
                return new InstructorEntityAssembler() as EntityAssembler<TEntity, TDto>;
            }
            else if (typeof(TDto).Name == "CourseIn")
            {
                return new CourseEntityAssembler() as EntityAssembler<TEntity, TDto>;
            }
            else if (IsEntityCollection(typeof(TDto)) && typeof(TDto).GenericTypeArguments.Single().Name == "InstructorWithCoursesIn")
            {
                return new InstructorsEntityAssembler() as EntityAssembler<TEntity, TDto>;
            }
            else
            {
                throw new ArgumentException("EntityAssemblerFactory is unable to create assembler of this type.", typeof(TDto).Name);
            }
        }

        private static bool IsEntityCollection(Type type)
        {
            return type.GetGenericTypeDefinition() == typeof(List<>) || type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
    }
}

