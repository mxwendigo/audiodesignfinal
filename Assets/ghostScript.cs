using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool moving;
    public GameObject Player;
    public float speed = 2.0f;
    public float knockbackForce;
    public Rigidbody2D rb;
    public int health;

    public Animator ghostAnim;
    public TopDownScript playerScript;
    public sceneManagerScript sceneScript;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.gameIsOver == false)
        {
            moving = true;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {

            if (sceneScript.newSword == true)
            {
                health -= 2;
            }
            else
            {
                health--;
            }


            ghostAnim.Play("ghostHurt");
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -150 * Time.deltaTime);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.playerGetsHurt();
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -150 * Time.deltaTime);
        }
    }
}