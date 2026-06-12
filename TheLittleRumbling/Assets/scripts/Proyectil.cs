using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    public void Lanzar(Vector2 direccion, float velocidad)
    {
        rb.linearVelocity = direccion * velocidad; 

        
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }
}
