using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaGrab : MonoBehaviour
{
    private bool isHeld = false; // Indica si la katana está siendo agarrada
    private Transform controllerTransform; // El controlador que agarra la katana

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con: " + other.name); // Depuración para ver si detecta colisión

        
        if (other.CompareTag("Controller"))
        {
            isHeld = true;
            controllerTransform = other.transform;
            Debug.Log("Katana agarrada por controlador: " + other.name); // Depuración cuando se agarra la katana
        }
        else
        {
            Debug.LogWarning("El objeto que tocó la katana no tiene el tag 'Controller'");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            isHeld = false;
            controllerTransform = null;
            Debug.Log("Katana soltada");
        }
    }

    void Update()
    {
        if (isHeld && controllerTransform != null)
        {
            Debug.Log("Katana sigue al controlador");
            transform.position = controllerTransform.position;
            transform.rotation = controllerTransform.rotation;
        }
    }
}
