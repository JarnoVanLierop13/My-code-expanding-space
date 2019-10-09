using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{

    public float duration = 5f;
    public GameObject pickupEffect;
    public Shield shield;
    public static bool isinvulnerable;

    // destroy object out of screen
    new GameObject camera;
    public Transform thisObject;
    private bool isActive;


    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        shield = GameObject.FindGameObjectWithTag("Shield").GetComponent<Shield>();
    }

    private void Update()
    {
        float minRangex = camera.transform.position.x - 10.5f;

        if (thisObject.transform.position.x <= minRangex && isActive != true)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            isActive = true;
            shield.Activate(duration);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            OnPickup();
        }
    }

    void OnPickup()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, duration);
        isActive = false;
    }
}
