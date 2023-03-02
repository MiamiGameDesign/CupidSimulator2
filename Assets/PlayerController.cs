using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 6f;
    public float jumpSpeed = 8f;
	public float gravity = 20f;
    public Rigidbody rb;
    public GameObject[] enemies = new GameObject[15];
    public Image image;
    public TextMeshProUGUI youwin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        foreach(var enemy in enemies)
        {
            enemy.tag = "cupid_simulator_enemy";
        }
        
    }

    private Vector3 moveDirection = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        GameObject[] enemytags = GameObject.FindGameObjectsWithTag("cupid_simulator_enemy");
        int count = 0;
        for (int i = 0; i < enemytags.Length; i++) {
            count++;
        }
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
        
        if (count == 0)
        {
            image.enabled = true;
            youwin.enabled = true;
            Time.timeScale = 0;
        }
    }
}
