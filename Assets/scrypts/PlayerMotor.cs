using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] Camera cam;

    private Vector3 velocity;
    private Vector3 rotation;
    private float camRotationX = 0f;
    private float currentCamRotX = 0f;
    private Vector3 jetpackVelocity;

    [SerializeField] private float camRotLim = 90f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _camRotationX)
    {
        camRotationX = _camRotationX;
    }

    public void ApplyThrust(Vector3 _jetVelocity)
    {
        jetpackVelocity = _jetVelocity;
    }

    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if(jetpackVelocity != Vector3.zero)
        {
            rb.AddForce(jetpackVelocity * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        currentCamRotX -= camRotationX;
        currentCamRotX = Mathf.Clamp(currentCamRotX,-camRotLim, camRotLim);

        cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
    }
}
