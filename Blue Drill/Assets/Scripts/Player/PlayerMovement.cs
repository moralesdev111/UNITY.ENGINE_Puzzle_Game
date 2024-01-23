using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [Header("References")]
    [SerializeField] Animator animator;
    [SerializeField] PlayerInputs playerInputs;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform mainCamera;

    [Header("Control Tuning")]
    public float movementSpeed = 4f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    private float currentSpeed;
    private float turnSmoothVelocity;
    private Vector3 velocity;


    public void Move()
    {
         currentSpeed = movementSpeed;
        if (playerInputs.direction.magnitude >= 0.01f)
        {
            GetDirection();
            animator.SetFloat("Speed", currentSpeed);
        }
        else
        {
            // If not moving, reset the vertical velocity (to prevent constant falling)
            velocity.y = 0f;
            animator.SetFloat("Speed", 0f);
        }
    }


    private void GetDirection()
    {
        float targetAngle = Mathf.Atan2(playerInputs.direction.x, playerInputs.direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Apply gravity to the character's movement
            velocity.y += gravity * Time.deltaTime;

            controller.Move((moveDir.normalized * currentSpeed + velocity) * Time.deltaTime);
    }
}
