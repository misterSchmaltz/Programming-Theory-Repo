using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payload : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticle;
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        explosionParticle.Play();
        Destroy(this.gameObject);
    }
}
