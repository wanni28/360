using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopLookTest : MonoBehaviour
{
    public float lookSpeed = 60f;                 // keyboard, degrees per second
    public float mouseSensitivity = 0.15f;       // mouse, degrees per pixel
    private float yaw;
    private float pitch;

    // Runs after TrackedPoseDriver so it always wins
    void LateUpdate()
    {
        var kb = Keyboard.current;
        var mouse = Mouse.current;

        if (kb != null)
        {
            if (kb.leftArrowKey.isPressed) yaw -= lookSpeed * Time.deltaTime;
            if (kb.rightArrowKey.isPressed) yaw += lookSpeed * Time.deltaTime;
        }

        if (mouse != null && mouse.rightButton.isPressed)
        {
            Vector2 delta = mouse.delta.ReadValue();
            yaw += delta.x * mouseSensitivity;
            pitch -= delta.y * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -80f, 80f);
        }

        transform.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
