using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Importar TextMeshPro

public class FruitCounter : MonoBehaviour
{
    public int fruitCount = 0;  // Contador de frutas cortadas
    public TextMeshProUGUI fruitCountText; // Campo de texto con TextMeshPro

    private void Start()
    {
        UpdateFruitCountText();  // Actualiza el texto al iniciar

        // Verificar si el campo de texto está asignado
        if (fruitCountText == null)
        {
            Debug.LogError("El campo de texto para el contador de frutas no está asignado.");
        }
    }

    public void IncreaseFruitCount()
    {
        fruitCount++;
        UpdateFruitCountText();  // Actualiza el texto en la UI
        Debug.Log("Frutas cortadas: " + fruitCount);  // Muestra el conteo en la consola
    }

    private void UpdateFruitCountText()
    {
        if (fruitCountText != null)
        {
            // Actualiza el texto en pantalla con la cantidad de frutas cortadas
            fruitCountText.text = "Frutas cortadas: " + fruitCount.ToString();
        }
    }
}
