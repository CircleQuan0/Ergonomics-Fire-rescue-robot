using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custom_follow_move : MonoBehaviour
{
    public bool isFollowing = false;
    public float followSpeed = 5f;
    public Vector3 offset;
    public float followDelay = 0.1f;
    public Transform robotTransform;

    private Animator animator;

    private bool collisionWithRobot = false;
    private bool gKeyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gKeyPressed = true;

            if (collisionWithRobot && !isFollowing)
            {
                
                isFollowing = true;
                StartCoroutine(FollowRobot());
                animator.SetBool("change_state",true);
            }
            else
            {

                isFollowing = false;
                StopCoroutine(FollowRobot());
                animator.SetBool("change_state", true);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == robotTransform.gameObject)
        {
            collisionWithRobot = true;
            StartCoroutine(CheckCollisionDuration());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject == robotTransform.gameObject)
        {
            collisionWithRobot = true;
            StartCoroutine(CheckCollisionDuration());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject == robotTransform.gameObject)
        {
            collisionWithRobot = false;
            StopCoroutine(CheckCollisionDuration());
        }
    }

    private IEnumerator CheckCollisionDuration()
    {
        float collisionStartTime = Time.time;
        while (collisionWithRobot && gKeyPressed)
        {
            if (Time.time - collisionStartTime > followDelay)
            {
                isFollowing = true;
                StartCoroutine(FollowRobot());
                break;
            }
            yield return null;
        }
    }

    private void AlignWithRobotXAxis()
    {
        transform.rotation = Quaternion.Euler(0, robotTransform.rotation.eulerAngles.y, 0);
    }

    private IEnumerator FollowRobot()
    {
        while (isFollowing)
        {
            Vector3 targetPosition = robotTransform.TransformPoint(offset);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
            yield return null;
        }
    }
}