using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J23Generator : MonoBehaviour {
    public GameObject prefabJ23;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Generar", 1,5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Generar()
    {
        Instantiate(prefabJ23, transform);
    }
}
