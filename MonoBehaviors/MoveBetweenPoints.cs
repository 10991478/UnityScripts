using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2f;
    private int direction = -1;

    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            if (currentWaypointIndex == waypoints.Length - 1 || currentWaypointIndex == 0)
            {
                direction *= -1;
            }
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = waypoints.Length - 1;
                direction = -1;
            }
            if (currentWaypointIndex < 0)
            {
                currentWaypointIndex = 0;
                direction = 1;
            }
            currentWaypointIndex += direction;
        }
        var newPos = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        transform.position = newPos;
    }
}