using UnityEngine;

namespace Game.Units.InputHandlers
{
    internal sealed class CloneCreatedInputHandler : IInputHandler
    {
        private readonly InputSystem _inputSystem;
        private readonly UnitBehaviour _behaviour;
        private readonly CloneFactory _cloneFactory;
        private readonly Vector2 _spawnPoint;

        internal CloneCreatedInputHandler(InputSystem inputSystem, UnitBehaviour behaviour, CloneFactory cloneFactory, Vector2 spawnPoint)
        {
            _inputSystem = inputSystem;
            _behaviour = behaviour;
            _cloneFactory = cloneFactory;
            _spawnPoint = spawnPoint;

            _inputSystem.OnCloneCreated += OnCloneCreated;
        }

        private void OnCloneCreated()
        {
            _cloneFactory.InstantiateClone();
            _behaviour.SetPosition(_spawnPoint);
        }

        public void Dispose()
        {
            _inputSystem.OnCloneCreated -= OnCloneCreated;
        }
    }
}