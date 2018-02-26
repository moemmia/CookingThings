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
       
        if (Input.GetKeyDown(KeyCode.E)) //No Haardcodear por favor, arreglalo cunado todo funcione Moisés
        {
            if(attached == null )
            {
                //QUE SEA UN AREA Y NO SOLO LA LÍNEA (MIRAR CapsuleCast) 
                if (Physics.Raycast(transform.position, Vector3.down, out hit))
                {
                    if (hit.transform.tag.Equals("obj"))
                    {
                        attached = hit.transform.gameObject;
                        GameObject.FindGameObjectWithTag("seguidor").GetComponent<MoveAlongTheCinta>().releaseMe(attached);
                        this.GetComponent<testBrazos>().enabled = true;
                        attached.GetComponent<Rigidbody>().isKinematic = true;
                        foreach (Collider c in hit.transform.GetComponents<Collider>())
                            c.enabled = false;
                    }
                }
            }
            else
            {
                this.GetComponent<testBrazos>().enabled = false;
                attached.GetComponent<Rigidbody>().isKinematic = false;
                foreach (Collider c in hit.transform.GetComponents<Collider>())
                    c.enabled = true;
                attached = null;
                
            }
        }
        if (attached != null)
        {
            attached.transform.position = this.transform.position;

        }

    }
}
