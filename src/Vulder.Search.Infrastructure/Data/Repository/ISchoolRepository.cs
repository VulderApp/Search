using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vulder.Search.Core.ProjectAggregate.School;

namespace Vulder.Search.Infrastructure.Data.Repository
{
    public interface ISchoolRepository
    {
        Task<List<School>> Find(string input);
        Task<School> Get(Guid id);
        Task Create(School school);
        Task Delete(Guid id);
        Task Update(School school);
    }
}