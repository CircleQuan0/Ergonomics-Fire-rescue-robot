using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_robot_camera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform robot; // 机器人的Transform
    public float distance = 5.0f; // 相机与机器人之间的距离
    public float heightOffset = 1.0f; // 相机与机器人之间的垂直偏移量
    public float minDistance = 1.0f; // 相机与机器人之间的最小距离
    public float maxDistance = 10.0f; // 相机与机器人之间的最大距离
    public float minDownwardOffset = 0.0f; // 相机向下偏移的最小值
    public float maxDownwardOffset = 3.0f; // 相机向下偏移的最大值
    public float moveSpeed = 5.0f; // 相机移动的速度
    public float rotateSpeed = 5.0f; // 相机旋转的速度

    private Vector3 offset; // 相机与机器人之间的偏移量

    void Start()
    {
        offset = transform.position - robot.position;
    }

    void Update()
    {
        // 计算相机的目标位置
        Vector3 targetPosition = robot.position + offset.normalized * distance;
        targetPosition.y = robot.position.y - heightOffset;

        // 平滑移动相机到目标位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 让相机始终朝向机器人
        transform.LookAt(robot);

        // 鼠标控制相机旋转
        if (!Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;

            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.y += mouseX;
            rotation.x -= mouseY;
            transform.localRotation = Quaternion.Euler(rotation);
        }
    }
}



