using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public float decrease = 2.0f;
    public float duration = 3f;
    public float modifier = 1.5f;
    public GameObject pickupEffect;

    new GameObject camera;
    public Transform thisObject;
    private bool isActive;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
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
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D Player)
    {
        isActive = true;
        Instantiate(pickupEffect, transform.position, transform.rotation);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        MoveWorld.WorldSpeed = MoveWorld.WorldSpeed * modifier;

        yield return new WaitForSeconds(duration);

        MoveWorld.WorldSpeed = MoveWorld.WorldSpeed / modifier;
        isActive = false;
        Destroy(gameObject);
    }
}
