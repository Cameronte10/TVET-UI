using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
