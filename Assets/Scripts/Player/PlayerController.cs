using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;


[RequireComponent(typeof(CharacterController)),SelectionBase]
public class PlayerController : MonoBehaviour
{
    Vector3 _input;
    CharacterController _characterController;
    public Animator myAnimator;

    public MoveSystem moveSystem;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        moveSystem.characterController = _characterController;
        UpdateManager.OnUpdate += ManagedUpdate;

    }

    // Update is called once per frame
    void ManagedUpdate()
    {
        InputUpdater();
        moveSystem.Update(_input);
        if(_input.magnitude != 0)
        {
            myAnimator.SetBool("Talando", false);
        }
    }
    

    private void InputUpdater() 
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

    }
    public Vector3 GetInput()
    {
        return _input;
    }
    


}
