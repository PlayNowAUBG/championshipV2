using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.DataContext;

namespace ChampionshipMvc3.Models.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public void AddNewPlayer(Player player)
        {
            player.PlayerID = Guid.NewGuid();
            RepositoryBase.DataContext.Players.InsertOnSubmit(player);
            SaveChanges();
        }

        public Player GetModel()
        {
            return new Player();
        }

        public ICollection<Player> GetAllPlayers()
        {
            return RepositoryBase.DataContext.Players.ToList();
        }

        public ICollection<Player> GetAllUnapprovedPlayers()
        {
            return RepositoryBase.DataContext.Players
                                 .Where(p => p.IsApproved == false).ToList();
        }

        public Player GetPlayerById(Guid playerId)
        {
            return RepositoryBase.DataContext.Players
                                 .Where(p => p.PlayerID == playerId).FirstOrDefault();
        }

        public void ApprovePlayer(Guid playerId)
        {
            var player = this.GetPlayerById(playerId);
            player.IsApproved = true;
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}