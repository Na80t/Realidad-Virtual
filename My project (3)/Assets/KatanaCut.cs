using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaCut : MonoBehaviour
{
    public float cutDuration = 0.5f;  // Tiempo antes de destruir la fruta
    public FruitCounter fruitCounter;  // Referencia al script del contador de frutas
    public GameManager gameManager;  // Referencia al script del GameManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            StartCoroutine(CutFruit(other.gameObject));
        }
        else if (other.CompareTag("Bomb"))  // Si el jugador toca una bomba
        {
            // Llama al GameManager para restar vidas
            if (gameManager != null)
            {
                gameManager.LoseLife();
            }
            
            // Destruye la bomba después de tocarla
            Destroy(other.gameObject);
        }
    }

    private IEnumerator CutFruit(GameObject fruit)
    {
        Vector3 originalScale = fruit.transform.localScale;
        Vector3 cutScale = new Vector3(originalScale.x, originalScale.y / 2, originalScale.z);

        float elapsedTime = 0;
        while (elapsedTime < cutDuration)
        {
            if (fruit == null)  // Verifica si el objeto aún existe
                yield break;    // Salir del coroutine si ya fue destruido

            fruit.transform.localScale = Vector3.Lerp(originalScale, cutScale, elapsedTime / cutDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Incrementar el contador de frutas cortadas
        if (fruitCounter != null)
        {
            fruitCounter.IncreaseFruitCount();
        }

        // Destruir el objeto después de todo el procesamiento
        Destroy(fruit);
    }
}
