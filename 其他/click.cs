using UnityEngine;

public class click : MonoBehaviour
{
    public AudioClip clickSound; // 鼠标点击时播放的提示音
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
        audioSource.clip = clickSound;
    }

    void Update()
    {
        // 检查是否发生了鼠标左键点击事件
        if (Input.GetMouseButtonDown(0)) // 0 代表鼠标左键
        {
            // 播放音频
            audioSource.Play();
        }
    }
}