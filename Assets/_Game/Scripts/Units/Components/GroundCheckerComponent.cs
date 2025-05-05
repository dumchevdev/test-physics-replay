using UnityEngine;

namespace Game
{
    internal sealed class GroundCheckerComponent : IFixedUpdateable
    {
        private readonly UnitData _unitData;
        private readonly Transform _transform;
        private readonly LayerMask _layerMask;
        private readonly Vector2 _checkerOffset;
        
        internal GroundCheckerComponent(UnitData unitData, Transform transform, float colliderRadius)
        {
            _unitData = unitData;
            _transform = transform;
            _layerMask = LayerMask.GetMask(Constance.Layers.GroundLayer);
            _checkerOffset = Vector2.down * (colliderRadius * transform.localScale.y);
        }

        void IFixedUpdateable.FixedUpdateInternal()
        {
            var checkPosition = (Vector2)_transform.position + _checkerOffset;
            _unitData.Grounded = Physics2D.OverlapCircle(checkPosition, _unitData.Stats.GroundCheckerRadius, _layerMask);
        }
    }
}