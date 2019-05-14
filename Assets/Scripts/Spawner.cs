using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Maxradius = 1f;
    public float Interval = 5f;

    public GameObject ObjToSpawn = null;
    private Transform Origin = null;

    // Start is called before the first frame update
    void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag
            ("Player").GetComponent<Transform>();
    }

    void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (Origin == null) return;

        Vector3 SpawnPos = Origin.position + 
            Random.onUnitSphere * Maxradius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }
}
