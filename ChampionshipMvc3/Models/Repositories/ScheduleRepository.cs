using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Enums;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {

        public Schedule GetModel()
        {
            return new Schedule();
        }

        public void AddNewSchedule(Schedule schedule, int StartHour, int EndHour)
        {
            AddDaysToSchedule(schedule, StartHour, EndHour);
            
            RepositoryBase.DataContext.Schedules.InsertOnSubmit(schedule);
        }

        public Schedule GetTeamSchedule(Guid teamId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetPlayerSchedule(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetPlayFieldSchedule(Guid playFieldId)
        {
            Playfield currentPlayfield = RepositoryBase.DataContext.Playfields
                .Where(p => p.PLayfieldID == playFieldId)
                .FirstOrDefault();

            return currentPlayfield.Schedule;
        }

        public Schedule GetScheduleByDayId(Guid dayId)
        {
            Guid scheduleId = RepositoryBase.DataContext.Days
                                            .Where(d => d.DaysID == dayId)
                                            .Select(s => s.ScheduleID)
                                            .FirstOrDefault();

            Schedule schedule = RepositoryBase.DataContext.Schedules
                                                .Where(s => s.ScheduleID == scheduleId)
                                                .FirstOrDefault();

            return schedule;
        }

        public Day GetDayById(Guid dayId)
        {
            Day day = RepositoryBase.DataContext.Days
                                    .Where(d => d.DaysID == dayId)
                                    .FirstOrDefault();

            return day;
        }

        private void AddDaysToSchedule(Schedule schedule, int StartHour, int EndHour)
        {
            for (int dayIndex = 0; dayIndex < 7; dayIndex++)
            {
                Day newDay = new Day();
                newDay.DaysID = Guid.NewGuid();
                newDay.DayName = ((DaysEnum)dayIndex).ToString();
                newDay.DayOrderID = dayIndex+1;
                newDay.Schedule = schedule;

                AddHoursToDay(newDay, StartHour, EndHour);

                RepositoryBase.DataContext.Days.InsertOnSubmit(newDay);
            }
        }

        private void AddHoursToDay(Day currentDay, int StartHour, int EndHour)
        {

            for (int hourIndex = StartHour; hourIndex < EndHour; hourIndex++)
            {
                StringBuilder hourLabel = new StringBuilder();
                hourLabel.AppendFormat("{0} - {1}", hourIndex, hourIndex + 1);
                
                Hour hour = new Hour();
                hour.Day = currentDay;
                hour.HourID = Guid.NewGuid();
                hour.HourLabel = hourLabel.ToString();
                hour.HourIndex = hourIndex; 

                RepositoryBase.DataContext.Hours.InsertOnSubmit(hour);
            }
        }

        public void SaveChanges()
        {
            ChangeSet cs = RepositoryBase.DataContext.GetChangeSet();
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}