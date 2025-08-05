using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        // Move toward the target point
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // If close to the target, switch direction
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip sprite horizontally
        transform.localScale = scale;
    }
}
