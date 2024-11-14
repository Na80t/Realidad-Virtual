using UnityEngine;
using UnityEngine.XR;

public class katana : MonoBehaviour
{
    private XRNode rightHandNode = XRNode.RightHand; // Nodo del controlador derecho
    private bool isHeld = false; // Verifica si la katana está siendo agarrada
    private bool isPositionSet = false; // Verifica si la posición inicial ya fue asignada
    public FruitCounter fruitCounter; // Referencia al script FruitCounter

    
    public Vector3 positionOffset = new Vector3(0.025f, -0.066f, 0.173f); 
    public Vector3 rotationOffset = new Vector3(0f, 0f, 90f); 

    private void Start()
    {
       
        if (fruitCounter == null)
        {
            Debug.LogError("El contador de frutas no está asignado al script de la katana.");
        }
    }

    private void Update()
    {
        // Solo actualiza la katana si está siendo agarrada
        if (isHeld)
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(rightHandNode);

            if (device.isValid)
            {
                device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
                device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

                // Solo actualiza la posición y rotación después del primer frame
                if (isPositionSet)
                {
                    
                    transform.position = position + positionOffset;

                    
                    transform.rotation = rotation * Quaternion.Euler(rotationOffset);
                }
                else
                {
                    isPositionSet = true; // Marca que la posición inicial ha sido configurada
                }

                // Log para verificar que el controlador se está actualizando
                Debug.Log("Katana Position: " + position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si la katana colisiona con la mano, marca como agarrada
        if (other.CompareTag("Hand"))
        {
            isHeld = true;
        }

        // Si la katana colisiona con una fruta
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);

            // Verificar si el contador está asignado y actualizar
            if (fruitCounter != null)
            {
                fruitCounter.IncreaseFruitCount(); // Llama al método del contador
                Debug.Log("Fruta cortada, total de frutas cortadas: " + fruitCounter.fruitCount);
            }
            else
            {
                Debug.LogError("El contador de frutas no está asignado.");
            }

            Debug.Log("Fruit destroyed by katana!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si la mano deja de tocar la katana, deja de seguir el controlador
        if (other.CompareTag("Hand"))
        {
            isHeld = false;
        }
    }
}

    
    /*private void Start()
    {
        // Establece la posición inicial deseada al inicio del juego
        transform.position = new Vector3(15.1f, 1.71f, 24.63f);
        
        transform.rotation = Quaternion.Euler(-89.98f, 0f, 0f);

        // Verificar si el contador de frutas está correctamente asignado
        if (fruitCounter == null)
        {
            Debug.LogError("El contador de frutas no está asignado al script de la katana.");
        }
    }

    private void Update()
    {
        // Solo actualiza la katana si está siendo agarrada
        if (isHeld)
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(rightHandNode);

            if (device.isValid)
            {
                device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
                device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

                // Solo actualiza la posición y rotación después del primer frame
                if (isPositionSet)
                {
                    transform.position = position;
                    transform.rotation = rotation;
                }
                else
                {
                    isPositionSet = true; // Marca que la posición inicial ha sido configurada
                }

                // Log para verificar que el controlador se está actualizando
                Debug.Log("Katana Position: " + position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si la katana colisiona con la mano, marca como agarrada
        if (other.CompareTag("Hand"))
        {
            isHeld = true;
        }

        // Si la katana colisiona con una fruta
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);

            // Verificar si el contador está asignado y actualizar
            if (fruitCounter != null)
            {
                fruitCounter.IncreaseFruitCount(); // Llama al método del contador
                Debug.Log("Fruta cortada, total de frutas cortadas: " + fruitCounter.fruitCount);
            }
            else
            {
                Debug.LogError("El contador de frutas no está asignado.");
            }

            Debug.Log("Fruit destroyed by katana!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si la mano deja de tocar la katana, deja de seguir el controlador
        if (other.CompareTag("Hand"))
        {
            isHeld = false;
        }
    }
}*/
