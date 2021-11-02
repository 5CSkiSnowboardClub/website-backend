using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Services;
using api.Common.Data;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IMemberService _memberService;

        public MemberController(
            ILogger<MemberController> logger,
            IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        // Dev method 
        [HttpGet("/gettypes")]
        public async Task<IEnumerable<MemberType>> GetMemberTypes()
        {
            var memberTypes = await _memberService.GetMemberTypes();

            return memberTypes;
        }

        /*
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */
    }
}
