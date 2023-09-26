using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasJugador : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de la bala

    private void Update()
    {
        // Avanza la bala en la dirección hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}