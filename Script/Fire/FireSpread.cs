using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public ParticleSystem fireParticles; // 火焰粒子系统
    public float spreadInterval = 0.1f; // 蔓延间隔
    public Transform[] spreadTransforms; // 蔓延位置的Transform数组
    public float speed = 5f; // 火势蔓延速度

    private int currentIndex = 0; // 当前蔓延位置的索引
    private float timer = 0f; // 计时器

    void Start()
    {
        if (spreadTransforms.Length > 0)
        {
            transform.position = spreadTransforms[0].position;
            currentIndex = 0;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spreadInterval && currentIndex < spreadTransforms.Length - 1)
        {
            timer = 0f;
            currentIndex++;
            SpreadToNextPosition(spreadTransforms[currentIndex].position);
        }
    }

    void SpreadToNextPosition(Vector3 targetPosition)
    {
        // 实例化一个新的火焰粒子系统
        ParticleSystem newFire = Instantiate(fireParticles, targetPosition, Quaternion.identity);
        // 设置粒子系统的速度
        var main = newFire.main;
        main.simulationSpeed = speed;
        // 播放粒子系统
        newFire.Play();
    }
}