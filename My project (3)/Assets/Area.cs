using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Collider area;
    public GameObject[] fruit;
    public float minArea = 1.5f;
    public float maxArea = 2.5f;

    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce = 7f;
    public float maxForce = 8f;

    public float maxLifeTime = 5f;

    private void Awake()
    {
        area = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(areaa());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator areaa()
    {
        yield return new WaitForSeconds(2f);

        // Verificar que el array no esté vacío
        if (fruit == null || fruit.Length == 0)
        {
            Debug.LogError("No hay frutas (ni bombas) asignadas en el array 'fruit'.");
            yield break;
        }

        while (enabled)
        {
            GameObject fruitToSpawn = fruit[Random.Range(0, fruit.Length)];

            // Reducir el área de aparición
            float areaReductionFactor = 0.01f; 

            Vector3 spawnPosition = new Vector3();
            spawnPosition.x = Random.Range(area.bounds.min.x + area.bounds.size.x * (1 - areaReductionFactor) / 2, area.bounds.max.x - area.bounds.size.x * (1 - areaReductionFactor) / 2);
            spawnPosition.y = Random.Range(area.bounds.min.y + area.bounds.size.y * (1 - areaReductionFactor) / 2, area.bounds.max.y - area.bounds.size.y * (1 - areaReductionFactor) / 2);
            spawnPosition.z = Random.Range(area.bounds.min.z + area.bounds.size.z * (1 - areaReductionFactor) / 2, area.bounds.max.z - area.bounds.size.z * (1 - areaReductionFactor) / 2);

            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruitInstance = Instantiate(fruitToSpawn, spawnPosition, spawnRotation);
            Destroy(fruitInstance, maxLifeTime);

            float force = Random.Range(minForce, maxForce);
            fruitInstance.GetComponent<Rigidbody>().AddForce(fruitInstance.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minArea, maxArea));
        }
    }
}
