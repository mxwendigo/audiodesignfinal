using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    public Animator playerAnim;
    public int health;
    public GameObject gameOverScene;
    public bool gameIsOver;

    void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver == false)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();
            rb2d.linearVelocity = moveInput * moveSpeed;

            if (Input.GetKey(KeyCode.D))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                playerAnim.Play("playerHammer");
            }
            if (Input.GetKey(KeyCode.F))
            {
                playerAnim.Play("playerSword");
            }

        }

        if (health <= 0)
        {
            gameIsOver = true;
            moveSpeed = 0;
            moveInput.Normalize();
            rb2d.linearVelocity = moveInput * moveSpeed;
            gameOverScene.SetActive(true);

        }



    }

    public void playerGetsHurt()
    {
        health--;
        playerAnim.Play("playerHurt");
    }

    public void resetPlayerPosition()
    {
        transform.position = new Vector3(-2, 0, 0);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}