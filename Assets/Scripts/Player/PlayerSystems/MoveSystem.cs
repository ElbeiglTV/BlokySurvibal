using UnityEngine;
[System.Serializable]
public class MoveSystem
{
    private Vector3 _input;
    private Vector3 _moveVector;

    public float speed;
    public float rotateSpeed;
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
        _moveVector = new Vector3(_input.x, _moveVector.y / speed, _input.z);
        _moveVector = _moveVector * speed;
    }
    private void RotateTarget()
    {
        if (_input.magnitude != 0)
        {
            rotateTarguet.transform.position = Vector3.Slerp(rotateTarguet.transform.position, characterController.transform.position + _input,rotateSpeed*Time.deltaTime);
        }

    }
    private void RotateToTarget()
    {
        mySkin.forward = rotateTarguet.position - mySkin.position;
    }

}
