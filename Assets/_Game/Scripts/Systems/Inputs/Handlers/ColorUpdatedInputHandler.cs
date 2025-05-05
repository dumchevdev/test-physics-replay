namespace Game
{
    internal sealed class ColorUpdatedInputHandler : IInputHandler
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;
        private readonly UnitBehaviour _behaviour;

        internal ColorUpdatedInputHandler(PlayerData playerData, InputSystem inputSystem, UnitBehaviour behaviour)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            _behaviour = behaviour;

            _inputSystem.OnColorUpdated += OnColorUpdated;
        }

        private void OnColorUpdated()
        {
            if (_playerData.BoostBlocked) return;
            
            var color = ColorExtension.GenerateColor();
            _playerData.Color = color;
            _behaviour.SetColor(color);
        }

        public void Dispose()
        {
            _inputSystem.OnColorUpdated -= OnColorUpdated;
        }
    }
}