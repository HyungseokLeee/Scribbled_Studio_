using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed;
    private Vector2 movement;
    private Vector2 fixedMovement;
    private float horiz;
    private float vert;
    private bool canMove = true;
    private GameController gC;
    public float rotateSpeed;
    public Animator animator;

    [Header("Attack Settings")]
    public GameObject bullet;
    public GameObject bulletSpawn;
    public float fireRate;
    private Rigidbody2D rBody;

    private float timer = 0.0f;
    private float myTime = 0.0f;
    public AudioSource hurt;

    GameObject hpO;
    HpBarController hpBarController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gCO = GameObject.FindWithTag("GameController");
        gC = gCO.GetComponent<GameController>();
        rBody = GetComponent<Rigidbody2D>();
        hpO = GameObject.FindWithTag("HpStatus");
        hpBarController = hpO.GetComponent<HpBarController>();

        Debug.Log($"Current firerateLev:{gC.FirerateLev}");

    }

    void Update()
    {
        timer -= Time.deltaTime;
        myTime += Time.deltaTime;
        if (timer >= 0.0)
        {
            //fireRate = 0.10f;
            if (Input.GetKey("space") && myTime > fireRate)
            {
                Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                myTime = 0.0f;
            }
        }
        else
        {
            if (Input.GetKey("space") && myTime > fireRate)
            {
                Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                myTime = 0.0f;
            }
        }
        //fireRate = 0.15f;

        //Animation boolean triggers
        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walk", false);
        }
        //idle shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Shoot", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Shoot", false);
        }
    }
    void FixedUpdate()
    {
        //if (canMove)
        //{
        //    // Read input
        //    horiz = Input.GetAxis("Horizontal");
        //    vert = Input.GetAxis("Vertical");
        //}
        ////Debug.Log("x: " + horiz + ",y: " + vert);

        //movement = new Vector2(horiz, vert);
        float moveHoriz = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveHoriz, 0, 0);

        float moveVert = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(0, moveVert, 0);

        //Move the Player
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;

        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }
    public void reduceFirerate()
    {
        float originalRate = fireRate;
        if(gC.FirerateLev == 0)
        {
            gC.addFirerateLev(1);
            fireRate = originalRate * 0.75f;
        }
        else if (gC.FirerateLev == 1)
        {
            gC.addFirerateLev(1);
            fireRate = originalRate * 0.5f;
        }
        Debug.Log($"Originalfirerate:{originalRate}");
        Debug.Log($"\nFireratelev : {gC.FirerateLev} \nFireRate:{fireRate}");

    }
    private void takeDamage()
    {
        gC.HP -= 20;
        hpBarController.SetDamage(20.0f);
        Debug.Log("Hit");
        if(gC.HP <= 0)
        {
            decreaseLife();
        }
    }
    private void decreaseLife()
    {
        if(gC.Lives > 0)
        {
            gC.Lives -= 1;
            gC.HP = 100;
            hpBarController.health = 100;
        }
        else
        {
            gC.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(col.gameObject);
            takeDamage();
            hurt.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            takeDamage();
            hurt.Play();
        }
    }
}