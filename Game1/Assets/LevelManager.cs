using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [Header("Cards")]
    public MessageCard[] cards;
    private int currentCardIndex = 0;

    [Header("UI References")]
    public TMP_Text contactNameText;
    public TMP_Text phoneNumberText;
    public TMP_Text messageText;
    public TMP_Text taskCounterText;
    public TMP_Text failCounterText;
    public Button yesButton;
    public Button noButton;

    [Header("Fail Tracking")]
    public FailTracker failTracker;

    [Header("Feedback Timing")]
    public float feedbackDisplayTime = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowCard(currentCardIndex);
    }

    void ShowCard(int index)
    {
        if (index >= cards.Length)
        {
            messageText.text = "Level Complete!";
            yesButton.interactable = false;
            noButton.interactable = false;
            return;
        }

        MessageCard card = cards[index];
        contactNameText.text = card.contactName;
        phoneNumberText.text = card.phoneNumber;
        messageText.text = string.Join("\n\n", card.messageLines);
        taskCounterText.text = "Task: " + (index + 1) + "/" + cards.Length;
        failCounterText.text = "Fails: " + failTracker.CurrentFails + "/" + failTracker.maxFails;

        yesButton.interactable = true;
        noButton.interactable = true;
    }

    public void OnYesPressed() { HandleAnswer(true); }
    public void OnNoPressed() { HandleAnswer(false); }

    void HandleAnswer(bool answeredYes)
    {
        yesButton.interactable = false;
        noButton.interactable = false;

        MessageCard card = cards[currentCardIndex];
        bool isCorrect = (answeredYes == card.correctAnswerIsYes);

        messageText.text = isCorrect ? card.feedbackCorrect : card.feedbackWrong;
        if (!isCorrect) failTracker.RegisterFail();

        failCounterText.text = "Fails: " + failTracker.CurrentFails + "/" + failTracker.maxFails;
        StartCoroutine(NextCardAfterDelay());
    }

    IEnumerator NextCardAfterDelay()
    {
        yield return new WaitForSeconds(feedbackDisplayTime);
        currentCardIndex++;
        ShowCard(currentCardIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
