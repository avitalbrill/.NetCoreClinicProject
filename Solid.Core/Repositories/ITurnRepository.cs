using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface ITurnRepository
    {
        Task<List<Turn>> GetAllTurnsAsync();
        Task<Turn> GetTurnByHourAsync(int hour);
        Task<Turn> AddTurnAsync(Turn t);
        Task<Turn> UpdateTurnAsync(int id, Turn turn);
        Task DeleteTurnAsync(int id);
        Task<Turn> GetTurnByIdAsync(int id);
    }
}
