using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    // I think the "f" behind the numbers means "default"
    private float _xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // The cursor is locked at the center of the screen and invisible
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        // the brown "Mouse X" and "Mouse Y" are the positions of the real mouse. "mouseX" and "mouseY" are the variables. We disconnect it from FrameRate
        var mouseX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;
        
        // mouseY is for the up and down movement of camera, the "mathClamp" is to fix it so the player can't turn his head vertically 360 degrees
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 70f);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

      


    }
}
