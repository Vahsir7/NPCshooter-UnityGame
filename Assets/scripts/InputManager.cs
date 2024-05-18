using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    KeyBinds controls;
    KeyBinds.PlayerActions player;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerLook playerLook;
    [SerializeField] Snowball snowball;
    
    Vector2 movementInput;
    Vector2 LookInput;



    private void Awake()
    {
        controls = new KeyBinds();
        player = controls.Player;

        player.movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();

        player.Jump.performed += _ => playerMovement.onJumpPressed();

        player.LookX.performed += ctx => LookInput.x = ctx.ReadValue<float>();
        player.LookY.performed += ctx => LookInput.y = ctx.ReadValue<float>();

        player.Shoot.performed += _ => snowball.shoot();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    public void Update()
    {
        playerMovement.ReceiveInput(movementInput);
        playerLook.ReceiveInput(LookInput);
    }
}
