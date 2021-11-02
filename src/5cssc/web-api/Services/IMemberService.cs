using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Common.Data;

namespace api.Services
{
    public interface IMemberService
    {
        public Task<IEnumerable<MemberType>> GetMemberTypes();
    }
}
