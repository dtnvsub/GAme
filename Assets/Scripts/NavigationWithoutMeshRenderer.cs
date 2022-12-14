using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationWithoutMeshRenderer : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject targetObject;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.SetDestination(targetObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
