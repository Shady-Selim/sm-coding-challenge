using System.Collections.Generic;
using System.Threading.Tasks;
using sm_coding_challenge.Models;

namespace sm_coding_challenge.Services.DataProvider
{
    public interface IDataProvider
    {
        Task<ResponseModel> GetPlayers(IList<string> id, int flag);
    }
}
