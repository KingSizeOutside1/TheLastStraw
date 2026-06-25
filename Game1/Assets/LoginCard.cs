using UnityEngine;

[CreateAssetMenu(fileName = "New Login Card", menuName = "Cards/Login Card")]
public class LoginCard : ScriptableObject
{
    [Header("Site Info")]
    public string SiteName; // Name of the site
    [Header("Link/Login")]
    public string DisplayURL; // URL displayed to the player
    public bool HasPadlockIcon; // True if the URL has a padlock icon, false if it does not
   [Header("Suspicous Details")]
    [TextArea(2, 4)]
    public string SuspiciousDetailsAndHints; // Details that make the URL suspicious, such as misspellings or unusual characters
    
    [Header("Decision")]
    public bool correctAnswerIsYes; // True if "Yes" is the correct answer, false if "No" is the correct answer

    [Header("Feedback")]
    [TextArea(2, 5)]
    public string FeedbackCorrect; // Feedback shown if player chooses the correct answer
    [TextArea(2, 5)]
    public string FeedbackWrong; // Feedback shown if player chooses the incorrect answer // matching messagecard.cs
// consistent capitalization for "Incorrect" vs "Wrong" in MessageCard and LoginCard
} 