using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValentineSpawner : MonoBehaviour
{
    public GameObject other;
    public GameObject hearts;
    public Canvas canvas;

    float time_until_next_spawn = 0.0f;
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }


    // Update is called once per frame
    void Update()
    {
        if (time_until_next_spawn <= 0.0f)
        {
            time_until_next_spawn = Random.Range(0.1f, 1.0f);
            var new_heart = Instantiate(hearts, canvas.transform);
            new_heart.transform.position = new Vector3(Random.Range(transform.position.x, other.transform.position.x), transform.position.y, 0.0f);
        }
        time_until_next_spawn -= Time.deltaTime;
    }
}
