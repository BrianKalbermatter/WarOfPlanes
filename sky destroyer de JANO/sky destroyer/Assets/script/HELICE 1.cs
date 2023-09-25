using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HELICE1 : MonoBehaviour
{
    public float velocidadRotacion = 500.0f; // Velocidad de rotación de las hélices

    // Update se llama una vez por frame
    void Update()
    {
        // Girar las hélices en el eje Y
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}