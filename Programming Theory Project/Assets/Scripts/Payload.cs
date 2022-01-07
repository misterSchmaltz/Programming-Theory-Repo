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
        /*
        if (!other.gameObject is Plane && !other.gameObject is Payload)
        {
            explosionParticle.Play();
            Destroy(this.gameObject);
        }*/
        if (!other.gameObject.GetComponent<Plane>() && !other.gameObject.GetComponent<Payload>())
        {
            //Instantiate(explosionParticle, this.transform.position, explosionParticle.transform.rotation);
            //explosionParticle.Play();
            //Destroy(explosionParticle, explosionParticle.duration);
            Destroy(this.gameObject);
        }
    }
}
