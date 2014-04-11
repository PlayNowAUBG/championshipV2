using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface ITeamRepository
    {
        void AddNewTeam(Team team);
        Team GetModel();
        ICollection<Team> GetAllTeams();
        void SaveChanges();
        Team FindTeamByName(string teamName);
        bool CheckTeamPass(string teamPass, Team playerTeam);
    }
}