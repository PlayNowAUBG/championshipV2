using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IScheduleRepository
    {
        Schedule GetModel();
        void AddNewSchedule(Schedule schedule);
        Schedule GetTeamSchedule(Guid teamId);
        Schedule GetPlayerSchedule(Guid playerId);
        Schedule GetPlayFieldSchedule(Guid playFieldId);
        Schedule GetScheduleByDayId(Guid dayId);
        Day GetDayById(Guid dayId);

    }
}