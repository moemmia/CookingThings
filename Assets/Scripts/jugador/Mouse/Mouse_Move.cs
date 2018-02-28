using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mouse_Move : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject animator;
    public GameObject showWere;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
        if (agent.hasPath && agent.remainingDistance > float.Epsilon)
        {
            if (!animator.GetComponent<Animator>().GetBool("walking"))
                animator.GetComponent<Animator>().SetBool("walking", true);
            showWere.SetActive(true);
            showWere.transform.position= agent.destination;
        }
        else
        {
            if (animator.GetComponent<Animator>().GetBool("walking"))
                animator.GetComponent<Animator>().SetBool("walking", false);
            showWere.SetActive(false);
        }

    }

    
}
