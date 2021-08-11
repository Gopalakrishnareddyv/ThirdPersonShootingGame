using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Animator anim;
    AggroDetection aggro;
    NavMeshAgent nav;
    Transform enemyTarget;
    private void Awake()
    {
        nav=GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        aggro = GetComponent<AggroDetection>();
        aggro.OnAggro += Aggro_OnAggro;
    }
    private void Aggro_OnAggro(Transform target)
    {
        this.enemyTarget = target;
    }
    private void Update()
    {
        if (enemyTarget != null)
        {
            nav.SetDestination(enemyTarget.position);
            float enemySpeed = nav.velocity.magnitude;
            anim.SetFloat("Speed", enemySpeed);
        }

    }
}
