using UnityEngine;

[RequireComponent (typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float mouseSens;

    private float maxSpeed;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        Deplacment();
        CameraMovment();
    }

    private void Deplacment()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);
    }

    private void CameraMovment()
    {
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSens;

        motor.Rotate(rotation);
    }
}
