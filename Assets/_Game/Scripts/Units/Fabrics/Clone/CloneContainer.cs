using System;
using System.IO;
using UnityEngine;

namespace Game
{
    internal class CloneContainer : IDisposable
    {
        private readonly CloneData _cloneData;
        private readonly UnitBehaviour _behaviour;
        private readonly ClonePool _clonePool;

        internal CloneContainer(CloneData cloneData, UnitBehaviour behaviour, ClonePool clonePool)
        {
            _cloneData = cloneData;
            _behaviour = behaviour;
            _clonePool = clonePool;

            _behaviour.OnDied += OnDied;
        }

        internal void SetActive(bool active)
        {
            _behaviour.gameObject.SetActive(active);
        }

        internal void SetPosition(Vector2 spawnPoint)
        {
            _behaviour.SetPosition(spawnPoint);
        }
        
        internal void SetColor(Color color)
        {
            _cloneData.Color = color;
            _behaviour.SetColor(color);
        }
        
        internal void Replay(ReplaySystem replaySystem)
        {
            _cloneData.MemoryStream.SetLength(0);
            
            replaySystem.Copy(_cloneData.MemoryStream);
            _cloneData.MemoryStream.Seek(0, SeekOrigin.Begin);
        }
        
        private void OnDied()
        {
            _behaviour.StopAllCoroutines();
            _cloneData.MemoryStream.SetLength(0);
            _clonePool.Return(this);
        }

        public void Dispose()
        {
            _cloneData.Dispose();
            _behaviour.OnDied -= OnDied;
        }
    }
}