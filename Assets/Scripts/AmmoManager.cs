using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject AmmoPrefab = null;

    public int PoolSize = 100;

    public Queue<Transform> AmmoQueue = new Queue<Transform>();

    private GameObject[] AmmoArray;

    public static AmmoManager AmmoManagerSingleTon = null;
    // Start is called before the first frame update
    void Awake()
    {
        if(AmmoManagerSingleTon != null)
        {
            Destroy(GetComponent<AmmoManager>());
            return;
        }

        AmmoManagerSingleTon = this;
        AmmoArray = new GameObject[PoolSize];

        for(int i=0; i<PoolSize; i++)
        {
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Transform ObjTransform = AmmoArray[i].GetComponent<Transform>();
            ObjTransform.parent = GetComponent<Transform>();
            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[i].SetActive(false);
        }


    }

    public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        Transform SpawnedAmmo = AmmoManagerSingleTon.AmmoQueue.Dequeue();

        SpawnedAmmo.gameObject.SetActive(true);
        SpawnedAmmo.position = Position;
        SpawnedAmmo.localRotation = Rotation;


        AmmoManagerSingleTon.AmmoQueue.Enqueue(SpawnedAmmo);

        return SpawnedAmmo;
    }


}
