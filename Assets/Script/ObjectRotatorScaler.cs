using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ObjectRotatorScaler : MonoBehaviour
{
    [Header("旋转设置")]
    [Tooltip("旋转灵敏度")]
    public float rotationSensitivity = 1f;
    [Tooltip("惯性衰减系数")]
    public float inertiaDamping = 0.9f;
    [Tooltip("最小惯性速度（低于此值停止旋转）")]
    public float minInertiaVelocity = 0.01f;

    [Header("缩放设置")]
    [Tooltip("缩放灵敏度")]
    public float scaleSensitivity = 0.1f;
    [Tooltip("最小缩放比例")]
    public float minScale = 0.1f;
    [Tooltip("最大缩放比例")]
    public float maxScale = 10f;

    private bool isDragging = false;
    private Vector2 lastMousePosition;
    private Vector2 currentVelocity;
    private Vector3 initialScale;

    void Start()
    {
        // 记录初始缩放比例作为基准
        initialScale = transform.localScale;
    }

    void Update()
    {
        HandleRotationInput();
        HandleScaleInput();
        ApplyInertia();
    }

    private void HandleRotationInput()
    {
        // 鼠标按下开始拖拽
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
            currentVelocity = Vector2.zero; // 重置惯性
        }
        // 鼠标释放结束拖拽
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // 拖拽中处理旋转
        if (isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 delta = currentMousePosition - lastMousePosition;

            // 计算旋转速度（作为惯性的基础）
            currentVelocity = delta * rotationSensitivity;

            // 应用旋转
            transform.Rotate(Vector3.up, -delta.x * rotationSensitivity, Space.World);
            transform.Rotate(Vector3.right, delta.y * rotationSensitivity, Space.Self);

            lastMousePosition = currentMousePosition;
        }
    }

    private void HandleScaleInput()
    {
        // 处理鼠标滚轮缩放
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.001f)
        {
            // 计算新的缩放比例
            Vector3 newScale = transform.localScale * (1 + scroll * scaleSensitivity);

            // 限制缩放范围
            newScale.x = Mathf.Clamp(newScale.x, initialScale.x * minScale, initialScale.x * maxScale);
            newScale.y = Mathf.Clamp(newScale.y, initialScale.y * minScale, initialScale.y * maxScale);
            newScale.z = Mathf.Clamp(newScale.z, initialScale.z * minScale, initialScale.z * maxScale);

            transform.localScale = newScale;
        }
    }

    private void ApplyInertia()
    {
        // 不在拖拽状态时应用惯性
        if (!isDragging && currentVelocity.sqrMagnitude > minInertiaVelocity * minInertiaVelocity)
        {
            // 应用旋转
            transform.Rotate(Vector3.up, -currentVelocity.x, Space.World);
            transform.Rotate(Vector3.right, currentVelocity.y, Space.Self);

            // 衰减惯性
            currentVelocity *= inertiaDamping;
        }
        else if (!isDragging)
        {
            currentVelocity = Vector2.zero;
        }
    }
}