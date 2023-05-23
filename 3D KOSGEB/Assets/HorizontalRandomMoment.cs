using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HorizontalRandomMoment : MonoBehaviour
{
    public WinController winController;
    public SpriteRenderer spriteImage;
    public NavMeshAgent agent;
    private Vector3 destination;
    public Animator animator;
    public GameObject side;
    public GameObject ball;
    public GameObject EmojiSpace, EmojiSpace2;
    public Button[] Emoji;
    public AudioSource ads;

    bool animasyonBitti;
    public float minX = -10f; // Minimum x (yatay) pozisyon deðeri
    public float maxX = 10f;  // Maximum x (yatay) pozisyon deðeri
    public float minStateTime = 1f; // Minimum durum süresi
    public float maxStateTime = 3f; // Maximum durum süresi
    public static bool ballOnSide;

    private int currentState = 0;
    private float stateTimer = 0f;
    private bool isHit = false;
    private float hitTimer = 0f;
    private Color originalColor;

    public void emojiselector(int sayi)
    {
        switch (sayi)
        {
            case 1:
                EmojiSpace2.GetComponent<SpriteRenderer>().sprite = Emoji[0].GetComponent<Image>().sprite;

                break;
            case 2:
                EmojiSpace2.GetComponent<SpriteRenderer>().sprite = Emoji[1].GetComponent<Image>().sprite;
                break;
            case 3:
                EmojiSpace2.GetComponent<SpriteRenderer>().sprite = Emoji[2].GetComponent<Image>().sprite;
                break;
            default:
                break;

        }

    }

    public void ResetEmojiState2()
    {

        EmojiSpace2.GetComponent<SpriteRenderer>().sprite = null;
    }
    public void ResetEmojiState()
    {

        EmojiSpace.GetComponent<SpriteRenderer>().sprite = null;
    }
    public void SetRandomEmoji(int RandomEmoji)
    {
        switch (RandomEmoji)
        {
            case 1:
                EmojiSpace.GetComponent<SpriteRenderer>().sprite = Emoji[0].GetComponent<Image>().sprite;

                break;
            case 2:
                EmojiSpace.GetComponent<SpriteRenderer>().sprite = Emoji[1].GetComponent<Image>().sprite;
                break;
            case 3:
                EmojiSpace.GetComponent<SpriteRenderer>().sprite = Emoji[2].GetComponent<Image>().sprite;
                break;


        }


    }


    private void Start()
    {
        agent.updateRotation = false;
        SetRandomState();
        originalColor = spriteImage.color;
    }

    public void PickUpBall()
    {
        //TOP ELE GELECEK VE ATIÞ BLA BLA

        ballOnSide = false;
    }

    private void SetRandomState()
    {
        if (ballOnSide)
        {
            Debug.Log("sahaya girdi");
            agent.SetDestination(ball.transform.position);
            PickUpBall();
        }
        else
        {
            currentState = Random.Range(1, 4); // 1, 2 veya 3 deðerlerinden rastgele bir durum seçilir

            switch (currentState)
            {
                case 1:
                    // WALK
                    SetRandomDestination();
                    break;
                case 2:
                    // IDLE-STOP
                    SetRandomStop();
                    break;
                case 3:
                    SetRandomEmoji(Random.Range(1, 8));
                    // Burada emoji gönderme iþlemleri yapýlabilir
                    break;
            }

            // Durum süresini rastgele bir deðere ayarla
            stateTimer = Random.Range(minStateTime, maxStateTime);


        }


    }

    private void SetRandomStop()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        agent.SetDestination(transform.position);
        animator.SetBool("WalkAI", false);
        spriteImage.color = Color.white;
    }

    private void SetRandomDestination()
    {
        float randomX = Random.Range(minX, maxX);
        destination = new Vector3(randomX, transform.position.y, transform.position.z);
        agent.SetDestination(destination);
        animator.SetBool("WalkAI", true);

        spriteImage.color = Color.white;
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }

    private void LateUpdate()
    {
        // Agent x ekseninde pozitif yöne gittiðinde "WalkBack" animasyonunu çalýþtýr
        if (agent.velocity.x > 0)
        {
            Debug.Log("far");
            animator.SetBool("WalkBack", true);
        }
        else
        {
            animator.SetBool("WalkBack", false);
        }
    }

    private void Update()
    {

        if (WinController.AILose)
        {
            spriteImage.color = Color.white;
            ads.volume = 0f;
            return;
        }

        if (agent.transform.position.x == destination.x)
        {

            stateTimer = 0;
            SetRandomState();
        }


        
        if (isHit)
        {
            hitTimer += Time.deltaTime;
            if (hitTimer >= 0.5f)
            {
                isHit = false;
                hitTimer = 0f;
                animator.SetBool("BallHit", false);

                SetRandomState();
            }
        }
        else
        {

            if (stateTimer <= 0f)
            {
                ResetEmojiState();
                ResetEmojiState2();
                SetRandomState();
            }

            stateTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetBool("BallHit", true);
            spriteImage.color = Color.red;
            isHit = true;
            ads.Play();
            winController.enemyhpValueCurrent -= 2f;
        }
    }
}
