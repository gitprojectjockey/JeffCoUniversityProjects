﻿using System.Threading.Tasks;
using JeffCoUniversity.Data.Core.Repositories;

namespace JeffCoUniversity.Data.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }
        IInstructorRepository Instructors { get; }

        Task<int> Complete();
        void Dispose();
    }
}