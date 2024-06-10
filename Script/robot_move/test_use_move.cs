using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_use_move : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 2.5f; // 前进速度
    public float moveSpeed2 = 1.5f; //平移速度 
    public float turnSpeed = 50f;

    private Rigidbody rb;

    //机器人运动状态量
    public bool forward;//前进
    public bool go_back;//后退
    public bool go_zuo;//左平移
    public bool go_you;//右平移
    public bool turn_zuo;//向左转
    public bool turn_you;//向右转
    //机器人形态变量
    public bool car_state;



   

    void Start()
    {
         animator = this.GetComponent<Animator>();//获取动画接口
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ///////////////
        // 鼠标左右平移控制机器人转向
        float mouseX = Input.GetAxis("Mouse X");
        if (mouseX < 0 && !turn_you) // 鼠标左移
        {
            turn_zuo = true; // 触发向左转状态
            animator.SetTrigger("ACS_TurnLeft"); // 触发向左转动画
        }
        else if (mouseX > 0 && !turn_zuo) // 鼠标右移
        {
            turn_you = true; // 触发向右转状态
            animator.SetTrigger("ACS_TurnRight"); // 触发向右转动画
        }

        // 根据鼠标平移量旋转机器人
        rb.MoveRotation(rb.rotation * Quaternion.AngleAxis(turnSpeed * mouseX * Time.deltaTime, Vector3.up));

        // 重置状态标志
        if (mouseX == 0)
        {
            turn_zuo = false;
            turn_you = false;
           // animator.SetTrigger("ACS_Idle"); // 无转向时触发闲置动画
        }

        ////////////////

        if (Input.GetKeyDown(KeyCode.Space))
        {
          

            if (Input.GetKeyDown(KeyCode.W))
            {
                forward = true;
                animator.SetTrigger("ACS_MoveWeelsForwad2");
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                forward = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (forward)
            {
                Vector3 forwardMovement = transform.forward * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + forwardMovement);
            }
            ////////////////////////后退/////////////////////////////////
            if (Input.GetKeyDown(KeyCode.S))
            {
                go_back = true;
                animator.SetTrigger("ACS_WalkBack");
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                go_back = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (go_back)
            {
                Vector3 backwardMovement = -transform.forward * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + backwardMovement);
            }

            ////////////////////////左平移///////////////////////////////
            if (Input.GetKeyDown(KeyCode.A))
            {
                go_zuo = true;
                animator.SetTrigger("ACS_StrafeLeft");
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                go_zuo = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (go_zuo)
            {
                Vector3 leftMovement = -transform.right * moveSpeed2 * Time.deltaTime;
                rb.MovePosition(rb.position + leftMovement);
            }

            ////////////////////////右平移///////////////////////////////
            if (Input.GetKeyDown(KeyCode.D))
            {
                go_you = true;
                animator.SetTrigger("ACS_StrafeRight");
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                go_you = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (go_you)
            {
                Vector3 rightMovement = transform.right * moveSpeed2 * Time.deltaTime;
                rb.MovePosition(rb.position + rightMovement);
            }

            ////////////////////////向左转///////////////////////////////turn_zuo
            if (Input.GetKeyDown(KeyCode.Q))
            {
                turn_zuo = true;
                animator.SetTrigger("ACS_TurnLeft");
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                turn_zuo = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (turn_zuo)
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }

            ////////////////////////向右转///////////////////////////////turn_you
            if (Input.GetKeyDown(KeyCode.E))
            {
                turn_you = true;
                animator.SetTrigger("ACS_TurnRight");
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                turn_you = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (turn_you)
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }




        }




        else
        {
            ////////////////////////前进/////////////////////////////
            if (Input.GetKeyDown(KeyCode.W))
            {
                forward = true;
                animator.SetTrigger("ACS_WalkForwad2");
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                forward = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (forward)
            {
                Vector3 forwardMovement = transform.forward * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + forwardMovement);
            }
            ////////////////////////后退/////////////////////////////////
            if (Input.GetKeyDown(KeyCode.S))
            {
                go_back = true;
                animator.SetTrigger("ACS_WalkBack");
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                go_back = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (go_back)
            {
                Vector3 backwardMovement = -transform.forward * moveSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + backwardMovement);
            }

            ////////////////////////左平移///////////////////////////////
            if (Input.GetKeyDown(KeyCode.A))
            {
                go_zuo = true;
                animator.SetTrigger("ACS_StrafeLeft");
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                go_zuo = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (go_zuo)
            {
                Vector3 leftMovement = -transform.right * moveSpeed2 * Time.deltaTime;
                rb.MovePosition(rb.position + leftMovement);
            }

            ////////////////////////右平移///////////////////////////////
            if (Input.GetKeyDown(KeyCode.D))
            {
                go_you = true;
                animator.SetTrigger("ACS_StrafeRight");
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                go_you = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (go_you)
            {
                Vector3 rightMovement = transform.right * moveSpeed2 * Time.deltaTime;
                rb.MovePosition(rb.position + rightMovement);
            }

            ////////////////////////向左转///////////////////////////////turn_zuo
            if (Input.GetKeyDown(KeyCode.Q))
            {
                turn_zuo = true;
                animator.SetTrigger("ACS_TurnLeft");
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                turn_zuo = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (turn_zuo)
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }

            ////////////////////////向右转///////////////////////////////turn_you
            if (Input.GetKeyDown(KeyCode.E))
            {
                turn_you = true;
                animator.SetTrigger("ACS_TurnRight");
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                turn_you = false;
                animator.SetTrigger("ACS_Idle");
            }
            if (turn_you)
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }
        



  


    }

    private void  Move()
    {
       
    }










}
