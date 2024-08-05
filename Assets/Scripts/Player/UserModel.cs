using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CharacterController)), SelectionBase]
public class UserModel : MonoBehaviour
{
    CharacterController _characterController;
    [SerializeField] Controller _controller;

    public float inputCheck;
    public Animator view;
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
        moveSystem.Update(_controller.GetMovementInput());
        if (inputCheck != 0)
        {
            view.SetBool("Move", true);
            view.SetBool("Talando", false);
            view.SetBool("Shoot", false);
        }
        else
        {
            view.SetBool("Move", false);
        }
    }
    private void InputUpdater()
    {
        inputCheck = _controller.GetMovementInput().normalized.magnitude; 
    }
    public Vector3 GetInput()
    {
        return _controller.GetMovementInput();
    }
}
