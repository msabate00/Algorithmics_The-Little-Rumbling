using UnityEngine;

public class Camara2D : MonoBehaviour
{
    
    public Transform Capuchin;

    void LateUpdate()
    {
        if (Capuchin != null)
        {
            // Mueve la cámara a la posición X e Y del jugador, pero mantiene el eje Z en -10
            transform.position = new Vector3(Capuchin.position.x, Capuchin.position.y, -10f);
        }
    }
}