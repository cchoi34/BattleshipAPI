using BattleshipGoogleCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BattleshipGoogleCloud.Services
{
    public class InMemoryStorageService : IStorageService
    {
        private readonly SemaphoreSlim _semaphore;
        private readonly Dictionary<string, Game> _storage;
        public InMemoryStorageService()
        {
            _storage = new Dictionary<string, Game>();
            _semaphore = new SemaphoreSlim(1);
        }
        public async Task<Game> GetGame(string name)
        {
            await _semaphore.WaitAsync();
            
            _storage.TryGetValue(name, out Game game);

            _semaphore.Release();

            return game;
        }

        public async Task<bool> SaveGame(Game game, string name)
        {
            await _semaphore.WaitAsync();
            
            _storage[name] = game;

            _semaphore.Release();

            return true;
        }
    }
}
