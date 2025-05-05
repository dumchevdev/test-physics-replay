using UnityEngine;

namespace Game
{
    internal sealed class VelocityProcessorComponent : IFixedUpdateable
    {
        private readonly UnitData _unitData;
        private readonly Rigidbody2D _rigidbody;

        internal VelocityProcessorComponent(UnitData unitData, Rigidbody2D rigidbody)
        {
            _unitData = unitData;
            _rigidbody = rigidbody;
        }
        
        void IFixedUpdateable.FixedUpdateInternal()
        {
            _rigidbody.linearVelocity = _unitData.FrameVelocity;
        }
    }
}