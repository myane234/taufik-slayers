using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerMovementPlatformer : MonoBehaviour
{
    public float speed; // atur speed
    public float jumpForce; // atur kekuatan loncat
    public LayerMask groundLayer; // layer tanah
    public Transform groundCheck; // posisi untuk mengecek tanah
    public Transform firePoint; // posisi untuk

    private Rigidbody2D rb; // komponen rigidbody
    private bool isGrounded; // apakah pemain berada di tanah
    private float moveInput; // input gerakan horizontal
    private SpriteRenderer spriteRenderer; // komponen sprite renderer
    private Animator animator; // komponen animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Mendapatkan input horizontal
        moveInput = Input.GetAxis("Horizontal");

        // Flip karakter saat bergerak kiri atau kanan
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
            firePoint.localPosition = new Vector3(1.7f, 0.6f, 0); // Posisi firePoint
            firePoint.localRotation = Quaternion.Euler(0, 0, 0); // Rotasi firePoint
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
            firePoint.localPosition = new Vector3(-1.7f, 0.6f, 0); // Posisi firePoint
            firePoint.localRotation = Quaternion.Euler(0, 180, 0); // Rotasi firePoint
        }

        // Cek apakah karakter berada di tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Animasi Jump
        animator.SetBool("isJumping", !isGrounded);

        // Melompat jika menekan tombol space dan berada di tanah
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Ganti linearVelocity dengan velocity
        }

        // Animasi Run
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y); // atur kecepatan rigidbody
    }
}
