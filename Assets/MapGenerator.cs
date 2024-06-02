using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject chestChunk;
    public GameObject[] chunks;
    public Transform player;
    public float spawnDistance = 10f;
    public float chunkWidth = 10f;

    private int spawnedChunks = 0;
    private int spawenChunks = 1;

    private List<Transform> activeChunks = new List<Transform>();

    private void Start()
    {
        // Den ersten Chunk auf der Startposition des Spielers spawnen
        // Vector3 spawnPosition = player.position;
        Vector3 spawnPosition = new Vector3(-27, 0, 0);
        Transform firstChunk = Instantiate(chunks[0], spawnPosition, Quaternion.identity).transform;
        activeChunks.Add(firstChunk);

        // Weitere Chunks spawnen
        for (int i = 1; i < 5; i++)
        {
            spawnPosition = firstChunk.position + Vector3.right * i * chunkWidth;
            Transform newChunk = Instantiate(chunks[0], spawnPosition, Quaternion.identity).transform;
            activeChunks.Add(newChunk);
        }
    }

    private void Update()
    {
        if (player.position.x > (activeChunks[4].position.x - spawnDistance))
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Vector3 spawnPosition = Vector3.right * (activeChunks.Count * chunkWidth);

        if (activeChunks.Count > 0)
        {
            var lastChunk = activeChunks[activeChunks.Count - 1];
            spawnPosition = lastChunk.position + Vector3.right * chunkWidth;
        }
        
        if(spawnedChunks % 15 == 0){
            Transform newChunk = Instantiate(chestChunk, spawnPosition, Quaternion.identity).transform;
            activeChunks.Add(newChunk);        
            if(spawenChunks < chunks.Length){
                spawenChunks++;
                Debug.Log(spawenChunks + " " + chunks.Length );
            }
        }else{
            Transform newChunk = Instantiate(chunks[Random.Range(0,spawenChunks)], spawnPosition, Quaternion.identity).transform;
            activeChunks.Add(newChunk);
        }

        spawnedChunks++;

        if (activeChunks.Count > 5)
        {
            Destroy(activeChunks[0].gameObject);
            activeChunks.RemoveAt(0);
        }
    }
}
