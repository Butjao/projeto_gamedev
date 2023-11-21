using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator animator;
    public GameObject bullet;
    public Transform firepointPosition;
    private float moveSpeed = 5f;
    private Animator animatorObj;
    public int lives = 3;
    public Image[] hearts;
    public Sprite cheio;
    public Sprite vazio;

    // Start is called before the first frame update
    void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>();
        animatorObj = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++) { 
            if (i < lives)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

        if(lives > -1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log('a');
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.up * -1 * moveSpeed * Time.deltaTime);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
       
    }

    void Shoot()
    {
        Instantiate(bullet, firepointPosition.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collisor)
    {
        if(collisor.gameObject.CompareTag("asteroid"))
        {
            lives--;
            if (lives < 0)
            {
                animatorObj.SetBool("dead", true);
                GameObject.Find("GameManager").GetComponent<GameOverScript>().GameOver();
                
            } else
            {
                animatorObj.SetBool("damaged", true);
            }
        }
    }

   
}
