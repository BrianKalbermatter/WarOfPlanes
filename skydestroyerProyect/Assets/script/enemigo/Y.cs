using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento
    private bool moverArriba = true; // Variable para determinar la dirección del movimiento

    void Update()
    {
        // Verificamos si el objeto ha llegado a su límite superior (50 en positivo) o inferior (-50 en negativo)
        if (transform.position.y >= 50f)
        {
            moverArriba = false; // Cambiamos la dirección hacia abajo
        }
        else if (transform.position.y <= -50f)
        {
            moverArriba = true; // Cambiamos la dirección hacia arriba
        }

        // Movemos el objeto en la dirección adecuada
        if (moverArriba)
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }
    }
}