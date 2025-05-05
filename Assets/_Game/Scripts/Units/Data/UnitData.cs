using UnityEngine;

namespace Game
{
    internal abstract class UnitData
    {
        internal UnitStats Stats { get; }
        
        internal Color Color;
        internal Vector2 FrameVelocity;
        internal bool Grounded;

        internal UnitData(UnitStats stats)
        {
            Stats = stats;
        }
    }
}