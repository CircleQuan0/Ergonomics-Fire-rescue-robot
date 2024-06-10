using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_fire : MonoBehaviour
{

        private void OnCollisionEnter(Collision collision)
        {
            // 检测到碰撞，检查碰撞对象是否有粒子系统组件
            ParticleSystem particles = collision.gameObject.GetComponent<ParticleSystem>();
            if (particles != null)
            {
                // 停止粒子系统并将其从场景中移除
                particles.Stop();
                Destroy(particles.gameObject);
            }
        }
    }

