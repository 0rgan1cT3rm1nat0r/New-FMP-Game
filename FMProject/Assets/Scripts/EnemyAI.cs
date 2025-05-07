using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;

    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;
    private GameObject player2;
    private float lastAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        if (player == null && player2 == null)
            return;

        GameObject targetPlayer = GetClosestPlayer();

        if (targetPlayer == null)
            return;

        float distance = Vector3.Distance(transform.position, targetPlayer.transform.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(targetPlayer.transform.position);

            if (distance <= attackRange)
            {
                agent.isStopped = true;

                // Optional: rotate to face target
                /*
                Vector3 direction = (targetPlayer.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
                */
                TryAttack();
            }
            else
            {
                agent.isStopped = false;
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isRunning", false);
        }
    }

    GameObject GetClosestPlayer()
    {
        float distanceToPlayer1 = player != null ? Vector3.Distance(transform.position, player.transform.position) : Mathf.Infinity;
        float distanceToPlayer2 = player2 != null ? Vector3.Distance(transform.position, player2.transform.position) : Mathf.Infinity;

        if (distanceToPlayer1 < distanceToPlayer2)
            return player;
        else if (distanceToPlayer2 < distanceToPlayer1)
            return player2;
        else
            return null;
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            anim.SetTrigger("attack");
            // Add attack logic here (e.g., damage the player, play sound)
        }
    }
}
