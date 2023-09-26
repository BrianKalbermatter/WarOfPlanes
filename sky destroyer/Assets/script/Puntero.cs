using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntero : MonoBehaviour
{
    public GameObject objetivo;

    public bool seguirPosicion;
    public float acercamientoPosicion = 0.5f;
    public bool seguirRotacion;
    public float acercamientoRotacion = 0.5f;

    void Update()
    {
        if (seguirPosicion)
        {
            transform.position = Vector3.Lerp(transform.position, objetivo.transform.position, acercamientoPosicion);
        }
        if (seguirRotacion)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, objetivo.transform.rotation, acercamientoRotacion);
        }
    }
}
