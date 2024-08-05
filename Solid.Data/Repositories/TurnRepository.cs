using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{

    public class TurnRepository : ITurnRepository
    {
        private readonly DataContext _dataContext;
        public TurnRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
        }

        public async Task<List<Turn>> GetAllTurnsAsync()
        {
            return await _dataContext.Turns
                .Include(t => t.Doctor)
                .Include(t => t.Patient)
                .ToListAsync();
        }

        public async Task<Turn> GetTurnByHourAsync(int hour)
        {
            return await _dataContext.Turns
                .Include(t => t.Doctor)
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(t => t.Hour == hour);
        }

        public async Task<Turn> GetTurnByIdAsync(int id)
        {
            return await _dataContext.Turns
                .Include(t => t.Doctor)
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Turn> AddTurnAsync(Turn t)
        {
            _dataContext.Turns.Add(t);
            await _dataContext.SaveChangesAsync();

            // שליפת הנתונים המלאה כולל ה-Doctor וה-Patient לאחר ההוספה
            return await GetTurnByIdAsync(t.Id);
        }

        public async Task<Turn> UpdateTurnAsync(int id, Turn turn)
        {
            var existingTurn = await _dataContext.Turns
                .Include(t => t.Doctor)
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTurn != null)
            {
                existingTurn.Date = turn.Date;
                existingTurn.Hour = turn.Hour;
                existingTurn.TreatmentDuration = turn.TreatmentDuration;
                existingTurn.PatientId = turn.PatientId != 0 ? turn.PatientId : existingTurn.PatientId;
                existingTurn.DoctorId = turn.DoctorId != 0 ? turn.DoctorId : existingTurn.DoctorId;

                await _dataContext.SaveChangesAsync();
            }

            return await GetTurnByIdAsync(id); // שליפת הנתונים המלאה לאחר עדכון
        }

        public async Task DeleteTurnAsync(int id)
        {
            var t = await _dataContext.Turns.FirstOrDefaultAsync(t => t.Id == id);
            _dataContext.Turns.Remove(t);
            await _dataContext.SaveChangesAsync();
        }
    }
}