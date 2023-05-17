using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    public Animator characterAnim;

    public static bool leftMove;
    public static bool rightMove;
    public static bool jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void rightButtonDown()
    {
        rightMove = true;
        characterAnim.SetBool("Run", true);
    }   
    public void rightButtonUp()
    {
        rightMove = false;
        characterAnim.SetBool("Run", false);
    }

    public void leftButtonDown()
    {
        leftMove = true;
        characterAnim.SetBool("RunBack", true);
    }
    public void leftButtonUp()
    {
        leftMove = false;
        characterAnim.SetBool("RunBack", false);
    }

    public void jumpButtonDown()
    {
        jump = true;
        characterAnim.SetTrigger("Jump");
    }
    
}
