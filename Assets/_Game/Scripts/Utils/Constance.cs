using UnityEngine;

namespace Game
{
    internal static class Constance
    {
        internal static class Layers
        {
            internal const string GroundLayer = "Ground";
            internal const string DeathLayer = "Death";
        }
        
        internal static class Names
        {
            internal const string Player = "Player";
            internal const string Clone = "Clone";
        }
        
        internal static class Inputs
        {
            internal const string HorizontalAxis = "Horizontal";
            internal const string JumpAxis = "Jump";
            internal const KeyCode SpeedBoostKey = KeyCode.LeftShift;
            internal const KeyCode CloneCreationKey = KeyCode.R;
            internal const KeyCode ColorUpdatedKey = KeyCode.C;
        }
        
        internal static class Units
        {
            internal const string UnitPrefabPath = "Units/UnitPrefab";
            internal const string UnitStatsPath = "Units/UnitStats";
        }
    }
}