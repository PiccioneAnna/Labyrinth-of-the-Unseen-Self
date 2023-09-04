using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] float spawnAreaH = 1f;
    [SerializeField] float spawnAreaW = 1f;

    [SerializeField] GameObject[] spawn;
    [SerializeField] GameObject anchor;
    [SerializeField] GameObject parentObject;
    int length;
    [SerializeField] float probability = 0.1f;
    [SerializeField] int spawnCount = 1;
    [SerializeField] int objectSpawnLimit = -1;

    private void Start()
    {
        length = spawn.Length;

        Spawn();
    }

    private void Update()
    {
        this.transform.position = anchor.transform.position;
    }

    private void FixedUpdate()
    {
        Spawn();
    }

    void Spawn()
    {
        if (Random.value > probability) { return; }

        for (int i = 0; i < spawnCount; i++)
        {
            int id = Random.Range(0, length);
            GameObject go = Instantiate(spawn[id]);
            Transform t = go.transform;
            t.SetParent(parentObject.transform);

            Vector3 position = transform.position;
            position.x += Random.Range(-spawnAreaW, spawnAreaW);
            position.y += Random.Range(-spawnAreaH, spawnAreaH);
            position.z = 0;

            t.position = position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaW * 2, spawnAreaH * 2));
    }
}
