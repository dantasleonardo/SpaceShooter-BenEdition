using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    public float DamageRate = 10f;
    // Start is called before the first frame update
    void OnTriggerStay(Collider Col)
    {
        Health H = Col.gameObject.GetComponent<Health>();

        if (H == null) return;

        H.HealthPoints -= DamageRate * Time.deltaTime;
    }


}
