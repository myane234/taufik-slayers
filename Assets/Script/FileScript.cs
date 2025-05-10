using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika peluru mengenai musuh, hancurkan musuh dan peluru
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Hancurkan musuh
            Destroy(gameObject); // Hancurkan peluru
        }
        // Jika peluru menyentuh player, jangan dihancurkan
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject); // Hancurkan peluru jika terkena objek lain selain Player
        }
    }
}
