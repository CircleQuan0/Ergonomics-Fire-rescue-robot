using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people_fire : MonoBehaviour
{

    public Transform robotTransform;

   

    private void OnCollisionEnter(Collision collision)
    {
        // 检测到碰撞，检查碰撞对象是否为机器人
        if (collision.collider.gameObject == robotTransform.gameObject)
        {
            // 停止粒子系统并将其从场景中移除
            ParticleSystem particles = GetComponent<ParticleSystem>();
            if (particles != null)
            {
                particles.Stop();
                Destroy(particles.gameObject);
            }
        }
    }
}
