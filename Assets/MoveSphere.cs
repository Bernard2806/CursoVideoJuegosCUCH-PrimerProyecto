using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    // Publicos de la Clase MoveSphere
    public float force = 150; // Fuerza Aplicada para el Movimiento
    public float jumpForce = 10; // Fuerza Aplicada para el Salto
    public LayerMask LayerSuelo; // Representa el Suelo
    public float DistanciaCheckPiso = 0.1f; // Distancia utilizada para verificar si esta en el Suelo

    // Privados de la Clase MoverSphere 
    private Rigidbody rb; // Objeto de RigidBody
    private bool EstaEnElPiso;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtiene los inputs para mover el Objeto
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forceVector = new Vector3(h, 0, v);
        rb.AddForce(forceVector * force * Time.deltaTime);

        //Verificacion si esta en el Suelo
        if(Input.GetButtonDown("Jump") && EstaEnElPiso) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    
    //Cuando esta en una Collision
    void OnCollisionEnter(Collision collision)
    {
        EstaEnElPiso = true;
    }
    //Cuando no esta en una Collision
    void OnCollisionExit(Collision other)
    {
        EstaEnElPiso = false;
    }
}
