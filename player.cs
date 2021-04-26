using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D Rb;

    public Rigidbody2D Ra;
    public float speed = 30f;
    public float x,y;
    // Start is called before the first frame update
    void Start()
    {
        Ra = GetComponent<Rigidbody2D>();
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        Ra.AddForce(Vector2.up * speed * y);
        Rb.AddForce(Vector2.right * speed * x);
    }
}
