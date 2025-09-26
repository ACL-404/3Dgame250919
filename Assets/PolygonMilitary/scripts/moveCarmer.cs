using UnityEngine;

public class moveCarmer : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float rotateSpeed = 100f; // 滑鼠旋轉速度
    private float rotationX = 0f;
    private float rotationY = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow ))
        {
            transform.Translate(Vector3.forward * 30f*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(Vector3.back * 30f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 30f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 30f * Time.deltaTime);
        }
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f); // 限制上下旋轉角度

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
