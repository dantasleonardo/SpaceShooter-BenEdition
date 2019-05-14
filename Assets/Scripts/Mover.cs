using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Transform ThisTransform = null;
    public float MaxSpeed = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ThisTransform.position += ThisTransform.forward * MaxSpeed * Time.deltaTime;
    }
}
