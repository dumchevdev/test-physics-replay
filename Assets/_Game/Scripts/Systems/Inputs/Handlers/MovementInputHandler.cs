using UnityEngine;

namespace Game
{
    internal sealed class MovementInputHandler : IInputHandler
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;

        internal MovementInputHandler(PlayerData playerData, InputSystem inputSystem)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            
            _inputSystem.OnMove += OnMove;
        }

        private void OnMove(float direction)
        {
            var targetVelocity = direction * _playerData.CurrentSpeed;
            var acceleration = _playerData.Stats.Acceleration * Time.fixedDeltaTime;
            
            _playerData.FrameVelocity.x = Mathf.MoveTowards(_playerData.FrameVelocity.x, targetVelocity, acceleration);
        }

        public void Dispose()
        {
            _inputSystem.OnMove -= OnMove;
        }
    }
}