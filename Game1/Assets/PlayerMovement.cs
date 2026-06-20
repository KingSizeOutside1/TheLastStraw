using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
       
    
    if (Input.GetKey(KeyCode.A))
    {
        Debug.Log("A pressed");
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey(KeyCode.D))
    {
        Debug.Log("D pressed");
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
    }
}
