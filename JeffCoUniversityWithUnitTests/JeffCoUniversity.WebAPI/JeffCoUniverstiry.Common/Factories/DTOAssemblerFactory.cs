using JeffCoUniversity.Common.DTOAssemblers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeffCoUniversity.Common.Factories
{
    public static class DTOAssemblerFactory<TDto,TEntity> where TDto : class where TEntity : class
    {
        public static DTOAssembler<TDto,TEntity> CreateAssembler()
        {

            if (typeof(TDto).Name == "InstructorOut")
            {
                return new InstructorDTOAssembler() as DTOAssembler<TDto, TEntity>;
            }
            else if (typeof(TDto).Name == "InstructorWithCoursesOut")
            {
                return new InstructorWithCoursesDTOAssembler() as DTOAssembler<TDto, TEntity>;
            }
            else if (typeof(TDto).Name == "CoursesOut")
            {
                return new CourseDTOAssembler() as DTOAssembler<TDto, TEntity>;
            }
            else if (IsDTOCollection(typeof(TDto)) && typeof(TDto).GenericTypeArguments.Single().Name == "InstructorOut")
            {
                return new InstructorsDTOAssembler() as DTOAssembler<TDto, TEntity>;
            }
            else if (IsDTOCollection(typeof(TDto)) && typeof(TDto).GenericTypeArguments.Single().Name == "InstructorWithCoursesOut")
            {
                return new InstructorsWithCoursesDTOAssembler() as DTOAssembler<TDto, TEntity>;
            }
            else if (IsDTOCollection(typeof(TDto)) && typeof(TDto).GenericTypeArguments.Single().Name == "CourseOut")
            {
                return new CoursesDTOAssembler() as DTOAssembler<TDto, TEntity>;
            }
            else
            {
                throw new ArgumentException("DTOAssemblerFactory is unable to create assembler of this type.", typeof(TDto).Name);
            }
        }

        private static bool IsDTOCollection(Type type)
        {
            return type.GetGenericTypeDefinition() == typeof(List<>) || type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
    }
}

