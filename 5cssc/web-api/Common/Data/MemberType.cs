using System;
namespace api.Common.Data
{
    public record MemberType
    {
        public int Id { get; init; }
        public string Type { get; init; }
    }
}
