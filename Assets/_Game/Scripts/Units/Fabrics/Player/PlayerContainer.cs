using System;
using UnityEngine;

namespace Game
{
    internal sealed class PlayerContainer : IDisposable
    {
        private readonly UnitBehaviour _behaviour;
        private readonly Vector2 _spawnPoint;
        private readonly InputHandlersContainer _inputHandlersContainer;

        public PlayerContainer(UnitBehaviour behaviour, Vector2 spawnPoint, InputHandlersContainer inputHandlersContainer)
        {
            _behaviour = behaviour;
            _spawnPoint = spawnPoint;
            _inputHandlersContainer = inputHandlersContainer;

            _behaviour.OnDied += OnRespawn;
        }

        private void OnRespawn()
        {
            _behaviour.SetPosition(_spawnPoint);
        }

        public void Dispose()
        {
            _inputHandlersContainer.Dispose();
            _behaviour.OnDied -= OnRespawn;
        }
    }
}