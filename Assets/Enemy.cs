using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftbound = startPos.x - distance;
        float rightbound = startPos.x - distance;
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x < rightbound)
            {

                movingRight = false;
                Flip();
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                if (transform.position.x <= leftbound)
                {
                    movingRight = true;
                    Flip();
                }
            }
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}