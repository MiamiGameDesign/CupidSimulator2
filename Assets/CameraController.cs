using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
	public float mouseSensitivity = 2f;
	float cameraVerticalRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //hide cursor and lock it in the middle of the screen
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X")*mouseSensitivity;
		float inputY = Input.GetAxis("Mouse Y")*mouseSensitivity;

		//rotate camera around x axis
		cameraVerticalRotation -= inputY;
		cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
		transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
		
		//rotate camera around y axis
		player.Rotate(Vector3.up * inputX);
    }
}
