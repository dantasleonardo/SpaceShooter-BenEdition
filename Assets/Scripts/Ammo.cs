using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public float Damage = 100f;
    public float LifeTime = 0f;
    // Start is called before the first frame update
    void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag != "Player")
        {
            Health H = Col.gameObject.GetComponent<Health>();
            if (H == null) return;
            H.HealthPoints -= Damage;
            Destroy(gameObject);
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
