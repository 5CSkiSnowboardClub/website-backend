using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Common.Data;

namespace api.Dao
{
    public interface IDatabaseService
    {
        public Task<IEnumerable<MemberType>> SelectMemberTypes();
    }
}
