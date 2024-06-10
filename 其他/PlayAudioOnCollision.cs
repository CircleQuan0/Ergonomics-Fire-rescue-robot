using UnityEngine;

public class PlayAudioOnCollision : MonoBehaviour
{
    public AudioClip collisionSound; // 碰撞时播放的音频剪辑
    private AudioSource audioSource; // 音频源组件

    void Start()
    {
        // 获取或创建AudioSource组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 设置音频剪辑
        audioSource.clip = collisionSound;
        // 确保AudioSource组件不会在游戏开始时自动播放
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 当发生碰撞时播放音频
        audioSource.Play();
    }
}