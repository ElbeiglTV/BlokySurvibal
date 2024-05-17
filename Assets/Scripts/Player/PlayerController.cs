using UnityEngine;


[RequireComponent(typeof(CharacterController)), SelectionBase]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Controller controller;
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
        if (_inputCheck != 0)
        {
            myAnimator.SetBool("Move", true);
            myAnimator.SetBool("Talando", false);
            myAnimator.SetBool("Shoot", false);
        }
        else
        {
            myAnimator.SetBool("Move", false);
        }
    }


    private void InputUpdater()
    {
        _inputCheck = controller.GetMovementInput().normalized.magnitude;
        _input = controller.GetMovementInput();
    }
    public Vector3 GetInput()
    {
        return _input;
    }




}
