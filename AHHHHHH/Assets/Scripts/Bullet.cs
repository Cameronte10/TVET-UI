using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1000;
    public byte r, g, b;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.up * speed);
        r = (byte) Random.Range(0, 255);
        g = (byte) Random.Range(0, 255);
        b = (byte)Random.Range(0, 255);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
