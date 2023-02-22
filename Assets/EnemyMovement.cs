using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // speed of the enemy
    private Vector3 direction; // direction to move in
    private float timeToChangeDirection; // time until changing direction

    void Start()
    {
        // set initial direction and time to change direction
        direction = GetRandomDirection();
        timeToChangeDirection = Random.Range(1f, 4f);
    }

    void Update()
    {
        // move the enemy in the current direction
        transform.position += direction * speed * Time.deltaTime;

        // update the time to change direction
        timeToChangeDirection -= Time.deltaTime;

        // if it's time to change direction, pick a new random direction and reset the timer
        if (timeToChangeDirection <= 0f)
        {
            direction = GetRandomDirection();
            timeToChangeDirection = Random.Range(1f, 4f);
        }
    }

    Vector3 GetRandomDirection()
    {
        // pick a random direction in the x-z plane
        float angle = Random.Range(0f, 360f);
        Vector3 direction = new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle));
        return direction;
    }
}