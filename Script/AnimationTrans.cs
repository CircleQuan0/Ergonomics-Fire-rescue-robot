using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrans : MonoBehaviour
{
    private Animator animator;         // 控制角色动画的Animator组件
    private Rigidbody rigid_body;      // 角色的刚体组件，用于控制角色移动
    private bool walk_key = false;     // 标记角色是否在行走
    private int walk_key_count = 0;    // 记录按下行走键的次数

    // Start is called before the first frame update
    void Start()
    {
        // 获取当前对象上的Animator组件
        animator = this.GetComponent<Animator>();
        // 获取当前对象上的Rigidbody组件
        rigid_body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 检测是否按下P键，用于增加walk_key_count
        if (Input.GetKey(KeyCode.P))
        {
            walk_key_count = walk_key_count + 1;
        }
        else if (walk_key_count > 5)
        {
            // 如果按键次数超过5次，则重置walk_key_count，并将walk_key取反
            walk_key_count = 0;
            walk_key = !walk_key;
        }
        else
        {
            // 如果未按下P键或按键次数不超过5次，则重置walk_key_count
            walk_key_count = 0;
        }

        // 根据walk_key来设置动画的播放状态
        if (walk_key)
        {
            // 如果角色在行走状态，并且walk_key为真，则停止行走动画
            if (animator.GetBool("isWalk"))
            {
                animator.SetBool("isWalk", false);
                walk_key = false;
            }
            else
            {
                // 如果角色不在行走状态，并且walk_key为真，则播放行走动画
                animator.SetBool("isWalk", true);
                walk_key = false;
            }
        }

        // 如果角色正在行走，则根据动画的Speed参数移动角色
        if (animator.GetBool("isWalk"))
        {
            // 计算角色前进的距离，并移动角色
            float distance = animator.GetFloat("Speed") * Time.deltaTime;
            Vector3 movement = new Vector3(0, 0, distance);
            this.rigid_body.MovePosition(this.rigid_body.position + movement);
        }
    }
}
