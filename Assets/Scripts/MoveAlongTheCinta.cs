using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongTheCinta : MonoBehaviour {

    public Vector3 rotation;
    List<GameObject> thingsToMove= new List<GameObject>();
    public float velocity=1;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
       // Debug.DrawRay(this.transform.position, rotation.normalized, Color.red);
        foreach(GameObject obj in thingsToMove)
        {
            //obj.transform.position += rotation.normalized*10;
            obj.GetComponent<Rigidbody>().velocity=(rotation.normalized* velocity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        thingsToMove.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        thingsToMove.Remove(other.gameObject);
    }
}
