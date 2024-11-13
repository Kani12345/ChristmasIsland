using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity101_ThirdPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform target, player;
    private float mouseX, mouseY;
    public float clampYUp = 30f, clampYDown = 30f;
    private float playerRotOffset;

    private void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        playerRotOffset = player.transform.rotation.y;
    }

    private void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -1*clampYUp, clampYDown);

        transform.LookAt(target);
        player.rotation = Quaternion.Euler(0, playerRotOffset + mouseX, 0);
        this.transform.rotation *= Quaternion.Euler(mouseY, 0, 0);
    }
}
