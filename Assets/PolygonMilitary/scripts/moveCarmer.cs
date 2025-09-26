using UnityEngine;

public class moveCarmer : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow ))
        {
            transform.Translate(Vector3.forward * 3.5f*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(Vector3.back * 3.5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 3.5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 3.5f * Time.deltaTime);
        }
    }
}
