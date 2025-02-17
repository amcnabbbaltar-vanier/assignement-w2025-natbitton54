using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody rb;

    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        animator.SetFloat("CharacterSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", characterMovement.IsGrounded);
        animator.SetBool("isDoubleJumping", !characterMovement.IsGrounded && Input.GetButtonDown("Jump") && characterMovement.canDoubleJump);
    }

    // public void LateUpdate()
    // {
    //    UpdateAnimator();
    // }

    // // TODO Fill this in with your animator calls
    // void UpdateAnimator()
    // {
        
    // }
}