using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 5f;
    public float chaseSpeed = 7f;
    public float detectionRange = 20f;
    public float attackRange = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;

    private int currentPatrolIndex;
    private Transform player;
    private float nextFireTime;

    private enum State { Patrol, Chase, Attack }
    private State currentState = State.Patrol;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentPatrolIndex = 0;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Cambiar de estado según la distancia al jugador
        if (distanceToPlayer <= attackRange)
            currentState = State.Attack;
        else if (distanceToPlayer <= detectionRange)
            currentState = State.Chase;
        else
            currentState = State.Patrol;

        // Ejecutar comportamiento según el estado
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                ChasePlayer();
                break;
            case State.Attack:
                AttackPlayer();
                break;
        }
    }

    void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        MoveTowards(targetPoint.position, patrolSpeed);

        if (Vector3.Distance(transform.position, targetPoint.position) < 3f)
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void ChasePlayer()
    {
        MoveTowards(player.position, chaseSpeed);
    }

    void AttackPlayer()
    {
        // Mirar hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // Disparar si es tiempo
        if (Time.time >= nextFireTime)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void MoveTowards(Vector3 target, float speed)
        {
            Vector3 direction = (target - transform.position).normalized;

            // Movimiento horizontal (X y Z)
            Vector3 horizontalMove = new Vector3(direction.x, 0, direction.z);
            transform.position += horizontalMove * speed * Time.deltaTime;

            // Mirar al objetivo horizontalmente
            Vector3 lookTarget = new Vector3(target.x, transform.position.y, target.z);
            transform.LookAt(lookTarget);

            // Raycast para detectar terreno
            Vector3 rayOrigin = transform.position + Vector3.up * 5f;
            float rayDistance = 100f;
            Debug.DrawRay(rayOrigin, Vector3.down * rayDistance, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Vector3.down, out hit, rayDistance))
            {
                float desiredHeight = hit.point.y + 3f;
                Vector3 pos = transform.position;
                pos.y = Mathf.Lerp(transform.position.y, desiredHeight, Time.deltaTime * 5f);
                transform.position = pos;
            }

        }

}
