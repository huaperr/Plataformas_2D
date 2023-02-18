using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class e_movement : MonoBehaviour
{

    Rigidbody2D rb;
    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            transform.Rotate(0, 0, 180);
        }
    }

}
