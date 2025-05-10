using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth; // Variabel Health maksimal player
    private int currentHealth; // Variabel Health saat ini
    public Image healthBarFill; // Referensi ke Image yang digunakan sebagai Health Bar Fill

    private void Start()
    {
        // Set health saat mulai game ke health maksimal
        currentHealth = maxHealth;
        UpdateHealthUI(); // Perbarui UI Health Bar
    }

    // Method untuk menerima damage dari enemy
    public void TakeDamage(int damage)
    {
         // Kurangi health dengan damage yang diterima
        currentHealth -= damage;
        
        // Pastikan health tidak kurang dari 0 atau lebih dari max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI(); // Perbarui tampilan UI Health Bar

        // Jika health habis, panggil fungsi Die()
        if (currentHealth <= 0)
        {
            Die();
        }
    }
   // Method untuk memperbarui tampilan Health Bar
    void UpdateHealthUI()
    {
        if (healthBarFill != null) // Pastikan healthBarFill telah diassign
        {
            // Hitung persentase HP yang tersisa
            float fillAmount = (float)currentHealth / maxHealth;

            // Ubah skala Health Bar berdasarkan HP
            healthBarFill.transform.localScale = new Vector3(fillAmount, 1, 1);
        }
    }

    // Method yang dipanggil ketika Player mati
    void Die()
    {
        Debug.Log("Player Mati!"); // Debug log untuk melihat jika player mati
        gameObject.SetActive(false); // Nonaktifkan player
    }
}
