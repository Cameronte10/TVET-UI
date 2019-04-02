using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {
    public DelayHealth health;
    public bool attacked, check;
    public float difference;
    public Transform curCheckpoint;
	// Use this for initialization
	void Start () {
        health = GetComponent<DelayHealth>();
        
	}

    private void Update()
    {
        if (attacked)
        {
            if (!check)
            {
                difference = health.curHealth - 25;
                check = true;
            }
            if (health.curHealth > difference)
            {
                health.curHealth -= 25 * Time.deltaTime;
            }
            else
            {
                attacked = false;
                check = false;
            }
        }
        if (health.curHealth <=0 )
        {
            gameObject.transform.position = curCheckpoint.position;
            health.curHealth = health.maxHealth;
            attacked = false;
            check = false;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Damage"))
        {
            //health.curHealth -= 25;
            attacked = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Heal"))
        {
            health.curHealth += Time.deltaTime * 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            curCheckpoint = other.transform;
        }
    }
}
