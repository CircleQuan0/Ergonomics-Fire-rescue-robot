using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Trans_test : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKey(KeyCode.K))
            {
                if (animator.GetBool("isWalk"))
                {
                    animator.SetBool("isWalk", false);

                }
                else
                {
                    animator.SetBool("isWalk", true);
                }

            }

            if (Input.GetKey(KeyCode.L))
            {
                if (animator.GetBool("iWalk"))
                {
                    animator.SetBool("iWalk", false);

                }
                else
                {
                    animator.SetBool("iWalk", true);
                }

            }
        }
    }
}
