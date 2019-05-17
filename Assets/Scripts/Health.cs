using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject DeathParticlesPrefab = null;
    private Transform ThisTransform = null;
    public bool ShouldDestroyOnDeath = true;

    // Start is called before the first frame update
    void Start()
    {
        ThisTransform = GetComponent<Transform>();
    }


    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            _HealthPoints = value;

            if(_HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                if (DeathParticlesPrefab != null)
                    Instantiate(DeathParticlesPrefab, ThisTransform.position, ThisTransform.rotation);

                //ShouldDestroyOnDeath = true;

                if (ShouldDestroyOnDeath)
                    Destroy(gameObject);
            }
        }
    }

    //[SerializeField]
    public float _HealthPoints = 100f;


   
}
