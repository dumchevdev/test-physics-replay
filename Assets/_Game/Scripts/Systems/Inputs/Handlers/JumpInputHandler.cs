namespace Game
{
    internal sealed class JumpInputHandler : IInputHandler
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;

        internal JumpInputHandler(PlayerData playerData, InputSystem inputSystem)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            
            _inputSystem.OnJump += OnJump;
        }

        private void OnJump()
        {
            if (_playerData.Grounded)
            {
                _playerData.FrameVelocity.y = _playerData.Stats.JumpPower;
            }
        }

        public void Dispose()
        {
            _inputSystem.OnJump -= OnJump;
        }
    }
}