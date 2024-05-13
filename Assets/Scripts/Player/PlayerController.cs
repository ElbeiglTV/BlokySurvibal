using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;


[RequireComponent(typeof(CharacterController)), SelectionBase]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Controller controller;
    public bool MobileInput;
    public float _inputCheck;


    Vector3 _input;
    CharacterController _characterController;
    public Animator myAnimator;

    public MoveSystem moveSystem;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        moveSystem.characterController = _characterController;
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdater();
        moveSystem.Update(_input);
        if(_inputCheck != 0)
        {
            myAnimator.SetBool("Move", true);
            myAnimator.SetBool("Talando", false);
        }
        else
        {
            myAnimator.SetBool("Move", false);
        }
    }
    

    private void InputUpdater() 
    {

        if (!MobileInput)
        {
          _inputCheck = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized.magnitude;
          _input = new Vector3(Input.GetAxis("Horizontal")*_inputCheck , 0, Input.GetAxis("Vertical")* _inputCheck).normalized;
        }
        else
        {
            _inputCheck = controller.GetMovementInput().normalized.magnitude;
            _input = controller.GetMovementInput();
        }

    }
    public Vector3 GetInput()
    {
        return _input;
    }
    
    


}
