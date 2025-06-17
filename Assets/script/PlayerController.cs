using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float jumphigh = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isground;
    private Rigidbody2D rb;
    private Animator animator;
    private void Awake()
    {
        animator= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handmove();
        handjump();
        UpdateAnimation();
    }
    private void handmove()
    {
        float moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * movespeed, rb.velocity.y);
        if (moveinput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveinput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    private void handjump()
    {
        if (Input.GetButtonDown("Jump") && isground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumphigh);
        }
        isground = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
    private void UpdateAnimation()
    {
        bool isrun = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isjump = !isground;
        animator.SetBool("isrun", isrun);
        animator.SetBool("isjump",isjump);
    }
}
