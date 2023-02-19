using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win_cond : MonoBehaviour
{

    public GameObject button;
    public GameObject door;
    private bool isPressed = false;

    private void Update()
    {
        if (isPressed)
        {
            Destroy(door);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("button"))
        {
            Destroy(button);

            isPressed = true;
        }
        if(collision.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }


}
