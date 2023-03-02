using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 direction;
    private float timeToChangeDirection;
    public float raycastDistance = 1f; // max distance to check for obstacles
    public LayerMask obstacleLayer; // layer to consider as obstacles

    void Start()
    {
        // set initial direction and time to change direction
        direction = GetRandomDirection();
        timeToChangeDirection = Random.Range(2f, 7f);
    }

    void Update()
    {
        // check for obstacles in front of the enemy
        bool obstacleDetected = Physics.Raycast(transform.position, direction, raycastDistance, obstacleLayer);

        if (!obstacleDetected)
        {
            // move the enemy in the current direction
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // if an obstacle is detected, pick a new random direction
            direction = GetRandomDirection();
        }

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