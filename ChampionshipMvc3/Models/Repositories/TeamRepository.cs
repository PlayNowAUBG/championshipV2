using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public void AddNewTeam(Team team)
        {
            team.TeamID = Guid.NewGuid();
            RepositoryBase.DataContext.Teams.InsertOnSubmit(team);
            SaveChanges();
        }

        public Team GetModel()
        {
            return new Team();
        }

        public ICollection<Team> GetAllTeams()
        {
            return RepositoryBase.DataContext.Teams.ToList();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }


        public Team FindTeamByName(string teamName)
        {
            ICollection<Team> teams = RepositoryBase.DataContext.Teams.ToList();
            Team playerTeam = teams.FirstOrDefault(t => t.TeamName == teamName);

            return playerTeam;
        }


        public bool CheckTeamPass(string teamPass, Team playerTeam)
        {
            if (playerTeam.TeamPassword.Trim() == teamPass)
            {
                return true;
            }

            return false;
        }
    }
}