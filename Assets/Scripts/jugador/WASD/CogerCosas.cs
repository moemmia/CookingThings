using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerCosas : MonoBehaviour {
    public GameObject person;
    GameObject attached;
    RaycastHit hit=new RaycastHit();
    RaycastHit[] hits;
    public float radius;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate() {
       // Ray ray = new Ray(transform.position+Vector3.up, Vector3.down);
       // Physics.SphereCast(ray,1f, out hit);
        hits=Physics.SphereCastAll(GetComponentInParent<Transform>().position + Vector3.up,  1f, Vector3.down);
        //Physics.Raycast(transform.position, Vector3.down, out hit); 
        if (Input.GetKeyDown(KeyCode.E)) //No Haardcodear por favor, arreglalo cunado todo funcione
        {
            if (attached == null)
            {
                hit = closestHit(hits);
                if (hit.transform!=null && hit.transform.tag.Equals("obj"))
                {
                    attached = hit.transform.gameObject;
                    GameObject.FindGameObjectWithTag("seguidor").GetComponent<MoveAlongTheCinta>().releaseMe(attached);
                    person.GetComponent<Animator>().SetBool("carrying", true);
                    attached.GetComponent<Rigidbody>().isKinematic = true;
                    foreach (Collider c in hit.transform.GetComponents<Collider>())
                        c.enabled = false;
                }
            }
            else
            {
                person.GetComponent<Animator>().SetBool("carrying", false);
                attached.GetComponent<Rigidbody>().isKinematic = false;
                foreach (Collider c in attached.GetComponents<Collider>())
                {
                    c.enabled = true;
                } 
                attached = null;
            }
        }else if (attached == null)
        {
                hit = closestHit(hits);
                if(hit.transform != null && hit.transform.tag.Equals("obj"))
                {
                    //dar una indicación visual de que se puede interactuar con el objeto.
                }             
        }else
        {
            attached.transform.position = this.transform.position;

        }
    }

    private RaycastHit closestHit(RaycastHit[] hits)
    {
        RaycastHit hit = new RaycastHit();
        foreach (RaycastHit h in hits)
        {
            if (hit.transform == null) hit = h;
            else if (h.transform.tag.Equals("obj") && hit.distance > h.distance)
            {
                hit = h;
            }
        }
        return hit;
    }
}
