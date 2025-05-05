using System;
using System.IO;
using UnityEngine;

namespace Game
{
    internal sealed class ReplaySystem : IDisposable
    {
        private MemoryStream _memoryStream;
        private BinaryWriter _binaryWriter;
        
        internal ReplaySystem()
        {
            _memoryStream = new MemoryStream();
            _binaryWriter = new BinaryWriter(_memoryStream);
        }
        
        internal void Record(Vector2 velocity)
        {
            _binaryWriter.Write(velocity.x);
            _binaryWriter.Write(velocity.y);
        }

        internal void Copy(MemoryStream memoryStream)
        {
            _memoryStream.WriteTo(memoryStream);
            _memoryStream.SetLength(0);
        }

        public void Dispose()
        {
            _memoryStream.Dispose();
            _memoryStream = null;
            
            _binaryWriter.Dispose();
            _binaryWriter = null;
        }
    }
}