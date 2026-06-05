using UnityEngine;

public class EnemigoDispara : MonoBehaviour
{
    public GameObject prefabProyectil; 
    public Transform jugador;          
    public Transform puntoDisparo;    

    public float velocidadProyectil = 5f;
    public float tiempoEntreDisparos = 2f;
    private float cronometro;

    void Update()
    {
        if (jugador == null) return;

        cronometro += Time.deltaTime;

        if (cronometro >= tiempoEntreDisparos)
        {
            Disparar();
            cronometro = 0f;
        }
    }

    void Disparar()
    {
        
        GameObject nuevaBala = Instantiate(prefabProyectil, puntoDisparo.position, Quaternion.identity);

        
        Vector2 direccion = (jugador.position - puntoDisparo.position).normalized;

        
        Proyectil scriptProyectil = nuevaBala.GetComponent<Proyectil>();
        if (scriptProyectil != null)
        {
            scriptProyectil.Lanzar(direccion, velocidadProyectil);
        }
    }
}

public class EnemigoDisparo : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject proyectilPrefab; 
    public Transform puntoDisparo;     
    public float velocidadBala = 10f;

    
    public void DispararProyectil()
    {
        
        GameObject bala = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = puntoDisparo.forward * velocidadBala;
        }
    }
}