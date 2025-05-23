using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    private bool isMoving;
    private Vector2 input; 
    private Animator animator;
    AudioManagerMain audioManager;

    private void Awake(){
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerMain>();
    }

    private void Update(){

        if (!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0 ) input.y = 0;

            if (input != Vector2.zero){
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);
       
        if(Input.GetKeyDown(KeyCode.E))
        Interact();
    }   
    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"),animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        var collider =Physics2D.OverlapCircle(interactPos,0.3f, interactableLayer);
        if (collider != null)
        {
                collider.GetComponent<Interactable>()?.Interact();
                audioManager.PlaySFX(audioManager.Interact);
        }
    }
    
    IEnumerator Move (Vector3 targetPos){
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos){
        if (Physics2D.OverlapCircle(targetPos,0.2f,solidObjectsLayer | interactableLayer) !=null){
            return false;
        }
            return true;
    }
}
