using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpheres : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = new Vector3(Random.Range(-35, 35), Random.Range(25, 55), Random.Range(-35, 35));
    }
}
