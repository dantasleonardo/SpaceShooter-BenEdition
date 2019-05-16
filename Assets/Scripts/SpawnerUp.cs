using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUp : MonoBehaviour
{
    public float Maxradius = 1f;
    public float Interval = 5f;

    public GameObject ObjToSpawnUp = null;
    private Transform Origin = null;

    // Start is called before the first frame update
    void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag
            ("Player").GetComponent<Transform>();
    }

    void Start()
    {
        InvokeRepeating("SpawnUp", 0f, Interval);
    }

    // Update is called once per frame
    void SpawnUp()
    {
        if (Origin == null) return;

        Vector3 SpawnPos = Origin.position +
            Random.onUnitSphere * Maxradius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawnUp, SpawnPos, Quaternion.identity);
    }
}
