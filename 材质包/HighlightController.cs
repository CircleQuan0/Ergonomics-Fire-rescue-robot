using UnityEngine;

public class PlaySoundOnKeyPress : MonoBehaviour
{
    public AudioClip soundEffect; // 提示音音频文件
    private AudioSource audioSource; // 音频源组件

    void Start()
    {
        // 获取或创建AudioSource组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 确保AudioSource组件不会在游戏开始时自动播放
        audioSource.playOnAwake = false;

        // 将提示音音频文件设置到AudioSource组件
        audioSource.clip = soundEffect;
    }

    void Update()
    {
        // 检查是否按下了"G"键
        if (Input.GetKeyDown(KeyCode.G))
        {
            // 播放提示音
            audioSource.Play();
        }
    }
}