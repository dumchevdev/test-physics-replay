using UnityEngine;

namespace Game
{
    internal sealed class PlayerData : UnitData
    {
        internal float CurrentSpeed;
        internal bool BoostBlocked;

        public PlayerData(UnitStats stats) : base(stats)
        {
            CurrentSpeed = stats.BaseSpeed;
            BoostBlocked = false;
            Color = Color.black;
        }

    }
}