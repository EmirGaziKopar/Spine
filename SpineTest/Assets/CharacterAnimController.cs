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

    public void throwButtonDown()
    {
        if(characterAnim.GetBool("PickUp") == true) //Eðer hali hazýrda topu pickUp'ladýysak atma buttonundaki iþlevler çalýþsýn
        {
            throwBall = true;

            characterAnim.SetTrigger("Throw");
            characterAnim.SetBool("PickUp", false); //Eðer cephane bittiyse false olmalý
        }
        
    }

    public void jumpButtonDown()
    {
        jump = true;
        if (CharacterMovement.counter == 0) characterAnim.SetTrigger("Jump"); //Yere deðene kadar sadece 1 defa zýplama animasyonu çalýþmasý için

    }
    
}
