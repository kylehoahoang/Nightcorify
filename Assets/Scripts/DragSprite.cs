using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    public Animator animator;
    private bool _dragging;

    private Vector2 _offset;

    void Update() {
        if(!_dragging) {
            return;
        }

        var mousePosition = GetMousePos();

        
        transform.position = mousePosition - _offset;



        // Get the horizontal input axis
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");
        if (horizontalInput > 0.1 && verticalInput < 0.1 && verticalInput > -0.1) // Right
        {
            animator.SetBool("rightMovement", true);
            animator.SetBool("leftMovement", false);
            animator.SetBool("upMovement", false);
            animator.SetBool("downMovement", false);
        }
        else if (horizontalInput < -0.1 && verticalInput < 0.1 && verticalInput > -0.1) // Left
        {
            animator.SetBool("rightMovement", false);
            animator.SetBool("leftMovement", true);
            animator.SetBool("upMovement", false);
            animator.SetBool("downMovement", false);
        }
        else if (verticalInput > 0.1 && horizontalInput < 0.1 && horizontalInput > -0.1) // Up
        {
            animator.SetBool("rightMovement", false);
            animator.SetBool("leftMovement", false);
            animator.SetBool("upMovement", true);
            animator.SetBool("downMovement", false);
        }
        else if (verticalInput > 0.06 && horizontalInput > 0.06) // Up Right
        {
            animator.SetBool("rightMovement", true);
            animator.SetBool("leftMovement", false);
            animator.SetBool("upMovement", true);
            animator.SetBool("downMovement", false);
        }
        else if (verticalInput > 0.06 && horizontalInput < -0.06) // Up Left
        {
            animator.SetBool("rightMovement", false);
            animator.SetBool("leftMovement", true);
            animator.SetBool("upMovement", true);
            animator.SetBool("downMovement", false);
        }
        else if (verticalInput < -0.1 && horizontalInput < 0.1 && horizontalInput > -0.1) // Down
        {
            animator.SetBool("rightMovement", false);
            animator.SetBool("leftMovement", false);
            animator.SetBool("upMovement", false);
            animator.SetBool("downMovement", true);
        }
        else if (verticalInput < -0.06 && horizontalInput > 0.06) // Down Right
        {
            animator.SetBool("rightMovement", true);
            animator.SetBool("leftMovement", false);
            animator.SetBool("upMovement", false);
            animator.SetBool("downMovement", true);
        }
        else if (verticalInput < -0.06 && horizontalInput < -0.06) // Down Left
        {
            animator.SetBool("rightMovement", false);
            animator.SetBool("leftMovement", true);
            animator.SetBool("upMovement", false);
            animator.SetBool("downMovement", true);
        }

    }

    void OnMouseDown() {
        _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;
        animator.SetBool("isPickedUp", _dragging);
    }

    void OnMouseUp() {
        _dragging = false;
        animator.SetBool("isPickedUp", _dragging);
        animator.SetBool("rightMovement", false);
        animator.SetBool("leftMovement", false);
        animator.SetBool("upMovement", false);
        animator.SetBool("downMovement", false);
    }

    Vector2 GetMousePos() {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
