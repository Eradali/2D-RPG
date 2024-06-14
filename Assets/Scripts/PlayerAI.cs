using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player : MonoBehaviour
{
    Vector3 target;
    public float speed = 5f;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        Vector3 pos = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime * 20);
        agent.SetDestination(pos);
    }
}
