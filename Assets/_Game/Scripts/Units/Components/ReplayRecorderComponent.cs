namespace Game
{
    internal sealed class ReplayRecorderComponent : IFixedUpdateable
    {
        private readonly PlayerData _playerData;
        private readonly ReplaySystem _replaySystem;

        public ReplayRecorderComponent(PlayerData playerData, ReplaySystem replaySystem)
        {
            _playerData = playerData;
            _replaySystem = replaySystem;
        }

        void IFixedUpdateable.FixedUpdateInternal()
        {
            _replaySystem.Record(_playerData.FrameVelocity);
        }
    }
}