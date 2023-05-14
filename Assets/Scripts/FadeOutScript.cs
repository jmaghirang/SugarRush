using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour
{
    public float fadeDuration = 2.0f;
    public Image imageToFade;

    private void Start()
    {
        // Call the FadeOut function after the specified duration
        Invoke("FadeOut", fadeDuration);
    }

    private void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        // Get the starting color of the image
        Color startColor = imageToFade.color;

        // Set the alpha value of the color to 1 (fully opaque)
        startColor.a = 1.0f;

        // Loop until the alpha value reaches 0 (fully transparent)
        while (startColor.a > 0.0f)
        {
            // Reduce the alpha value of the color over time
            startColor.a -= Time.deltaTime / fadeDuration;

            // Set the color of the image to the new color with reduced alpha value
            imageToFade.color = startColor;

            // Wait for a frame before continuing the loop
            yield return null;
        }

        // Disable the image object after the fadeout is complete
        imageToFade.gameObject.SetActive(false);
    }
}