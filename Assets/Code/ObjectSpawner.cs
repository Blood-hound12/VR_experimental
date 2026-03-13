using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Configuracion del Objeto")]
    public GameObject[] prefabsParaCaer;

    [Header("Ajustes de Tiempo")]
    public float minTime = 1f;
    public float maxTime = 5f;

    [Header("Área de Caída")]
    public float spawnRadius = 10f;

    float waitTime = 3f;

    private void Start()
    {
        waitTime = maxTime; 
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
           
            //float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            waitTime -= 0.125f;
            waitTime = Mathf.Clamp(waitTime,0.07f,100);

            Vector3 randomPos = transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));

            int indiceAleatorio = Random.Range(0, prefabsParaCaer.Length);
            GameObject objetoElegido = prefabsParaCaer[indiceAleatorio];

            Instantiate(objetoElegido, randomPos, Quaternion.Euler(Random.Range(0, 360),0,0));

            //Vector3 playerPos = Camera.main.transform.position;

            //float safeRadius = 2.0f;

            //Vector2 randomDir = Random.insideUnitCircle.normalized;

            //float distance = Random.Range(safeRadius, spawnRadius);

            //Vector3 spawnPos = new Vector3(playerPos.x + (randomDir.x * distance), transform.position.y, playerPos.z + (randomDir.y * distance));

            //Instantiate(objectPrefab, spawnPos, Random.rotation);
        }
    }
}
