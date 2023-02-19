using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed = 4f;
    public Transform posA, posB;
    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,posA.position) < .1f) targetPos = posB.position;

        if(Vector2.Distance(transform.position,posB.position) < .1f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
