using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 6f;
    public float jumpSpeed = 8f;
	public float gravity = 20f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private Vector3 moveDirection = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        if(Input.GetKey(KeyCode.LeftControl)) {
            gravity = 200;
        } else {
            gravity = 20;
        }
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
        if(transform.position.y < 0) {
            transform.position = new Vector3(0, 12, 0);
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
