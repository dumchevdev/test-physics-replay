using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(UnitVisual))]
    internal sealed class UnitBehaviour : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private UnitVisual _visual;
        private IFixedUpdateable[] _fixedUpdateables;
        
        internal event Action OnDied;

        internal void Construct(params IFixedUpdateable[] fixedUpdateables)
        {
            _fixedUpdateables = fixedUpdateables;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _visual = GetComponent<UnitVisual>();
        }

        internal void SetColor(Color color)
        {
            _visual.SetColor(color);
        }
        
        internal void SetPosition(Vector2 position)
        {
            _visual.SetEmittingTrail(false);
            transform.position = position;
            _rigidbody.linearVelocity = Vector2.zero;
            _visual.SetEmittingTrail(true);
        }
        
        private void FixedUpdate()
        {
            foreach (var component in _fixedUpdateables)
            {
                component.FixedUpdateInternal();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(Constance.Layers.DeathLayer))
                OnDied?.Invoke();
        }
    }
}