using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform targetObject;
    public string tagObject;
    Animator animator;
    NavMeshAgent navMeshAgent;
    GameLogic gameLogic;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if(targetObject == null){
            targetObject = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(gameLogic == null){
            GameObject _temp = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameLogic = _temp.GetComponent<GameLogic>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = targetObject.position;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == tagObject){
            Destroy(other.gameObject);
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Death");
            gameLogic.GetScoreKillEnemy();
        }
    }
}
