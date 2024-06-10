using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{
    private CharacterController _character;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>( );
        _animator = GetComponent<Animator>( );
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.forward; // 创建向前的移动方向
        //if (dir != Vector3.zero)
        //{
            //transform.rotation = Quaternion.LookRotation(dir);
            //_animator.SetBool(name: "isRun", value: true);
            transform.Translate(dir * 2 * Time.deltaTime); // 应用移动
            //transform.Translate(translation: Vector3.forward * 2 * Time.deltaTime);
        //}
        //else
        //{
        //    _animator.SetBool(name: "isRun", value: false);
        //}
        //transform.Translate(translation: Vector3.forward * 2 * Time.deltaTime);

    }
}
