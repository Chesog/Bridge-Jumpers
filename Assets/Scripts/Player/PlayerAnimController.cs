using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string animatorParam;

    private void OnEnable()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 temp = Vector3.zero;
        temp.x = InputManager.Instance.GetAxis("Horizontal");
        temp.y = InputManager.Instance.GetAxis("Vertical");
        _animator.SetFloat(animatorParam,temp.magnitude - temp.z);
    }
}
