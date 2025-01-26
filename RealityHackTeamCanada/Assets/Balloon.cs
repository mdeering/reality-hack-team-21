using UnityEngine;

public class Balloon : MonoBehaviour
{
    // Store the available balloon models
    public GameObject[] BalloonModels;
    
//     string[] NormalVision = {
//         "#FF0000", // Red
//         "#00FF00", // Green
//         "#0000FF", // Blue
//         "#FFFF00", // Yellow
//         "#FFA500", // Orange
//         "#800080", // Purple
//         "#00FFFF", // Cyan
//         "#FFC0CB", // Pink
//         // "#808080", // Gray
//         // "#000000"  // Black
//     };

//     // Green-weak Friendly
//     string[] Deuteranomaly = {
//         "#E6194B", // Reddish
//         "#3CB44B", // Greenish
//         "#FFE119", // Yellow
//         "#4363D8", // Blue
//         "#F58231", // Orange
//         "#911EB4", // Purple
//         "#42D4F4", // Lighter Cyan
//         "#F032E6", // Magenta
//         "#BFEF45", // Lime-ish
//         "#800000"  // Dark Red
//     };

//     // Red-weak Friendly
// O    string[] Deuteranopia = {
//         "#D73027", // Reddish
//         "#FC8D59", // Salmon/Orange
//         "#FEE090", // Yellow-ish
//         "#E0F3F8", // Light Cyan
//         "#91BFDB", // Bluish
//         "#4575B4", // Deeper Blue
//         "#DF65B0", // Pink/Magenta
//         "#999999", // Gray
//         "#7F0000", // Dark Red
//         "#DDDD00"  // Yellow
//     };

    void Start()
    {
        // Get the Renderer component from the new cube
        var renderer = GetComponent<Renderer>();

        // Set the color of the new cube
        renderer.material.color = Color.red;
    }
}
