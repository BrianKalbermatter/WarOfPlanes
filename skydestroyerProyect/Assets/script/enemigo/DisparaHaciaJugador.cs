using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class DisparaHaciaJugador : MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil
    public Transform puntoDisparo; // Punto de origen del disparo
    public float velocidadProyectil = 10f; // Velocidad del proyectil
    public float frecuenciaDisparo = 1f; // Frecuencia de disparo en segundos
    public int cantidadMaximaBalas = 10; // Cantidad máxima de balas en el pool
    public float tiempoDeVidaBala = 5f; // Tiempo de vida de las balas
    private float tiempoUltimoDisparo = 0f; // Tiempo del último disparo
    private Transform jugador; // Referencia al transform del jugador
    private List<GameObject> poolBalas = new List<GameObject>();

    private void Start()
    {
        // Encuentra el GameObject del jugador por su etiqueta
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;

        // Crea el pool de balas
        for (int i = 0; i < cantidadMaximaBalas; i++)
        {
            GameObject bala = Instantiate(proyectilPrefab);
            bala.SetActive(false);
            poolBalas.Add(bala);
        }
    }

    private void Update()
    {
        // Comprueba si ha pasado suficiente tiempo desde el último disparo
        if (Time.time - tiempoUltimoDisparo > frecuenciaDisparo)
        {
            // Encuentra una bala del pool que no esté en uso
            GameObject bala = poolBalas.Find(x => !x.activeSelf);

            if (bala != null)
            {
                // Calcula la dirección hacia el jugador
                Vector3 direccion = (jugador.position - transform.position).normalized;

                // Calcula la rotación para apuntar al jugador
                Quaternion rotacion = Quaternion.LookRotation(direccion);

                // Configura la posición y rotación de la bala
                bala.transform.position = puntoDisparo.position;
                bala.transform.rotation = rotacion;

                // Activa la bala
                bala.SetActive(true);

                // Establece su velocidad
                Rigidbody rb = bala.GetComponent<Rigidbody>();
                rb.velocity = direccion * velocidadProyectil;

                // Programa la desactivación de la bala después de un tiempo
                StartCoroutine(DesactivarBala(bala));
                
                // Actualiza el tiempo del último disparo
                tiempoUltimoDisparo = Time.time;
            }
        }
    }

    // Coroutine para desactivar la bala después de un tiempo
    private IEnumerator DesactivarBala(GameObject bala)
    {
        yield return new WaitForSeconds(tiempoDeVidaBala);
        bala.SetActive(false);
    }
}