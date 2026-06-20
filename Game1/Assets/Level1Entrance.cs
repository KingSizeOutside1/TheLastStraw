using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1Entrance : MonoBehaviour
{
    public GameObject promptUI;
    public string TextsAndEmails;
    private bool playerInRange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TextsAndEmails");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (promptUI != null)
            {
                promptUI.SetActive(true);
            }
        }
        {
    Debug.Log("Something entered: " + other.gameObject.name);
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player detected!");
        playerInRange = true;
        if (promptUI != null) promptUI.SetActive(true);
    }
}
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (promptUI != null)
            {
                promptUI.SetActive(false);
            }
        }
    }
}
