using UnityEngine;
[System.Serializable]
public class MoveSystem
{
    private Vector3 _input;
    private Vector3 _moveVector;

    public float Speed;
    public float Gravity = 9.81f;

    public CharacterController characterController;
    public Transform mySkin;
    public Transform rotateTarguet;




    public void Update(Vector3 input)
    {
        InputUpdater(input);
        SetMoveVector();
        SetGravity();
        characterController.Move(_moveVector * Time.deltaTime);
        RotateToTarget();
        RotateTarget();

    }

    private void InputUpdater(Vector3 input)
    {
        _input = input;
    }

    private void SetGravity()
    {
        if (characterController.isGrounded)
        {
            _moveVector.y = -Gravity * Time.deltaTime;
        }
        else
        {
            _moveVector.y -= Gravity * Time.deltaTime;
        }
    }
    private void SetMoveVector()
    {
        _moveVector = new Vector3(_input.x, _moveVector.y / Speed, _input.z);
        _moveVector = _moveVector * Speed;
    }
    private void RotateTarget()
    {
        if (_input.magnitude != 0)
        {
            rotateTarguet.transform.position = characterController.transform.position + _input;
        }

    }
    private void RotateToTarget()
    {
        mySkin.forward = rotateTarguet.position - mySkin.position;
    }

}
