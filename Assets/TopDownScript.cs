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
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] footstepClips;
    private float footstepTimer;
    public float footstepDelay = 0.4f;
    public AudioClip swordSwish;



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

            if (moveInput.magnitude > 0)
            {
                footstepTimer -= Time.deltaTime;

                if (footstepTimer <= 0)
                {
                    PlayFootstep();
                    footstepTimer = footstepDelay;
                }
            }


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
                PlaySwordSwish();
                audioSource.PlayOneShot(swordSwish, 0.2f);
            
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

    void PlayFootstep()
    {
        if (audioSource == null) return;
        if (footstepClips.Length == 0) return;

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(
            footstepClips[Random.Range(0, footstepClips.Length)]
        );
    }
    void PlaySwordSwish()
    {
        if (audioSource == null || swordSwish == null) return;

        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(swordSwish);
    }


}