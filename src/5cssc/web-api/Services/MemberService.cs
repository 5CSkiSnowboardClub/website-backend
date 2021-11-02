using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using api.Common.Data;
using api.Dao;

namespace api.Services
{
    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;
        private readonly IDatabaseService _database;

        public MemberService(
            ILogger<MemberService> logger,
            IDatabaseService database)
        {
            _logger = logger;
            _database = database;
        }

        public async Task<IEnumerable<MemberType>> GetMemberTypes()
        {
            var memberTypes = await _database.SelectMemberTypes();

            return memberTypes;
        }
    }
}
