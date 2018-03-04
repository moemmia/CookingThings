using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    NavMeshAgent agent;
    public GameObject animator;
    public GameObject showWere;
    private float lastClickTime;
    private float catchTime = 0.3f;
    public Action onArrive;
    public GameObject attached;
    public bool carrying;
    public GameObject basemover;
    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetButtonDown("Mouse0"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                MoveTo(hit.point);
            }
            lastClickTime = Time.time;
            onArrive = null;
        }
        if (Input.GetButtonDown("Mouse1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                try
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.GetComponent<ListOfActions>().show();
                }
                catch{}
                
            }
        }
        ContinueMove();
        Carrying();
    }

    public void MoveTo(Vector3 position)
    {
        if (Time.time - lastClickTime < catchTime && Vector3.Distance(agent.destination, position) < 0.3f)
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
        agent.destination = position;
    }

    private void ContinueMove()
    {
        if (agent.hasPath && agent.remainingDistance > float.Epsilon)
        {
            if (!animator.GetComponent<Animator>().GetBool("walking"))
                animator.GetComponent<Animator>().SetBool("walking", true);
            showWere.SetActive(true);
            showWere.transform.position = agent.destination;
        }
        else
        {
            if (animator.GetComponent<Animator>().GetBool("walking"))
                animator.GetComponent<Animator>().SetBool("walking", false);
            showWere.SetActive(false);
            if (onArrive != null)
            {
                onArrive();
            }
        }
    }

    private void Carrying()
    {
        if (carrying && attached != null)
        {
            attached.GetComponent<Rigidbody>().isKinematic = true;
            attached.GetComponent<NavMeshObstacle>().enabled = false;
            foreach (Collider c in attached.transform.GetComponents<Collider>())
                c.enabled = false;
            attached.transform.position = basemover.transform.position;
            animator.GetComponent<Animator>().SetBool("carrying", true);
        }
        else if(!carrying && attached != null)
        {
            attached.GetComponent<Rigidbody>().isKinematic = false;
            attached.GetComponent<NavMeshObstacle>().enabled = true;
            foreach (Collider c in attached.transform.GetComponents<Collider>())
                c.enabled = true;
            animator.GetComponent<Animator>().SetBool("carrying", false);
            attached = null;
        }
    }

    
}
