using UnityEngine;
using UnityEngine.SceneManagement;
public class FailTracker : MonoBehaviour
{
    public int maxFails = 3;
    private int currentFails = 0;
    public int CurrentFails { get { return currentFails; } }

    public string hackedSceneName = "HackedScreen"; //make this later today

    public void RegisterFail()
    {
        currentFails++;
        Debug.Log("Fail registered. Current fails: " + currentFails);
        if (currentFails >= maxFails)
        {
            TriggerHacked();
        }
    }
    void TriggerHacked()
    {
        Debug.Log("Hacked - Game Over!");
        SceneManager.LoadScene(hackedSceneName);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
