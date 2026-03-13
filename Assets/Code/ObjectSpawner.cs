using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Configuracion del Objeto")]
    public GameObject objectPrefab;

    [Header("Ajustes de Tiempo")]
    public float minTime = 1f;
    public float maxTime = 5f;

    [Header("Área de Caída")]
    public float spawnRadius = 10f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            Vector3 randomPos = transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));

            Instantiate(objectPrefab, randomPos, Quaternion.Euler(Random.Range(0, 360),0,0));

            //Vector3 playerPos = Camera.main.transform.position;

            //float safeRadius = 2.0f;

            //Vector2 randomDir = Random.insideUnitCircle.normalized;

            //float distance = Random.Range(safeRadius, spawnRadius);

            //Vector3 spawnPos = new Vector3(playerPos.x + (randomDir.x * distance), transform.position.y, playerPos.z + (randomDir.y * distance));

            //Instantiate(objectPrefab, spawnPos, Random.rotation);
        }
    }
}
