using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator pickUp;
    Rigidbody2D rigidbody2D;
    public float speed;
    public float rolSpeed;
    public float jumpParametr;
    public static int counter;
    public float gravityScale;
    float rollTime;
    float parabolTepeNokta = 0.3f;
    float parabolDip = 0;
    public GameObject Ball;
    public Rigidbody2D BallRB;
    public Transform BallPosition;


    Vector2 gravity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = new Vector2(0, -gravityScale);
        pickUp = this.gameObject.GetComponent<Animator>();
    }

    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CharacterAnimController.throwBall)
        {
            Ball.SetActive(true);
            Ball.transform.position = BallPosition.position;
            BallRB.velocity = new Vector2(15f, 6f);
            CharacterAnimController.throwBall = false;
            pickUp.SetBool("Jump", false); //Eðer olurda idle'a geçtiðinde jump bool'u true olduysa top attýktan hemen sonra zýplama animasyonu çalýþmasýn diye eklendi.
        }

        //ikinci seçenek rigidbody2D.velocity += new vector2() yaparak belli saniye aralýðýnda çalýþtýrmak. Hem zýplama hem yuvarlanma yapmamalý.
        //Burada karaktere 0.5f saniye boyunca vektör toplamasý uyguluyoruz.
        if (CharacterAnimController.roll) //Bu örnek olarak yazýldý
        {
            /*
            if (rollTime < 0.5f)
            {
                if(rollTime > 0.25f)
                {
                    if (rigidbody2D.velocity.x > 0.05f)
                    {
                        rigidbody2D.velocity -= new Vector2(rolSpeed, 0); //Ortalara doðru yani kalkmadan önce yavaþlasýn
                    }
                    
                }
                else
                {
                    rigidbody2D.velocity += new Vector2(rolSpeed, 0);
                }
                rollTime += Time.fixedDeltaTime;
                
            }
            
            else
            {
                CharacterAnimController.roll = false;
                rollTime = 0; //Bir sonraki çaðrýþta hýzlanma mekaniðinin tekrar çalýþmasý için.
            }
            */
            if (rollTime < 0.5f)
            {
                rigidbody2D.velocity += new Vector2(rolSpeed, 0);
               
                rollTime += Time.fixedDeltaTime;

            }

            else
            {
                CharacterAnimController.roll = false;
                rollTime = 0; //Bir sonraki çaðrýþta hýzlanma mekaniðinin tekrar çalýþmasý için.
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed / 50, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed / 50, 0, 0);
        }
        //rigidbody2D.AddForce(new Vector2(1,1));
        if (CharacterAnimController.leftMove)
        {
            transform.position += new Vector3(-speed/50, 0 , 0);
            /*if(counter == 0) // counter == 0 ise karakter yer ile temas etmiþtir ve yerdedir bu nedenle zemine doðru vektör uygulanmasýna gerek yoktur.
            {
                rigidbody2D.velocity = new Vector2(-speed * 1, 0);
            }
            
            if (counter == 1) //karakter havada demektir ona yer çekimi kuvveti hissiyatýný verecek zemine ileri gitmenin yaný sýra zemine doðru giden bir vektor oluþturmamýz gerek 
            {
                //rigidbody2D.velocity = new Vector2(speed * 1, -speed / 1.5f * 1); daha doðal görünmesi için
                rigidbody2D.velocity = new Vector2(-speed * 1, 0);
                rigidbody2D.AddForce(gravity);
            }
            */
        }
        if (CharacterAnimController.rightMove)
        {
            transform.position += new Vector3(speed / 50, 0, 0);
            /*
            if (counter == 0)
            {
                rigidbody2D.velocity = new Vector2(speed * 1, 0); //+= þeklinde giderse vektörler toplanýr ve karakter hýzlanarak ilerlemeye devam eder.
            }
           
            if(counter == 1) //karakter havada demektir ona yer çekimi kuvveti hissiyatýný verecek zemine ileri gitmenin yaný sýra zemine doðru giden bir vektor oluþturmamýz gerek 
            {
                //rigidbody2D.velocity = new Vector2(speed * 1, -speed/1.5f * 1);
                rigidbody2D.velocity = new Vector2(speed * 1, 0);
                rigidbody2D.AddForce(gravity);
            }
            */

        }
        if (CharacterAnimController.jump)
        {
            if (counter < 1)
            {
                counter++;
                rigidbody2D.velocity = new Vector2(0, jumpParametr * 1);
            }
            
        }

        
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor") //Counter eðer 1 ise karakter hala havada demektir.
        {
            counter = 0;
            CharacterAnimController.jump = false;
        }
        if (collision.gameObject.tag == "Ball")
        {
            Ball.SetActive(false);
            pickUp.SetBool("PickUp", true);
        }
    }
}
