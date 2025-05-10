using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPlatformer : MonoBehaviour
{
    // Titik tujuan pertama dan kedua untuk patroli musuh
    public Transform PointTujuan1, PointTujuan2;
    public float speed; // Kecepatan pergerakan musuh

    private Rigidbody2D rb;
    private Transform target;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Mengambil komponen Rigidbody2D yang ada pada GameObject ini
        rb = GetComponent<Rigidbody2D>();

        // Awalnya musuh bergerak menuju titik tujuan pertama
        target = PointTujuan1;

        // Mengambil komponen SpriteRenderer untuk mengubah orientasi sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   void FixedUpdate()
    {
        // Menentukan arah gerakan berdasarkan posisi target saat ini
        float direction = Mathf.Sign(target.position.x - transform.position.x);

        // Menggerakkan musuh ke arah target dengan kecepatan tertentu
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        // Jika musuh telah mencapai target (jarak kurang dari 0.5)
        if (Vector2.Distance(transform.position, target.position) < 0.5f)
        {
            // Mengubah target ke titik sebaliknya
            target = (target == PointTujuan1) ? PointTujuan2 : PointTujuan1;

            // Memanggil fungsi Flip() untuk membalik arah sprite
            Flip();
        }
    }

    void Flip()
    {
        // Membalik sprite saat musuh berubah arah
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
