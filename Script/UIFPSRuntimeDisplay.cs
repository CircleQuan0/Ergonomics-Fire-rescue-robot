using UnityEngine;
using UnityEngine.UI;

public class UIFPSRuntimeDisplay : MonoBehaviour
{
    public Text fpsText; // 绑定FPS显示的UI Text
    public Text runtimeText; // 绑定运行时长显示的UI Text
    private float deltaTime = 0.0f; // 用于计算FPS的时间差
    private float runtime = 0.0f; // 应用运行的总时间

    void Start()
    {
        // 绑定UI Text组件
        fpsText = GetComponent<Text>();
        runtimeText = GetComponent<Text>();
    }

    void Update()
    {
        // 计算FPS
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + fps;

        // 更新运行时长
        runtime += Time.deltaTime;
        runtimeText.text = "Runtime: " + FormatRuntime(runtime);
    }

    // 格式化运行时长为分钟和秒
    string FormatRuntime(float seconds)
    {
        int minutes = (int)(seconds / 60);
        int secondsWithoutMinutes = (int)(seconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, secondsWithoutMinutes);
    }
}