using UnityEngine;
using UnityEngine.UI;

public class UIParallaxEffect : MonoBehaviour
{
    public RectTransform[] backgrounds; // Array of all the backgrounds to be parallaxed
    public float[] parallaxSpeeds; // Speed at which each background moves
    public float smoothing = 1f; // How smooth the parallax effect should be. Make sure to set this above 0

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Move the background
            float parallax = parallaxSpeeds[i] * Time.deltaTime;
            backgrounds[i].anchoredPosition += new Vector2(parallax, 0);

            // If the background has moved too far, reset its position
            if (backgrounds[i].anchoredPosition.x >= 1920) // Adjust this value based on your background size
            {
                backgrounds[i].anchoredPosition = new Vector2(-1920, backgrounds[i].anchoredPosition.y); // Adjust this value based on your background size
            }
        }
    }
}
