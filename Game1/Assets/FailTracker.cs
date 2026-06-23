using UnityEngine;
using UnityEngine.SceneManagement;
public class FailTracker : MonoBehaviour
{
    public int maxFails = 3;
    public static FailTracker Instance { get; private set; }
    private int currentFails = 0;
    public int CurrentFails { get { return currentFails; } }

    public string hackedSceneName = "HackedScreen"; //make this later today
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RegisterFail()
    {
        currentFails++;
        Debug.Log("Fail registered. Current fails: " + currentFails);
        if (currentFails >= maxFails)
        {
            TriggerHacked();
        }
    }
    public void ResetFails()
    {
        currentFails = 0; // Reset fails after triggering hacked, or you can choose to keep it as is if you want to track fails across levels
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
