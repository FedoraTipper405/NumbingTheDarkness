using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage; // Assign a full-screen UI Image in the Inspector
    [SerializeField] private float fadeInDuration = 1.0f; // Duration of fade-in in seconds
    [SerializeField] private float fadeOutDuration = 1.0f; // Duriation of fade-out in seconds

    private void Start()
    {
        if (fadeImage == null)
        {
            Debug.LogError("FadeImage is not assigned. Please assign a UI Image.");
        }
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0, fadeInDuration)); // Fade from black to transparent
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1, fadeOutDuration)); // Fade from transparent to black
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        if (fadeImage == null) yield break;

        Color color = fadeImage.color;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            fadeImage.color = color;
            yield return null;
        }

        // Ensure final alpha is set
        color.a = endAlpha;
        fadeImage.color = color;
    }
}