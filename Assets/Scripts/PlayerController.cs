using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody ThisBody = null;
    private Transform ThisTransform = null;
    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float MaxSpeed = 5f;
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;
    public Transform[] TurretTransform;
    float x;

    void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
        ThisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Health._HealthPoints);
        float Horz = Input.GetAxis(HorzAxis);
        float Vert = Input.GetAxis(VertAxis);
        Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert);
        ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);

        ThisBody.velocity = new Vector3(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed), 
            Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));

        if (MouseLook)
        {
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
            Vector3 LookDirection = MousePosWorld - ThisTransform.position;

            ThisTransform.localRotation = Quaternion.LookRotation(
                LookDirection.normalized, Vector3.up);
        }

        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (Transform T in TurretTransform)
            {
                if (GameController.Score <= 200)
                {
                    AmmoManager.SpawnAmmo(T.position, T.rotation);
                }
                else if (GameController.Score >= 100 && GameController.Score <= 500)
                {
                    //Debug.Log("Saiu 1");
                    var pos = T.position;
                    x += Time.deltaTime * 10;
                    AmmoManager.SpawnAmmo(new Vector3(pos.x - 0.5f, pos.y, pos.z - 0.5f), Quaternion.AngleAxis(10.0f, transform.up) * T.rotation);
                    AmmoManager.SpawnAmmo(new Vector3(pos.x + 0.5f, pos.y, pos.z + 0.5f), Quaternion.AngleAxis(-10.0f, transform.up) * T.rotation);
                }
                else if (GameController.Score > 500)
                {
                    //Debug.Log("Saiu 2");
                    AmmoManager.SpawnAmmo(new Vector3(T.position.x - 0.5f, T.position.y, T.position.z - 0.5f), Quaternion.AngleAxis(10.0f, transform.up) * T.rotation);//T.rotation);
                    AmmoManager.SpawnAmmo(new Vector3(T.position.x, T.position.y, T.position.z), T.rotation);
                    AmmoManager.SpawnAmmo(new Vector3(T.position.x + 0.5f, T.position.y, T.position.z + 0.5f), Quaternion.AngleAxis(-10.0f, transform.up) * T.rotation);
                }
                //Debug.Log("Atirou");
            }

            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }
}
