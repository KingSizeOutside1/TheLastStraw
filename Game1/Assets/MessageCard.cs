using UnityEngine;

[CreateAssetMenu(fileName = "New Message Card", menuName = "Game/Message Card")]
public class MessageCard : ScriptableObject
{
    [Header("Contact Info")]
    public string contactName;
    public string phoneNumber;

    [Header("conversation")]
    [TextArea(3, 10)]
    public string[] messageLines; // each line is 1 "bubble" in the conversation

    [Header("Decision")]
    public bool correctAnswerIsYes; // true = "Yes" is correct, false = "No" is correct

    [Header("Feedback")]
    [TextArea(2, 5)]
    public string feedbackCorrect; // feedback shown if player chooses the correct answer
    [TextArea(2, 5)]
    public string feedbackWrong; // feedback shown if player chooses the incorrect answer

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
