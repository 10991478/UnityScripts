using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBetweenPosts : MonoBehaviour
{
    public GameObject[] posts;
    private int currentPost = 0;
    public float speed = 2f;
    public bool x, y, z;
    private int direction = -1;
    [System.NonSerialized] public bool moving = true;


    void Update()
    {
        if (moving)
        {
            if (CloseToPost(0.1f))
            {
                if (currentPost == posts.Length - 1 || currentPost == 0)
                {
                    direction *= -1;
                }
                if (currentPost >= posts.Length)
                {
                    currentPost = posts.Length - 1;
                    direction = -1;
                }
                if (currentPost < 0)
                {
                    currentPost = 0;
                    direction = 1;
                }
                currentPost += direction;
            }
            Vector3 targetPosition = posts[currentPost].transform.position;
            if (!x) targetPosition.x = transform.position.x;
            if (!y) targetPosition.y = transform.position.y;
            if (!z) targetPosition.z = transform.position.z;
            Vector3 newPos = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.position = newPos;
        }
    }

    private bool CloseToPost(float range)
    {
        if (x && Mathf.Abs(posts[currentPost].transform.position.x - transform.position.x) > range) return false;
        else if (y && Mathf.Abs(posts[currentPost].transform.position.y - transform.position.y) > range) return false;
        else if (z && Mathf.Abs(posts[currentPost].transform.position.z - transform.position.z) > range) return false;
        else return true;
    }
}
