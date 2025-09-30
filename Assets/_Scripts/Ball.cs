using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public AudioClip bounceSound;
    public float speed = 36.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.eulerAngles = new Vector3(0, 90, 0);

        float angle = Random.value * 44 - 22;

        if (Random.value < 0.5f) {
            angle += 180;
        }

        transform.eulerAngles += new Vector3(0, angle, 0);

        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Floor"))
        {
            AudioSource.PlayClipAtPoint(bounceSound, transform.position, 1.0f);
        }
    }
}
