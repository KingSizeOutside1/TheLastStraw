using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButtonManager : MonoBehaviour
{
    public string mainSceneName = "SampleScene"; // 

    public void OnReturnButtonPressed()
    {
        SceneManager.LoadScene(mainSceneName);
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
