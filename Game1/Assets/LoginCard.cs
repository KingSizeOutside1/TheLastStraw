using UnityEngine;

[CreateAssetMenu(fileName = "New Login Card", menuName = "Cards/Login Card")]
public class LoginCard : ScriptableObject
{
    [Header("Sender Info")]
    public string SenderName; // Name of the sender
    public string SenderEmail; // Email address of the sender (used to determine if it's a phishing attempt)
    [Header("Message")]
    [TextArea(3, 10)]
    public string[] MessageLines; // each line is 1 "bubble" in the conversation, shown in order from top to bottom
    [Header("Link/Login")]
    public string DisplayURL;
    [Header("Decision")]
    public bool correctAnswerIsYes; // True if "Yes" is the correct answer, false if "No" is the correct answer

    [Header("Feedback")]
    [TextArea(2, 5)]
    public string FeedbackCorrect; // Feedback shown if player chooses the correct answer
    [TextArea(2, 5)]
    public string FeedbackWrong; // Feedback shown if player chooses the incorrect answer // matching messagecard.cs
// consistent capitalization for "Incorrect" vs "Wrong" in MessageCard and LoginCard
} 