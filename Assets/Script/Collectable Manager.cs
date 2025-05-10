using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    // Membuat instance statis agar bisa diakses dari skrip lain tanpa perlu referensi manual
    public static CollectableManager Instance; 
    private int coinCount; // Variabel untuk menyimpan jumlah koin yang dikumpulkan pemain
    public TextMeshProUGUI coinText; // Referensi ke UI Text yang akan menampilkan jumlah koin

    // Fungsi Awake dipanggil pertama kali sebelum Start
    private void Awake()
    {
        // Jika Instance masih null, atur Instance ke objek ini
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Fungsi Start dipanggil saat game mulai
    private void Start()
    {
        // Memastikan UI koin diperbarui dengan nilai awal
        UpdateCoinUI();
    }
   // Fungsi untuk menambahkan koin dan memperbarui UI
    public void AddCoin(int amount)
    {
        coinCount += amount; // Menambahkan jumlah koin
        UpdateCoinUI(); // Memperbarui tampilan UI
    }

    // Fungsi untuk memperbarui teks pada UI koin
    private void UpdateCoinUI()
    {
        coinText.text = coinCount.ToString(); // Menampilkan jumlah koin saat ini
    }
}
