using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custom_follow_move_robot : MonoBehaviour
{
 private   bool isColliding = false;
  private  float collisionTime = 0f;

    void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        collisionTime = Time.time;
    }

    void OnCollisionStay(Collision collision)
    {
        if (Time.time - collisionTime >= 0.1f)
        {
      //      GetComponent<CustomFollowMove>().StartFollowing();
            isColliding = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

}
