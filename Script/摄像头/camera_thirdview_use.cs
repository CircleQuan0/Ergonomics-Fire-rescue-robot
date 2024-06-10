using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_thirdview_use : MonoBehaviour
{
   
    public Transform target; // 机器人的Transform
    public float distance = 5.0f; // 相机与机器人之间的距离
    public float height = 3.0f; // 相机距离地面的高度
    public float smoothSpeed = 0.5f; // 相机移动的平滑度

    public float lookSpeed = 2.0f; // 相机旋转的速度
    public float minAngleY = -50.0f; // 相机最小的仰角
    public float maxAngleY = 50.0f; // 相机最大的仰角


    public Vector3 initialPosition; // 摄像头初始位置
    public Quaternion initialRotation; // 摄像头初始旋转
    public float transitionDuration = 1.0f; // 过渡持续时间


    private void Start()
    {
        // 设置摄像头的初始位置和旋转
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    // 这个方法由UI按钮调用
    public void StartExperiment()
    {
        StartCoroutine(TransitionToTarget());
    }

    private IEnumerator TransitionToTarget()
    {
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < transitionDuration)
        {
            // 平滑过渡位置
            transform.position = Vector3.Lerp(startPosition, target.position, (elapsedTime / transitionDuration));
            // 平滑过渡旋转
            transform.rotation = Quaternion.Lerp(startRotation, target.rotation, (elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保最终位置和旋转与目标一致
        transform.position = target.position;
        transform.rotation = target.rotation;
    }


    void LateUpdate()
    {
        // 锁定鼠标位置并隐藏
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        float screenCenterX = Screen.width / 2;
        float screenCenterY = Screen.height / 2;

        // 设置鼠标位置为屏幕中心

        Cursor.lockState = CursorLockMode.Locked;//将鼠标锁定在屏幕中心
                                                 // Cursor.lockState = CursorLockMode.Confined;//将鼠标锁定在游戏窗口内
                                                 // Cursor.lockState = CursorLockMode.None;//取消鼠标锁定状态


        if (!target)
            return;

        // 计算相机的目标位置
        Vector3 targetPosition = target.position - target.forward * distance;
        targetPosition.y = target.position.y + height;

        // 平滑移动相机到目标位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // 让相机始终朝向机器人
         transform.LookAt(target);
        // 限制相机的旋转角度
      //  float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
      //  float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        Vector3 rotation = transform.localRotation.eulerAngles;
    //    rotation.y += mouseX;
    //    rotation.x -= mouseY;
        rotation.x = Mathf.Clamp(rotation.x, minAngleY, maxAngleY);
        transform.localRotation = Quaternion.Euler(rotation);


        //if (target)
        //{
        //    // 使相机朝向机器人
        //    transform.LookAt(target);

        //    // 将鼠标位置设置为中心，以实现画面中心对齐鼠标中心
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;

        //    // 计算并设置相机的目标位置（根据需要调整）
        //    // 这里需要根据实际情况调整，以实现Z轴对齐
        //    float desiredRotationAngle = transform.eulerAngles.y - target.eulerAngles.y;
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, desiredRotationAngle, 0);
        //}



    }
}

