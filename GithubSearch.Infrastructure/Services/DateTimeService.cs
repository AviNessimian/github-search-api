using GithubSearch.Core.Contracts;
using System;

namespace GithubSearch.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
