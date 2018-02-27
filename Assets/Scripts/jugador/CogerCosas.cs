using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerCosas : MonoBehaviour {

    GameObject attached;
    RaycastHit hit=new RaycastHit();
    public float radius;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate() {
        Ray ray = new Ray(transform.position+Vector3.up, Vector3.down);
        Physics.SphereCast(ray,1f, out hit);
       //Physics.Raycast(transform.position, Vector3.down, out hit); 
        if (Input.GetKeyDown(KeyCode.E)) //No Haardcodear por favor, arreglalo cunado todo funcione
        {
            if (attached == null)
            {
                if (hit.transform!=null && hit.transform.tag.Equals("obj"))
                {
                    attached = hit.transform.gameObject;
                    GameObject.FindGameObjectWithTag("seguidor").GetComponent<MoveAlongTheCinta>().releaseMe(attached);
                    this.GetComponent<testBrazos>().enabled = true;
                    attached.GetComponent<Rigidbody>().isKinematic = true;
                    foreach (Collider c in hit.transform.GetComponents<Collider>())
                        c.enabled = false;
                }
            }
            else
            {
                this.GetComponent<testBrazos>().enabled = false;
                attached.GetComponent<Rigidbody>().isKinematic = false;
                foreach (Collider c in attached.GetComponents<Collider>())
                {
                    c.enabled = true;
                } 
                attached = null;

            }
        }
        else
        {
            if (attached == null && hit.transform != null && hit.transform.tag.Equals("obj"))
                {
                    //dar una indicación visual de que se puede interactuar con el objeto.
                }
        }
        if (attached != null)
        {
            attached.transform.position = this.transform.position;

        }

    }
}
