using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float maxHp = 45f;
    public int reward = 10;
    public int damageToServer = 6;

    private float currentHp;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void SetPath(Transform[] path)
    {
        waypoints = path;
        currentWaypointIndex = 0;

        if (waypoints != null && waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    private void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (currentWaypointIndex >= waypoints.Length)
        {
            ReachServer();
            return;
        }

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetWaypoint.position,
            speed * Time.deltaTime
        );

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        if (distance < 0.05f)
        {
            currentWaypointIndex++;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy mati, player dapat Data Point: " + reward);
        Destroy(gameObject);
    }

    private void ReachServer()
    {
        Debug.Log("Enemy sampai ke server. Damage: " + damageToServer);
        Destroy(gameObject);
    }
}