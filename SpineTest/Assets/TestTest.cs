using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;



public class TestTest : MonoBehaviour
{
    public SkeletonAnimation test;
    private const string runAnim = "run";
    private const string backWalkAnim = "back_walk";
    private const string idleAnim = "ýdle";
    private const string jumpAnim = "jump";
    int sayac = 0;
    int sayac2 = 0;
    int sayac3 = 0;

    public bool D;
    public bool A;

    public float speed;
    public float backSpeed;


    const int movementTrack = 0;
    public bool control;

    // Start is called before the first frame update
    void Start()
    {
        test.AnimationState.SetAnimation(movementTrack, runAnim, true);
    }

    private void FixedUpdate()
    {
        if (A)
        {
            transform.Translate(-transform.right*backSpeed);
        }
        if (D)
        {
            transform.Translate(transform.right*speed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            D = true;
            sayac2 = 0;
            control = true;
            if (sayac < 1)
            {
                sayac++;
                test.AnimationState.SetAnimation(movementTrack, runAnim, true);
            }
            
            
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            D = false;
            sayac = 0;
            test.AnimationState.SetAnimation(movementTrack, runAnim, false);
            control = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            A = true;
            sayac2 = 0;
            control = true;
            if (sayac < 1)
            {
                sayac++;
                test.AnimationState.SetAnimation(movementTrack, backWalkAnim, true);
            }
            
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            A = false;
            sayac = 0;
            test.AnimationState.SetAnimation(movementTrack, backWalkAnim, false);
            control = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            sayac3++;
            if (sayac3 < 2)
            {                
                test.AnimationState.SetAnimation(movementTrack, jumpAnim, true);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            
            test.AnimationState.SetAnimation(movementTrack, jumpAnim, false);
            control = false;
        }


        if (control == false)
        {
            if(sayac2 < 1)
            {
                sayac2++;
                test.AnimationState.SetAnimation(movementTrack, idleAnim, true);
            }
            
        }
        Debug.Log(sayac3);

        //test.AnimationState.AddAnimation(1, "asdasd", true, 5f);
    }
}
