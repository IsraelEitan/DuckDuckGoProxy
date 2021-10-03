using DuckDuckGo.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DuckDuckGo.Application.Interfaces
{
    public interface IDuckDuckGoAPIService
    {
        public Task<List<RelatedTopic>> GetRelatedTopics(string queryParam);
        public Task SaveUserQueries(List<UserQuery> queries);

        public Task<List<UserQuery>> GetUserQueries();
    }
}
