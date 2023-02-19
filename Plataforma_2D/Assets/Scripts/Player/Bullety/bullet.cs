using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private float speed = 30f;
    private int dmg = 30;
    public Rigidbody2D rb;

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(WaitToDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
