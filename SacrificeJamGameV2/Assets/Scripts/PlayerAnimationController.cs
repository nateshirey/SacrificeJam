using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private PlayerCharacterController characterController;
    private Vector2 movementInput;
    private float tan;
    private bool idle = false;

    private void Awake()
    {
        characterController = this.GetComponent<PlayerCharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = characterController.inputMoveValue;

        idle = false;
        if(characterController.inputMoveValue.sqrMagnitude <= 0.3f)
        {
            idle = true;
        }
        else
        {
            tan = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
            tan /= 45;
        }

        anim.SetFloat("Blend", tan);
        anim.SetBool("Idle", idle);
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }
}
