using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterTest : MonoBehaviour
{
    public NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print(pos);
            agent.SetDestination(pos);
        }
        
       
    }
}
