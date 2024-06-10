using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custom_move_back_and_forth : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isMoving)
            {
                StartCoroutine(MoveAndReturn());
               animator.SetBool( "isMoving" , true);
            }
            else
            {
                StopMoving();
                animator.SetBool("isMoving", false);
            }
        }
    }

    IEnumerator MoveAndReturn()
    {
        // Rotate to face along the x-axis
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // Move forward 10 units
        float distance = 0;
        int count = 0;

        while (true)
        {
            count++;

            while (distance < 2)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
                distance += Time.deltaTime;
                yield return null;
            }

            // Rotate 180 degrees
            transform.Rotate(0, 180, 0);

            // Move back to the starting position
            while (distance > 0)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
                distance -= Time.deltaTime;
                yield return null;
            }

            // Rotate to face along the x-axis again
            transform.rotation = Quaternion.Euler(0, 0, 0);

            // Move forward 10 units again
            while (distance < 2)
            {
                transform.Translate(Vector3.forward * Time.deltaTime);
                distance += Time.deltaTime;
                yield return null;
            }
            distance = 0;
            // Reset the moving flag and distance

        }

        isMoving = false;
        
    }

    void StopMoving()
    {
        StopAllCoroutines();
        isMoving = false;
    }

}