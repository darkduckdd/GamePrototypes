using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [Tooltip("speed for left/rigth")]
    public float dodgeSpeed = 5;
    [Tooltip(" speed forward")]
    [Range(0, 8)]
    [SerializeField]
    private float speed = 4.0f;


    public ParticleSystem Smoke;

    public GameObject PostObj;

    public Joystick joystick;

    public Slider slider;

    private AudioSource AuSr;

    //Своиство RollSpeed

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (speed > 8)
            {
                speed = 8.0f;
            }
            else if (speed < 2f)
            {
                speed = 2.0f;
            }
            else
            {
                speed = value;
            }
        }
    }

    private void Awake()
    {
        AuSr = GetComponent<AudioSource>();
    }


    private void Start()
    {
        StartCoroutine(AutoSpeed());
        PostObj.SetActive(false);
        AuSr.Play();
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_IOS || UNITY_ANDROID
        if (PauseScreenBehaviour.paused)
        {
            return;
        }

#endif
    }

    private void FixedUpdate()
    {
        if (PauseScreenBehaviour.paused)
        {
            return;
        }

        transform.position += transform.forward * Speed * Time.deltaTime;

        var movHorizontal = joystick.Horizontal;

        if (movHorizontal > 0.3f)
        {
            transform.position += transform.right * dodgeSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 10, 0);
            StartCoroutine(ResetRotation());
        }
        else if (movHorizontal < -0.3f)
        {
            transform.position -= transform.right * dodgeSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -10, 0);
            StartCoroutine(ResetRotation());
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ReduceSpeed();
        }
    }


    public void ReduceSpeed()
    {
        Speed -= 0.4f;
    }

    IEnumerator AutoSpeed()
    {
        Speed += 0.4f;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(AutoSpeed());
    }

    IEnumerator ResetRotation()
    {
        yield return new WaitForSeconds(0.35f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    /// <summary>
    /// дым при столкновений
    /// </summary>
    private void PlaySmoke()
    {
        AuSr.Stop();
        AuSr.clip = Resources.Load<AudioClip>("Audios/Death");
        if(Smoke != null)
        {
            Smoke.Play();
            PostObj.SetActive(true);
            AuSr.volume = 1;
            AuSr.Play();
        }
        Speed = 2.0f;
    }
}
