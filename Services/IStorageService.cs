using BattleshipGoogleCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGoogleCloud.Services
{
    public interface IStorageService
    {
        Task<bool> SaveGame(Game game, string name);
        Task<Game> GetGame(string name);
    }
}
