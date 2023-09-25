using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionEnemigo : MonoBehaviour
{
    public Transform[] puntosDestino; // Lista de puntos de destino
    public float velocidad = 5f;
    public float cambioDeObjetivoIntervaloMin = 5f;
    public float cambioDeObjetivoIntervaloMax = 10f;
    public float rotacionSpeed = 2f; // Velocidad de rotación

    private Transform objetivoActual;
    private int indicePuntoDestino;
    private float tiempoHastaCambioObjetivo;

    void Start()
    {
        // Inicializamos el objetivo actual y el tiempo hasta el cambio de objetivo
        objetivoActual = GetRandomDestino();
        tiempoHastaCambioObjetivo = Random.Range(cambioDeObjetivoIntervaloMin, cambioDeObjetivoIntervaloMax);
    }

    void Update()
    {
        // Mueve el avión hacia el objetivo actual
        if (objetivoActual != null)
        {
            Vector3 direccion = objetivoActual.position - transform.position;
            direccion.Normalize();

            // Rotamos el avión hacia la dirección en la que se está moviendo
            if (direccion != Vector3.zero)
            {
                Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * rotacionSpeed);
            }

            // Movemos el avión hacia adelante
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

            // Si el avión está cerca del objetivo, seleccionamos uno nuevo
            if (direccion.magnitude < 1f)
            {
                objetivoActual = GetRandomDestino();
            }
        }

        // Contamos el tiempo hasta el cambio de objetivo
        tiempoHastaCambioObjetivo -= Time.deltaTime;

        // Si ha pasado el tiempo, seleccionamos un nuevo objetivo
        if (tiempoHastaCambioObjetivo <= 0)
        {
            objetivoActual = GetRandomDestino();
            tiempoHastaCambioObjetivo = Random.Range(cambioDeObjetivoIntervaloMin, cambioDeObjetivoIntervaloMax);
        }
    }

    Transform GetRandomDestino()
    {
        // Elegimos un punto de destino aleatorio de la lista
        indicePuntoDestino = Random.Range(0, puntosDestino.Length);
        return puntosDestino[indicePuntoDestino];
    }
}