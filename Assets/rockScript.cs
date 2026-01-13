using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScript : MonoBehaviour
{
    public int health = 2;
    public sceneManagerScript sceneScript;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] mineClips;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hammer"))
        {
            if (audioSource != null && mineClips.Length > 0)
            {
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(
                    mineClips[Random.Range(0, mineClips.Length)]
                );
            }

            if (sceneScript.newHammer == true)
            {
                health -= 2;
            }
            else
            {
                health--;
            }

        }
    }
}