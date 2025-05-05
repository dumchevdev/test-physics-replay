using UnityEngine;

namespace Game
{
    internal sealed class GravityProcessorComponent : IFixedUpdateable
    {
        private readonly UnitData _unitData;

        internal GravityProcessorComponent(UnitData unitData)
        {
            _unitData = unitData;
        }
        
        void IFixedUpdateable.FixedUpdateInternal()
        {
            _unitData.FrameVelocity.y = _unitData.Grounded && _unitData.FrameVelocity.y <= 0f
                ? _unitData.Stats.GroundingForce
                : Mathf.MoveTowards(_unitData.FrameVelocity.y, -_unitData.Stats.MaxFallSpeed, _unitData.Stats.FallAcceleration * Time.fixedDeltaTime);
        }
    }
}