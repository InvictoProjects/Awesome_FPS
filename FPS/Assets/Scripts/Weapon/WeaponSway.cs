using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 4f;
    [SerializeField] private float maxTurn = 3f;

    private InputManager _input;

    private void Start()
    {
        _input = GetComponentInParent<InputManager>();
    }

    void Update()
    {
        Vector2 mouseInput = _input.look;

        ApplyRotation(GetRotation(mouseInput));
    }

    Quaternion GetRotation(Vector2 mouse)
    {
        mouse = Vector2.ClampMagnitude(mouse, maxTurn);

        Quaternion rotX = Quaternion.AngleAxis(-mouse.y, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(mouse.x, Vector3.up);

        Quaternion targetRot = rotX * rotY;

        return targetRot;
    }

    void ApplyRotation(Quaternion targetRot)
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, rotateSpeed * Time.deltaTime);
    }
}
