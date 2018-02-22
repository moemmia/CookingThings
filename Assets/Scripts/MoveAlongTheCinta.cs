using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveAlongTheCinta : MonoBehaviour {


    private Vector3[] vert;
    public float velocity=0.1f;
    private IDictionary<GameObject,int> objs= new Dictionary<GameObject, int>(); // Objeto y vertice actual
    // Use this for initialization
    void Start () {
        vert = GetComponent<MeshFilter>().mesh.vertices;
        assingMe(GameObject.FindGameObjectWithTag("Player"));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        List<GameObject> toInc = new List<GameObject>();
        foreach (GameObject gm in objs.Keys) {
            Vector3 vertice = transform.TransformPoint(vert[objs[gm]]);
            float distSqr = Vector3.Distance( gm.transform.position, vertice);
            gm.transform.position = Vector3.MoveTowards(gm.transform.position, vertice, velocity);
            if (distSqr < 0.1f)
            {
                
                    toInc.Add(gm);
            }
        }
        foreach(GameObject gm in toInc)
        {
            if (objs[gm] >= vert.Length - 1)
            {
                objs[gm] = 0;
            }
            else
                objs[gm]++;
            Debug.Log(objs[gm]);
        }

    }

    public void assingMe(GameObject gm)
    {
        float minDistanceSqr = Mathf.Infinity;
        int nearestVertex = -1;
        for(int i=0; i< vert.Length; i++)
        {
            float distSqr = Vector3.Distance(gm.transform.position, transform.TransformPoint(vert[i]));
            if (distSqr < minDistanceSqr)
            {
                minDistanceSqr = distSqr;
                nearestVertex = i;
            }
        }
        objs.Add(gm, nearestVertex);
    }
}
