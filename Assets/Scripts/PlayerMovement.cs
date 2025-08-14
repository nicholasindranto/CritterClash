using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // reference ke animator dan rigidbody2d nya
    public Animator animator;
    private Rigidbody2D rb;

    // kecepatan dia lari
    public float speed = 5f;

    // kekuatan jump nya
    public float jumpForce = 7f;

    // apakah nyentuh tanah
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // ambil dulu komponen rigidbodynya
    }

    private void Update()
    {
        // movement horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");

        // kita set kecepatannya
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        // kita flip karakternya
        if (moveHorizontal > 0)
        {
            // kanan
            transform.localScale = new Vector3(3, 3, 3); // karakternya tetap di kanan
        }
        else if (moveHorizontal < 0)
        {
            // kiri
            transform.localScale = new Vector3(-3, 3, 3); // karakternya tetap di kiri
        }

        // update animator
        // kalau sama dengan 0, maka dia diem dan idle
        animator.SetBool("isRunning", Mathf.Abs(moveHorizontal) > 0);

        // jumping hanya saat dia kaga nyentuh tanah
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // set kecepatan lompatnya
            animator.SetBool("isJumping", true); // set animatornya
            animator.SetBool("isFalling", false);
            isGrounded = false; // karna dia sekarang lagi di udara
        }

        // update pas dia lagi turun
        if (rb.velocity.y < 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // pas udah nyampe tanah
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // uda nyampe tanah
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }
}
