using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivityX = 8f;
    [SerializeField] float mouseSensitivityY = 0.5f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;
    [SerializeField] float clampOffset = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        transform.Rotate(Vector3.up * mouseX *Time.deltaTime);


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp+clampOffset, xClamp);
        Vector3 targetRotatation = transform.eulerAngles;
        targetRotatation.x = xRotation;

        playerCamera.eulerAngles = targetRotatation;

    }
    public void ReceiveInput(Vector2 _mouseInput)
    {
        mouseX = _mouseInput.x * mouseSensitivityX;
        mouseY = _mouseInput.y * mouseSensitivityY;
    }
}
