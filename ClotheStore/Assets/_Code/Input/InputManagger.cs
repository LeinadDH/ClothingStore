using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagger : MonoBehaviour
{
    public static Vector2 Movement;
    
    private PlayerInput _playerController;
    private InputAction _movementAction;
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerInput>();
        _movementAction = _playerController.actions["Move"];
    }

    private void Update()
    {
        Movement = _movementAction.ReadValue<Vector2>();
    }
}
