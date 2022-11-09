using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector2 defoPosition ;

    NavMeshAgent2D NavMeshAgent2D;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent2D = GetComponent<NavMeshAgent2D>();
        defoPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent2D.SetDestination(target.position);
    }
    public void PlaerHit()
    {
        transform.position = defoPosition;
    }
    
}
