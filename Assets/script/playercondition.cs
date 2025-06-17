using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercondition : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            gameManager.Addsroce(1);

        }
        else if (collision.CompareTag("trap"))
        {
            gameManager.Gameover();
         
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.Gameover();

        }
    }
}
