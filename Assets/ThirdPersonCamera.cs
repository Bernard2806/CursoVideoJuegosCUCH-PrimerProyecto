using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // El objetivo que la cámara seguirá (la esfera)
    public Vector3 offset; // El desplazamiento de la cámara desde el objetivo

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            Debug.LogError("El objetivo (target) no está asignado en el script ThirdPersonCamera.");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Mantiene la cámara en una posición fija con respecto al objetivo
            transform.position = target.position + offset;

            // La cámara siempre debe mirar hacia el objetivo
            transform.LookAt(target.position);
        }
    }
}
