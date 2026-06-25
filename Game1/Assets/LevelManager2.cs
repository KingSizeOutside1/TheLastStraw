using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelManager2 : MonoBehaviour
{
    private enum Stage
    {
        Logins,
        News,
        Complete
    }
    private Stage currentStage = Stage.Logins;

    [Header("Stage 1: Login Cards")]
    public LoginCard[] loginCards;

    [Header("Stage 2: News")]
    public NewsCard[] newsCards;

    private int currentCardIndex = 0;

    [Header("Shared UI Header")]
    public TMP_Text titleText;
    public TMP_Text subtitleText;
    public TMP_Text bodyText;
    public TMP_Text taskCounterText;
    public TMP_Text failCounterText;
    public TMP_Text stageLabelText;

    [Header("Buttons")]
    public Button yesButton;
    public Button noButton;

    [Header("Feedback Timing")]
    public float feedbackDisplayTime = 2f;

    private FailTracker failTracker;


    void Start() //runs the program automatically when the scene is loaded.
    {
        failTracker = FailTracker.Instance; // pulling FailTracker from level 1 and stores it in my own variable.

        if (failTracker == null) // DEBUG FIX: If someone directly enters inside the level 2 scene the failtracker.instance wont exist yet, this creates a new backup for us.
        {
            Debug.LogWarning("No FailTracker.Instance found - was Level 1 skipped? Creating a fallback.");
            GameObject fallback = new GameObject("FailTracker_Fallback");
            failTracker = fallback.AddComponent<FailTracker>();
        }

        currentStage = Stage.Logins; //resets btoh their starting values, so the level behinds at the first login card no matter what.
        currentCardIndex = 0;
        ShowCard();
    }

    void ShowCard()
    {
        if (currentStage == Stage.Logins) // only run this when were on the logins stage
        {
            if (currentCardIndex >= loginCards.Length) // Checks how many logincards we have assigned and >= checks if weve run out of cards, If currentCardIndex is 5 and there are only 5 cards, we've gone past the end.
            {
                currentStage = Stage.News; // switch to the news stage and reset the card index to 0
                currentCardIndex = 0;
                ShowCard();
                return;
            }
            ShowLoginCard(loginCards[currentCardIndex]); // DEBUG: currentCardIndex is looking at the card we are currently on, the >= above it checks if weve run out, [currentcardindex] is the actual card we are showing, and we pick out the ones remaining.
        }
        else if (currentStage == Stage.News)
        {
            if (currentCardIndex >= newsCards.Length) // same as for logins, checking how many we have left
            {
                ShowLevelComplete();
                return;
            }
            ShowNewsCard(newsCards[currentCardIndex]);
        }
    }



}