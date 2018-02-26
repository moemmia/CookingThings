using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongTheCinta : MonoBehaviour {

    public float velocity = 1f;

    private Vector3[] vert; //Vertices del objeto base
    private IDictionary<GameObject,int> objs= new Dictionary<GameObject, int>(); // Objeto y vertice actual

    // Use this for initialization
    void Start () {
        vert = GetComponent<MeshFilter>().mesh.vertices;
    }

    // Update is called once per fixed frame
    void FixedUpdate () {
        velocity = Mathf.Abs(velocity);
        List<GameObject> toInc = new List<GameObject>();
        foreach (GameObject gm in objs.Keys) {
            Vector3 vertice = transform.TransformPoint(vert[objs[gm]]);
            gm.transform.position = Vector3.MoveTowards(gm.transform.position, vertice, velocity/100);
            if (Vector3.Distance(gm.transform.position, vertice) < 0.1f+gm.GetComponent<MeshFilter>().mesh.bounds.extents.y)
            {
                
                    toInc.Add(gm);
            }
        }
        foreach(GameObject gm in toInc)
        {
            objs[gm] = objs[gm] >= vert.Length - 1 ? 0 : objs[gm] + 1;
        }

    }


    //Asigna un objeto a la pila de objetos a mover
    public void assingMe(GameObject gm)
    {
        if (objs.ContainsKey(gm)) return;
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

    public void releaseMe(GameObject gm)
    {
        objs.Remove(gm);
    }
}
