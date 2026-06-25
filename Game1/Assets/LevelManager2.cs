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

    [Header("Login-Only Visuals")]
    public GameObject loginOnlyFields;

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
            Debug.LogWarning("No FailTracker.Instance found - was Level 1 skipped? Creating a fallback."); // logs a warning to the console that the failtracker.instance was not found, and that we are creating a fallback.
            GameObject fallback = new GameObject("FailTracker_Fallback");
            failTracker = fallback.AddComponent<FailTracker>(); // creates a new gameobject called "FailTracker_Fallback" and adds the FailTracker component to it, storing it in the failtracker variable.
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

    void ShowLoginCard(LoginCard card)
    {
        loginOnlyFields.SetActive(true);
        bodyText.rectTransform.sizeDelta = new Vector2(100, 50); // smaller box for more compact login card display
        stageLabelText.text = "Stage 1: Logins";
        titleText.text = card.SiteName;
        subtitleText.text = card.DisplayURL;
        bodyText.text = card.HasPadlockIcon ? "connection secure" : "connection not secure"; // shows a message based on whether the URL is secure or not

        UpdateCounters(loginCards.Length);
    }
    void ShowNewsCard(NewsCard card) //
    {
        loginOnlyFields.SetActive(false);
        bodyText.rectTransform.sizeDelta = new Vector2(400, 50); // bigger box for longer article/post text
        bodyText.rectTransform.anchoredPosition = new Vector2(232, 0); // adjust these numbers to match where it should sit
        stageLabelText.text = "Stage 2: News";

        if (card.DisplayStyle == NewsType.HeadlineArticle)
        {
            titleText.text = card.Headline;
            subtitleText.text = card.SourceName;
            bodyText.text = card.ArticleSnippet;
        }
        else
        {
            titleText.text = card.PosterName;
            subtitleText.text = card.PosterHandle;
            bodyText.text = card.PostCaption;
        }

        UpdateCounters(newsCards.Length);
    }
    void UpdateCounters(int stageLength) // Updates the task and fail counters
    {
        taskCounterText.text = "Task: " + (currentCardIndex + 1) + "/" + stageLength; // +1 because currentCardIndex is 0 based, so we add 1 to make it more human readable
        failCounterText.text = "Fails: " + failTracker.CurrentFails + "/" + failTracker.maxFails; // shows the current number of fails and the max number of fails allowed
        yesButton.interactable = true;
        noButton.interactable = true;
    }

    void ShowLevelComplete()
    {
        currentStage = Stage.Complete; // sets the current stage to complete
        stageLabelText.text = ""; // clears the stage label text
        titleText.text = ""; // shows level complete in the title text
        subtitleText.text = ""; // clears the subtitle text
        bodyText.text = "You have completed the level!"; // shows a message in the

        yesButton.interactable = false; // disables the yes button so the player cannot click it
        noButton.interactable = false; // disables the no button so the player cannot click it
    }

    public void OnYesPressed() { HandleAnswer(true); }
    public void OnNoPressed() { HandleAnswer(false); }

    void HandleAnswer(bool answeredYes) // the value from whichever button the user presses
    {
        yesButton.interactable = false; // disables the yes button so the player cannot click it
        noButton.interactable = false; // disables the no button so the player cannot click it

        bool correctAnswerisYes;
        string feedbackCorrect;
        string feedbackWrong;

        if (currentStage == Stage.Logins)
        {
            LoginCard card = loginCards[currentCardIndex];
            correctAnswerisYes = card.correctAnswerIsYes;  // True if "Yes" is the correct answer, false if "No" is the correct answer
            feedbackCorrect = card.FeedbackCorrect; // Feedback shown if player chooses the correct answer
            feedbackWrong = card.FeedbackWrong; // Feedback shown if player chooses the incorrect answer
        }
        else // Same as LoginCards but for NewsCards.
        {
            NewsCard card = newsCards[currentCardIndex];
            correctAnswerisYes = card.correctAnswerIsYes;
            feedbackCorrect = card.FeedbackCorrect;
            feedbackWrong = card.FeedbackWrong;
        }

        bool isCorrect = (answeredYes == correctAnswerisYes);
        bodyText.text = isCorrect ? feedbackCorrect : feedbackWrong;
        if (!isCorrect) failTracker.RegisterFail(); // if the answer is wrong, register a fail

        failCounterText.text = "Fails: " + failTracker.CurrentFails + "/" + failTracker.maxFails;
        StartCoroutine(NextCardAfterDelay());

        IEnumerator NextCardAfterDelay()
        {
            yield return new WaitForSeconds(feedbackDisplayTime); // waits before moving on
            currentCardIndex++;
            ShowCard();
        }

    }



}