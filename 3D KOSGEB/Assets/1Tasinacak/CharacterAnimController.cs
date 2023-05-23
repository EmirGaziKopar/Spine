using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    public Animator characterAnim;

    public static bool leftMove;
    public static bool rightMove;
    public static bool jump;
    public static bool roll;
    public static bool throwBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void rollForwardDown()
    {
        roll = true;
        characterAnim.SetTrigger("Roll");
    }
    public void rightButtonDown()
    {
        if(characterAnim.GetBool("PickUp") == true)
        {
            rightMove = true;
            characterAnim.SetBool("CatchRun", true);

        }             
        if (characterAnim.GetBool("PickUp") == false) //Tutmuyorsa d�z ko�u animasyonu �al���r
        {
            rightMove = true;
            characterAnim.SetBool("Run", true);
        }

    }   
    public void rightButtonUp()
    {
        rightMove = false;
        characterAnim.SetBool("CatchRun", false);
        characterAnim.SetBool("Run", false);
        
        
    }

    public void leftButtonDown()
    {
        if(characterAnim.GetBool("PickUp") == true)
        {
            characterAnim.SetBool("CatchRunBack", true);
            leftMove = true;
        }
        if (characterAnim.GetBool("PickUp") == false)
        {
            leftMove = true;
            characterAnim.SetBool("RunBack", true);
        }
        
    }
    public void leftButtonUp()
    {

        characterAnim.SetBool("CatchRunBack", false);
        characterAnim.SetBool("RunBack", false);
        leftMove = false;

    }

    public void throwButtonDown()
    {
        if(characterAnim.GetBool("PickUp") == true) //E�er hali haz�rda topu pickUp'lad�ysak atma buttonundaki i�levler �al��s�n
        {
            throwBall = true;

            characterAnim.SetTrigger("Throw");
            characterAnim.SetBool("PickUp", false); //E�er cephane bittiyse false olmal�
        }
        
    }

    public void jumpButtonDown()
    {
        if(characterAnim.GetBool("PickUp") == true)
        {
            jump = true;
            if (CharacterMovement.counter == 0) characterAnim.SetTrigger("JumpWithBall"); //Yere de�ene kadar sadece 1 defa z�plama animasyonu �al��mas� i�in
        }
        if (characterAnim.GetBool("PickUp") == false)
        {
            jump = true;
            if (CharacterMovement.counter == 0) characterAnim.SetTrigger("Jump"); //Yere de�ene kadar sadece 1 defa z�plama animasyonu �al��mas� i�in
        }
        

    }
    
}
