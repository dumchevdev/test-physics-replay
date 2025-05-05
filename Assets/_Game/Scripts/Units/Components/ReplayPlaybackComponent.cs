using System.IO;
using UnityEngine;

namespace Game
{
    internal class ReplayPlaybackComponent : IFixedUpdateable
    {
        private readonly CloneData _cloneData;

        internal ReplayPlaybackComponent(CloneData cloneData)
        {
            _cloneData = cloneData;
        }

        void IFixedUpdateable.FixedUpdateInternal()
        {
            var memoryStream = _cloneData.MemoryStream;
            var binaryReader = _cloneData.BinaryReader;
            
            if (memoryStream.Position < memoryStream.Length)
            {
                UpdateFrameVelocity(binaryReader);
            }
            else
            {
                _cloneData.FrameVelocity.x = 0;
            }
        }
        
        private void UpdateFrameVelocity(BinaryReader binaryReader)
        {
            float velocityX = binaryReader.ReadSingle();
            float velocityY = binaryReader.ReadSingle();
    
            Vector2 nextFrameVelocity = new Vector2(velocityX, 
                _cloneData.Grounded ? velocityY : _cloneData.FrameVelocity.y);
    
            _cloneData.FrameVelocity = nextFrameVelocity;
        }
    }
}