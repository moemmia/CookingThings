using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBrazos : MonoBehaviour {

    public List<GameObject> brazos = new List<GameObject>();
    public List<Vector3> rotation = new List<Vector3>();
    // Use this for initialization
    void Start () {
		
	}

    // LateUpdate is called once per frame at the end
    void LateUpdate() {
        for(int i=0; i< rotation.Count; i++) {
            brazos[i].transform.localRotation= Quaternion.Euler(rotation[i]);
        }
	}
}
