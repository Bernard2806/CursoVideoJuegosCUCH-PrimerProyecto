using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
        public GameObject platformPrefab; // Prefab de la plataforma
    public int maxPlatforms = 15;     // Número máximo de plataformas a generar
    public float spawnInterval = 1f;  // Intervalo entre generaciones de plataformas
    public float minSpacing = 10f;    // Espacio mínimo entre plataformas
    public float maxSpacing = 12f;    // Espacio máximo entre plataformas
    public float minHeight = -2f;     // Altura mínima para las plataformas
    public float maxHeight = 2f;      // Altura máxima para las plataformas
    public float minHeightDifference = 1f; // Diferencia mínima en altura entre plataformas

    private float timer;
    private int currentPlatformCount = 0;  // Contador actual de plataformas en la escena
    private Vector3 nextPosition;          // Posición para generar la siguiente plataforma
    private float lastHeight;              // Altura de la última plataforma generada

    void Start()
    {
        // Inicializa la posición de la primera plataforma en la posición del objeto padre
        nextPosition = transform.position;

        // Genera la primera plataforma al inicio
        SpawnPlatform();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentPlatformCount < maxPlatforms)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        // Genera la altura para la siguiente plataforma asegurando que haya una diferencia de altura suficiente
        float randomHeight;
        do
        {
            randomHeight = Random.Range(minHeight, maxHeight);
        } while (Mathf.Abs(randomHeight - lastHeight) < minHeightDifference);

        // Ajusta la posición en Y con la altura aleatoria
        nextPosition.y = lastHeight + randomHeight;

        // Calcula el espaciado aleatorio asegurando que sea lo suficientemente lejos en el eje Z
        float randomSpacing = Random.Range(minSpacing, maxSpacing);
        nextPosition.z += randomSpacing;

        // Instancia la plataforma en la posición calculada
        Instantiate(platformPrefab, nextPosition, Quaternion.identity);

        // Actualiza la altura de la última plataforma generada
        lastHeight = nextPosition.y;

        // Incrementa el contador de plataformas
        currentPlatformCount++;
    }

    public void RemovePlatform()
    {
        // Método para eliminar una plataforma (puedes llamar a esto para reducir el conteo)
        if (currentPlatformCount > 0)
        {
            // Encuentra la última plataforma instanciada y destrúyela
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            if (platforms.Length > 0)
            {
                Destroy(platforms[platforms.Length - 1]);
                currentPlatformCount--;
            }
        }
    }
}
