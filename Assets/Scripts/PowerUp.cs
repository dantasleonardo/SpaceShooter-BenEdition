using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    //Animator anim;
    BoxCollider col;

    //private AudioSource audioS;

    // Use this for initialization
    void Start()
    {

        //anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<BoxCollider>();
        Debug.Log(Health._HealthPoints);
        //audioS = gameObject.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //audioS.Play();
            Health._HealthPoints += 200f;
            //Ammo.Damage += 200f;
            col.enabled = false;
            Debug.Log(Health._HealthPoints);
            //anim.SetTrigger("Coletando");
            Destroy(gameObject, 0.667f);
        }
    }
}
