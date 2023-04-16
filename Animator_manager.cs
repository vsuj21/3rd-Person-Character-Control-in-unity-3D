using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_manager : MonoBehaviour

    
{
    Animator animator;
    int horizontal;
    int vertical;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }
    public void UpdateAnimatorValues(float horizontalmovement, float verticalmovement)
    {
        float snappedHorizontal;
        float snappedVertical;
        #region snappedHorizontal
        if (horizontalmovement>0 && horizontalmovement<0.55f)
        {
            snappedHorizontal = 0.5f;
        }
        else if (horizontalmovement > 0.5f){
            snappedHorizontal = 1;
        }

        else if(horizontalmovement < 0 && horizontalmovement>-0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if (horizontalmovement < -0.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion
        #region SnappedVertical
        if (verticalmovement > 0 && verticalmovement < 0.55f)
        {
            snappedVertical = 0.5f;
        }
        else if (verticalmovement > 0.5f)
        {
            snappedVertical = 1;
        }

        else if (verticalmovement < 0 && verticalmovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalmovement < -0.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }
        #endregion
        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical,0.1f, Time.deltaTime);
    }
}
