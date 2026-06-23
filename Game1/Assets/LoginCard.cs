using UnityEngine;

[CreateAssetMenu(fileName = "New Login Card", menuName = "Cards/Login Card")]
public class LoginCard : ScriptableObject
{
    [Header("Sender Info")]
    public string SenderName;
    public string SenderEmail;
    [Header("Message")]
    [TextArea(3, 10)]
    public string[] MessageLines;
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