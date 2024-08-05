using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class TurnService : ITurnService
    {
        private readonly ITurnRepository _turnRepository;
        public TurnService(ITurnRepository turnRepository)
        {
            _turnRepository=turnRepository; 
        }
        public async Task<List<Turn>> GetAllTurnsAsync()
        {
            return await _turnRepository.GetAllTurnsAsync();
        }

        public async Task<Turn> GetTurnByHourAsync(int hour)
        {
           return await _turnRepository.GetTurnByHourAsync(hour);
        }
        public async Task<Turn> AddTurnAsync(Turn t)
        {
           return await _turnRepository.AddTurnAsync(t);
        }
        public async Task<Turn> UpdateTurnAsync(int id,Turn t)
        {
           return await _turnRepository.UpdateTurnAsync(id,t);
        }

        public async Task DeleteTurnAsync(int id)
        {
           await _turnRepository.DeleteTurnAsync(id);
        }

        public async Task<Turn> GetTurnByIdAsync(int id)
        {
            return await _turnRepository.GetTurnByIdAsync(id);
        }
    }
}
