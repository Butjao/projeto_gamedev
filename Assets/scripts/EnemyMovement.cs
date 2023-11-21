using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;

    private float moveSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * -1 * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collisor)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        animator.SetBool("isDead", true);
        Destroy(gameObject, 1f);
    }
}
