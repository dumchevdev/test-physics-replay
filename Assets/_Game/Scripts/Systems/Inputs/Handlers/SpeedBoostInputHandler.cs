using System.Collections;
using UnityEngine;

namespace Game
{
    internal sealed class SpeedBoostInputHandler : IInputHandler
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;
        private readonly UnitBehaviour _behaviour;

        internal SpeedBoostInputHandler(PlayerData playerData, InputSystem inputSystem, UnitBehaviour behaviour)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            _behaviour = behaviour;

            _inputSystem.OnSpeedBoost += OnSpeedBoost;
            _inputSystem.OnCloneCreated += OnReset;
            _behaviour.OnDied += OnReset;
        }

        private void OnSpeedBoost()
        {
            if (_playerData.BoostBlocked) return;
            _behaviour.StartCoroutine(OnSpeedBoostInternal());
        }
        
        private IEnumerator OnSpeedBoostInternal()
        {
            _playerData.BoostBlocked = true;
            _playerData.CurrentSpeed *= _playerData.Stats.SpeedBoostMod;

            var firstColor = ColorExtension.GenerateColor();
            var secondColor = ColorExtension.GenerateColor();

            for (float timer = 0; timer <= _playerData.Stats.SpeedBoostDuration; timer += Time.deltaTime)
            {
                float intervalProgress = timer % _playerData.Stats.SpeedBoostAnimationInterval / _playerData.Stats.SpeedBoostAnimationInterval;
        
                if (Mathf.Approximately(intervalProgress, 0f))
                    (firstColor, secondColor) = (secondColor, firstColor);

                _behaviour.SetColor(Color.Lerp(firstColor, secondColor, intervalProgress));
                
                yield return null;
            }

            OnReset();
        }
        
        private void OnReset()
        {
            _behaviour.SetColor(_playerData.Color);
            _behaviour.StopAllCoroutines();
            _playerData.BoostBlocked = false;
            _playerData.CurrentSpeed = _playerData.Stats.BaseSpeed;
        }

        public void Dispose()
        {
            _inputSystem.OnSpeedBoost -= OnSpeedBoost;
            _behaviour.OnDied -= OnReset;
        }
    }
}