using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar el juego
using TMPro; // Para manejar el texto del contador de vidas

public class GameManager : MonoBehaviour
{
    public GameObject[] hearts;  // Los objetos de imagen de los corazones en la UI
    public TextMeshProUGUI livesText;  // Texto opcional para mostrar el número de vidas
    private int lives = 3;  // Número de vidas

    public GameObject gameOverMenu; // Menú de Game Over

    private void Start()
    {
        UpdateLivesUI();  // Actualiza el texto y corazones al iniciar
    }

    // Método para restar vidas cuando se toca una bomba
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLivesUI();  // Actualiza las vidas visualmente al perder una vida
        }

        if (lives == 0)
        {
            GameOver();  // Llama al Game Over cuando las vidas se terminan
        }
    }

    private void UpdateLivesUI()
    {
        // Actualizar corazones: desactiva los corazones a partir del número de vidas restantes
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].SetActive(true);  // Muestra los corazones correspondientes a las vidas restantes
            }
            else
            {
                hearts[i].SetActive(false);  // Oculta los corazones si las vidas se han perdido
            }
        }
    }

    // Método que se llama cuando se termina el juego
    private void GameOver()
    {
        gameOverMenu.SetActive(true);  // Muestra el menú de Game Over
        Time.timeScale = 0f;  // Pausa el juego
    }

    // Reinicia el juego
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Restablece el tiempo normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reinicia la escena actual
    }
}
