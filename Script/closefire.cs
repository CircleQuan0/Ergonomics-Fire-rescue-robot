using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class closefire : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        ParticleSystem otherParticles = other.GetComponent<ParticleSystem>();
        if (otherParticles != null && otherParticles != GetComponent<ParticleSystem>())
        {
            Destroy(otherParticles.gameObject);
        }
    }
    //  private ParticleSystem particles;

    //void Start()
    //{
    //    particles = GetComponent<ParticleSystem>();
    //}

    //void OnParticleCollision(GameObject other)
    //{
    //    ParticleSystem otherParticles = other.GetComponent<ParticleSystem>();
    //    if (otherParticles != null && otherParticles != particles)
    //    {
    //        Destroy(otherParticles.gameObject);
    //    }
    //}
}

