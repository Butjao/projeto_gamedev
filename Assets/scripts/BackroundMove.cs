using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackroundMove : MonoBehaviour
{
    public float moveSpeed =  2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * -1 * moveSpeed * Time.deltaTime);

        if (transform.position.x < -12.66)
        {
            transform.position = new Vector2(11.8f, transform.position.y);
        }
    }
}
