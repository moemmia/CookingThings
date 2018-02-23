using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachOnTouch : MonoBehaviour {

   public GameObject rail;
   private MoveAlongTheCinta mov;
    // Use this for initialization
    void Start () {
        mov= rail.GetComponent<MoveAlongTheCinta>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        mov.assingMe(other.gameObject);
    }
}
