using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValentineScript : MonoBehaviour
{
    RectTransform my_transform;
    float speed;
    float angular_speed;

    // Start is called before the first frame update
    void Start()
    {
        my_transform = GetComponent<RectTransform>();
        int size = Random.Range(20, 100);
        my_transform.rect.Set(my_transform.rect.x, my_transform.rect.y, size, size);
        speed = Random.Range(10, 35);
        angular_speed = Random.Range(0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        my_transform.SetPositionAndRotation(my_transform.position + new Vector3(0.0f, -speed*Time.deltaTime, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, my_transform.rotation.eulerAngles.z + angular_speed * Time.deltaTime));
       
    }
}
