using UnityEngine;

public class FadeTester : MonoBehaviour
{
    private ScreenFader screenFader;

    private void Start()
    {
        // Find the ScreenFader component in the scene
        screenFader = FindObjectOfType<ScreenFader>();

        if (screenFader == null)
        {
            Debug.LogError("No ScreenFader found in the scene! Please add the ScreenFader script to a GameObject.");
        }
    }

    private void Update()
    {
        // Press Q to test Fade In
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Fading In");
            screenFader?.FadeIn();
        }

        // Press E to test Fade Out
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Fading Out");
            screenFader?.FadeOut();
        }
    }
}