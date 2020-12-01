using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb;
    [HideInInspector]
    public Animator anim;
    public GameObject destruction;
    [HideInInspector]
    public float timer;
    public float startTimer;
    public TrailRenderer trail;
    public GameObject teleport;
    public static bool isTeleported;
    [HideInInspector]
    private float opTimer;
    public float startOpTimer;
    public static bool isOp = false;
    [HideInInspector]
    public bool isClicked;
    public static bool isMaxed;
    public float slideSpeed;
    public static int killCount;
    public float bigTimer;
    private float privateBigTimer;
    private AudioSource sounds;
    public AudioClip teleportationSound;
    public AudioClip explosionSound;
    public AudioClip powerUp;
    public AudioClip heart;
    public static bool isFlying;
    private bool stop;
    public static bool isTutorial;
    public AudioSource music;
    public static int tutKillCount;
    private bool isMusic = false;
    private bool repeat = true;
    public static bool repeatTutorial = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sounds = GetComponent<AudioSource>();
        timer = startTimer;
        opTimer = startOpTimer;
        privateBigTimer = bigTimer;
        if (repeatTutorial)
        {
            isTutorial = true;
        }
        if (volume.isChanged)
        {
            sounds.volume = volume.x;
            music.volume = volume.x;
        }
        if (Buttons.isChanged == true)
        {
            if (Buttons.grph)
            {
                Camera.main.GetComponent<PostProcessLayer>().enabled = true;
            }
            if (Buttons.grph == false)
            {
                Camera.main.GetComponent<PostProcessLayer>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isFlying = true;
            rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
            anim.SetTrigger("idle");
        } else
        {
            isFlying = false;
            anim.SetTrigger("float");
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime * -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

    }
    private void Update()
    {
        if(Buttons.isPaused)
        {
            Time.timeScale = 0f;
            sounds.enabled = false;
        }
        if(Buttons.isPaused == false)
        {
            sounds.enabled = true;
            Time.timeScale = 1f; 
        }
        if (volume.isChanged)
        {
            sounds.volume = volume.x;
            music.volume = volume.x;
        }
        if (isTutorial == false)
        {
            repeatTutorial = false;
        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1) && timer <= 0 && isTutorial == false)
        {
            trail.time = -1;
            Instantiate(teleport, transform.position, Quaternion.identity);
            sounds.clip = teleportationSound;
            sounds.Play();
            transform.position = mousePos;
            isTeleported = true;
            Instantiate(teleport, transform.position, Quaternion.identity);
            timer = startTimer;
            stop = true;

        } else
        {
            if (isTutorial == false)
            {
                timer -= Time.deltaTime;
            }
            if (stop)
            {
                trail.time = 1;
                stop = false;
            }
        }
        
        if(PowerUp.isCollected && privateBigTimer >= 0)
        {
            anim.SetBool("exithuge", false);
            anim.SetBool("huge", true);
            privateBigTimer -= Time.deltaTime;
        } else
        {
            anim.SetBool("exithuge", true);
            anim.SetBool("huge", false);
            privateBigTimer = bigTimer;
            PowerUp.isCollected = false;
        }
        if(PowerUp.sound)
        {
            sounds.clip = powerUp;
            sounds.Play();
            PowerUp.sound = false;
        }
        if(HeartPower.collectSound)
        {
            sounds.clip = heart;
            sounds.Play();
            HeartPower.collectSound = false;
        }
        if(isTutorial)
        {
            music.pitch = 0.5f;
        } 
        if(isTutorial == false)
        {
            if (Projectile.musika)
            {
                music.pitch = Mathf.Lerp(music.pitch, 1, Time.deltaTime * 5);
            }
            if (repeat == true)
            {
                isMusic = true;
            }
        }
        if(isMusic)
        {
            repeat = false;
            music.time = 0;
            isMusic = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Meteorite"))
        {
            sounds.clip = explosionSound;
            sounds.Play();
            if (isTutorial == false)
            {
                killCount++;
            }
            if (isTutorial)
            {
                tutKillCount++;
            }
            Destroy(collision.gameObject);
            Instantiate(destruction, transform.position, Quaternion.identity);
        }
    }
    
}
