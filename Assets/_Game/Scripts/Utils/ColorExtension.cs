using UnityEngine;

namespace Game
{
    internal static class ColorExtension
    {
        internal static Color GenerateColor()
        {
            var randomColor = Color.HSVToRGB(
                Random.Range(0f, 1f),
                Random.Range(0.95f, 1f),
                Random.Range(0.95f, 1f)
            );

            return randomColor;
        }
    }
}