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
    public GameObject[] goals;
    Vector3 lastgoal;
    public float chasingPoint;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        aggro = GetComponent<AggroDetection>();
        aggro.OnAggro += Aggro_OnAggro;
    }


    private void Aggro_OnAggro(Transform target)
    {
        this.enemyTarget = target;
    }

    public void SetLocation()
    {
        var g = goals[Random.Range(0, goals.Length)].transform.position;
        nav.SetDestination(g);
        Debug.Log(g);
        anim.SetFloat("Speed", 1);
    }

    private void Update()
    {
        if (enemyTarget != null)
        {
            nav.SetDestination(enemyTarget.position);
            float enemySpeed = nav.velocity.magnitude;
            anim.SetFloat("Speed", 1);
        }
        if (nav.remainingDistance <= chasingPoint)
        {
            SetLocation();
        }

    }
}

