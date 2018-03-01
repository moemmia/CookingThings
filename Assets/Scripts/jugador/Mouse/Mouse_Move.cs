using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mouse_Move : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject animator;
    public GameObject showWere;
    private float lastClickTime;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        float catchTime =  0.3f;
        if (Input.GetButtonDown("Mouse0"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (Time.time - lastClickTime < catchTime && Vector3.Distance( agent.destination, hit.point)<0.3f)
                {
                    //double click
                    animator.GetComponent<Animator>().SetFloat("vel", 4f);
                    agent.speed = 10f;
                }
                else
                {
                    //normal click
                    animator.GetComponent<Animator>().SetFloat("vel", 2f);
                    agent.speed = 5f;
                }
                agent.destination = hit.point;
            }
            lastClickTime = Time.time;
            
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
