using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;   // Prefab del cubo
    public int maxCubes = 100;      // Número máximo de cubos a generar
    public float spawnInterval = 1f; // Intervalo entre generaciones de cubos
    public float spacing = 10f;     // Espacio entre cubos en la línea (mínimo 10)
    public float minHeight = 0f;    // Altura mínima para los cubos
    public float maxHeight = 5f;    // Altura máxima para los cubos

    private float timer;
    private int currentCubeCount = 0;  // Contador actual de cubos en la escena
    private Vector3 startPosition;     // Posición inicial para generar la línea de cubos

    void Start()
    {
        // Inicializa la posición de inicio
        startPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval && currentCubeCount < maxCubes)
        {
            SpawnCube();
            timer = 0f;
        }
    }

    void SpawnCube()
    {
        // Calcula la posición del nuevo cubo en una línea recta
        Vector3 spawnPosition = startPosition + Vector3.forward * (currentCubeCount * spacing);

        // Genera una altura aleatoria dentro del rango definido
        float randomHeight = Random.Range(minHeight, maxHeight);

        // Ajusta la posición del cubo con la altura aleatoria
        spawnPosition.y += randomHeight;

        // Instancia el cubo en la posición calculada
        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);

        currentCubeCount++;  // Incrementa el contador de cubos
    }

    public void RemoveCube()
    {
        // Método para eliminar un cubo (puedes llamar a esto para reducir el conteo)
        if (currentCubeCount > 0)
        {
            // Encuentra el último cubo instanciado y destrúyelo
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
            if (cubes.Length > 0)
            {
                Destroy(cubes[cubes.Length - 1]);
                currentCubeCount--;
            }
        }
    }
}
