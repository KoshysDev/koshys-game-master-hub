using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public TMP_Text messageText;
    public float displayDuration = 3f; // Duration in seconds

    private bool isDisplaying;
    private float displayTimer;

    private void Start()
    {
        // Make sure the text component is initially disabled
        messageText.enabled = false;
    }

    private void Update()
    {
        if (isDisplaying)
        {
            // Countdown the timer
            displayTimer -= Time.deltaTime;

            // Check if the timer has expired
            if (displayTimer <= 0f)
            {
                // Hide the text and reset flags
                messageText.enabled = false;
                isDisplaying = false;
            }
        }
    }

    // Call this method to display the text
    public void DisplayText(string text)
    {
        // Set the text content
        messageText.text = text;

        // Enable the text component
        messageText.enabled = true;

        // Set the timer for hiding the text
        displayTimer = displayDuration;
        isDisplaying = true;
    }
}
