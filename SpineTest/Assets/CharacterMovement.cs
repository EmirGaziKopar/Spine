using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed;
    public float rolSpeed;
    public float jumpParametr;
    public static int counter;
    public float gravityScale;
    float rollTime;
    float parabolTepeNokta = 0.3f;
    float parabolDip = 0;

    Vector2 gravity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = new Vector2(0, -gravityScale);
    }

    
    // Update is called once per frame
    void Update()
    {
        //ikinci se�enek rigidbody2D.velocity += new vector2() yaparak belli saniye aral���nda �al��t�rmak. Hem z�plama hem yuvarlanma yapmamal�.
        //Burada karaktere 0.5f saniye boyunca vekt�r toplamas� uyguluyoruz.
        if (CharacterAnimController.roll) //Bu �rnek olarak yaz�ld�
        {
            /*
            if (rollTime < 0.5f)
            {
                if(rollTime > 0.25f)
                {
                    if (rigidbody2D.velocity.x > 0.05f)
                    {
                        rigidbody2D.velocity -= new Vector2(rolSpeed, 0); //Ortalara do�ru yani kalkmadan �nce yava�las�n
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
                rollTime = 0; //Bir sonraki �a�r��ta h�zlanma mekani�inin tekrar �al��mas� i�in.
            }
            */
            if (rollTime < 0.5f)
            {
                rigidbody2D.velocity += new Vector2(rolSpeed*Time.deltaTime , 0); //Burada time.deltaTime kullanmaya gerek vard�r ��nk� kare ba��na anl�k artan de�erlerin toplam�n� hesapl�yoruz.  Bu �a��r�ld��� miktar kadar toplanan bir vekt�r� simgeler.           
                rollTime += Time.deltaTime;
                
            }

            else
            {
                CharacterAnimController.roll = false;
                rollTime = 0; //Bir sonraki �a�r��ta h�zlanma mekani�inin tekrar �al��mas� i�in.
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3((-speed / 50) * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3((speed / 50) * Time.deltaTime, 0, 0);
        }
        //rigidbody2D.AddForce(new Vector2(1,1));
        if (CharacterAnimController.leftMove)
        {
            transform.position += new Vector3((-speed/50) * Time.deltaTime, 0 , 0);
            /*if(counter == 0) // counter == 0 ise karakter yer ile temas etmi�tir ve yerdedir bu nedenle zemine do�ru vekt�r uygulanmas�na gerek yoktur.
            {
                rigidbody2D.velocity = new Vector2(-speed * 1, 0);
            }
            
            if (counter == 1) //karakter havada demektir ona yer �ekimi kuvveti hissiyat�n� verecek zemine ileri gitmenin yan� s�ra zemine do�ru giden bir vektor olu�turmam�z gerek 
            {
                //rigidbody2D.velocity = new Vector2(speed * 1, -speed / 1.5f * 1); daha do�al g�r�nmesi i�in
                rigidbody2D.velocity = new Vector2(-speed * 1, 0);
                rigidbody2D.AddForce(gravity);
            }
            */
        }
        if (CharacterAnimController.rightMove)
        {
            transform.position += new Vector3((speed / 50) * Time.deltaTime, 0, 0);
            /*
            if (counter == 0)
            {
                rigidbody2D.velocity = new Vector2(speed * 1, 0); //+= �eklinde giderse vekt�rler toplan�r ve karakter h�zlanarak ilerlemeye devam eder.
            }
           
            if(counter == 1) //karakter havada demektir ona yer �ekimi kuvveti hissiyat�n� verecek zemine ileri gitmenin yan� s�ra zemine do�ru giden bir vektor olu�turmam�z gerek 
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
                rigidbody2D.velocity = new Vector2(0, jumpParametr * 1);  //Burada time.deltaTime kullanmaya gerek yoktur ��nk� kare ba��na anl�k artan de�erlerin toplam�n� hesaplam�yoruz. �r transform.position += ....
            }
            
        }

        
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor") //Counter e�er 1 ise karakter hala havada demektir.
        {
            counter = 0;
            CharacterAnimController.jump = false;
        }
    }
}
