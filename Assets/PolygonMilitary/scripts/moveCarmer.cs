using UnityEngine;

public class moveCarmer : MonoBehaviour
{
    [Header("移動相關")]
    [SerializeField] private float moveSpeed = 20f;      // 最大移動速度
    [SerializeField] private float moveSmooth = 5f;      // 移動平滑度 (慣性阻力)

    [Header("旋轉相關")]
    [SerializeField] private float rotateSpeed = 100f;   // 滑鼠旋轉速度
    [SerializeField] private float rollAmount = 30f;     // 最大傾斜角度 (戰鬥機 roll)
    [SerializeField] private float rollSmooth = 5f;      // 傾斜平滑度
    [SerializeField] private float rotateSmooth = 5f;    // 旋轉慣性平滑度

    private float rotationX = 0f; // Pitch (上下)
    private float rotationY = 0f; // Yaw (左右)
    private float currentRoll = 0f; // Roll (傾斜)

    private Vector3 moveVelocity = Vector3.zero; // 當前移動速度
    private float yawVelocity = 0f; // 水平旋轉慣性
    private float pitchVelocity = 0f; // 垂直旋轉慣性

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // === 1. 鍵盤移動輸入 ===
        Vector3 inputDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) inputDir += Vector3.forward;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) inputDir += Vector3.back;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) inputDir += Vector3.right;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) inputDir += Vector3.left;

        // 平滑過渡 (慣性移動)
        Vector3 targetVelocity = inputDir.normalized * moveSpeed;
        moveVelocity = Vector3.Lerp(moveVelocity, targetVelocity, Time.deltaTime * moveSmooth);

        // 套用移動 (依照機體方向前後左右)
        transform.Translate(moveVelocity * Time.deltaTime, Space.Self);

        // === 2. 滑鼠旋轉輸入 ===
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        // 使用慣性：逐漸平滑旋轉
        yawVelocity = Mathf.Lerp(yawVelocity, mouseX, Time.deltaTime * rotateSmooth);
        pitchVelocity = Mathf.Lerp(pitchVelocity, -mouseY, Time.deltaTime * rotateSmooth);

        rotationX += pitchVelocity; // Pitch
        rotationY += yawVelocity;   // Yaw
        // ❌ 不限制 Pitch，可以 360 度翻轉

        // === 3. 戰鬥機傾斜效果 (Roll) ===
        float targetRoll = -Input.GetAxis("Mouse X") * rollAmount; // 滑鼠左右帶來傾斜
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, Time.deltaTime * rollSmooth);

        // === 4. 最終旋轉 ===
        transform.rotation = Quaternion.Euler(rotationX, rotationY, currentRoll);
    }
}