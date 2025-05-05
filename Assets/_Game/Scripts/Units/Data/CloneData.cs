using System;
using System.IO;

namespace Game
{
    internal class CloneData : UnitData, IDisposable
    {
        internal MemoryStream MemoryStream { get; }
        internal BinaryReader BinaryReader { get; }
        
        internal CloneData(UnitStats stats) : base(stats)
        {
            MemoryStream = new MemoryStream();
            BinaryReader = new BinaryReader(MemoryStream);
        }

        public void Dispose()
        {
            MemoryStream.Dispose();
            BinaryReader.Dispose();
        }
    }
}