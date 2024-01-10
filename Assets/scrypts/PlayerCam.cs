using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float mouseSensX = 100;
    [SerializeField] float mouseSensY = 100;

    public Transform playerBody;

    float yRotation;
    float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
