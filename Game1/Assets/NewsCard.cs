using UnityEngine;

public enum NewsType
{
    HeadlineArticle,
    SocialPost,
}

[CreateAssetMenu(fileName = "New News Card", menuName = "Cards/News Card")] // creates a "Create > Cards > News Card" option in the Unity editor to create new news cards
public class NewsCard : ScriptableObject
{
    [Header("Display Style")]
    public NewsType DisplayStyle = NewsType.HeadlineArticle;

    [Header("Headline Article Fields")]
    public string Headline;
    [TextArea(3, 8)]
    public string ArticleSnippet; //
    public string SourceName;

    [Header("Social Post Fields")] // only used if DisplayStyle is SocialPost
    public string PosterName;
    public string PosterHandle;
    [TextArea(2, 6)]
    public string PostCaption;

    [Header("decision")]
    public bool correctAnswerIsYes; // True if "Yes" is the correct answer, false if "No" is the correct answer
    [Header("Feedback")] 
    [TextArea(2, 5)]
    public string FeedbackCorrect; // Feedback shown if player chooses the correct answer
    [TextArea(2, 5)]
    public string FeedbackWrong; // Feedback shown if player chooses the incorrect answer
}