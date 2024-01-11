using UnityEngine;

[RequireComponent (typeof(PlayerMotor))]
[RequireComponent(typeof(ConfigurableJoint))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float mouseSensY;
    [SerializeField] private float mouseSensX;

    [SerializeField] private float jetpackSTR;

    [Header("joint options")]
    [SerializeField] private float jointSpring;
    [SerializeField] private float jointMaxSTR;

    [SerializeField] AudioSource music;
    private bool musicIsPlaying;

    private float maxSpeed;

    private PlayerMotor motor;
    private ConfigurableJoint joint;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();
        SetJointSetting(jointSpring);
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Deplacment();
        CameraMovment();
        JetpackMove();
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

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensY;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 camRotation = new Vector3(xRot, 0, 0) * mouseSensX;

        xRot = Mathf.Clamp(xRot, -90, 90);
        motor.RotateCamera(camRotation);
    }

    private void JetpackMove()
    {
        Vector3 jetpackVelocity = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            jetpackVelocity = Vector3.up * jetpackSTR;
            SetJointSetting(0f);
            if(musicIsPlaying == false)
            {
                music.Play();
                musicIsPlaying = true;
            }
        }
        else
        {
            SetJointSetting(jointSpring);
            music.Stop();
            musicIsPlaying = false;
        }
        motor.ApplyThrust(jetpackVelocity);
    }

    private void SetJointSetting(float _jointSpring)
    {
        joint.yDrive = new JointDrive { positionSpring = _jointSpring, maximumForce = jointMaxSTR };
    }
}
