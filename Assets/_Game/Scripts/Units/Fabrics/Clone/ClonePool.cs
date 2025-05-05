using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    internal sealed class ClonePool : IDisposable
    {
        private readonly UnitStats _stats;
        private readonly UnitBehaviour _prefab;
        private readonly Stack<CloneContainer> _pool;
        private readonly HashSet<CloneContainer> _activatedClones;

        internal ClonePool(UnitStats stats)
        {
            _stats = stats;
            _pool = new Stack<CloneContainer>();
            _activatedClones = new HashSet<CloneContainer>();
            _prefab = Resources.Load<UnitBehaviour>(Constance.Units.UnitPrefabPath);
        }

        internal CloneContainer Get()
        {
            if (_pool.TryPop(out var cloneContainer))
            {
                _activatedClones.Add(cloneContainer);
                return cloneContainer;
            }
    
            var cloneData = new CloneData(_stats);
            var behaviour = Object.Instantiate(_prefab);
            ConfigureBehaviour(cloneData, behaviour);
    
            cloneContainer = new CloneContainer(cloneData, behaviour, this);
            _activatedClones.Add(cloneContainer);
            
            return cloneContainer;
        }

        internal void Return(CloneContainer cloneContainer)
        {
            _activatedClones.Remove(cloneContainer);
            
            cloneContainer.SetActive(false);
            _pool.Push(cloneContainer);
            
        }

        private void ConfigureBehaviour(CloneData cloneData, UnitBehaviour behaviour)
        {
            behaviour.name = Constance.Names.Clone;

            var circleCollider = behaviour.GetComponent<CircleCollider2D>();
            var groundChecker = new GroundCheckerComponent(cloneData, behaviour.transform, circleCollider.radius);
            
            var replayPlaybackComponent = new ReplayPlaybackComponent(cloneData);
            var gravityComponent = new GravityProcessorComponent(cloneData);
            
            var rigidBody = behaviour.GetComponent<Rigidbody2D>();
            var applyVelocityComponent = new VelocityProcessorComponent(cloneData, rigidBody);
            
            behaviour.Construct(
                groundChecker, 
                replayPlaybackComponent, 
                gravityComponent, 
                applyVelocityComponent);
        }

        public void Dispose()
        {
            foreach (var clone in _pool)
                clone.Dispose();

            foreach (var clone in _activatedClones)
                clone.Dispose();

            _pool.Clear();
        }
    }
}