using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public Transform target;
    private GameController gC;
    public int lives = 5;
    public float fireRate;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gCO = GameObject.FindWithTag("GameController");
        gC = gCO.GetComponent<GameController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 1.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (lives < 1)
        {
            Destroy(this.gameObject);
            gC.Score += 100;
        }
        CheckIfTimeToFire();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            lives = lives - 1;
            Debug.Log("SE");
            Destroy(other.gameObject);
        }
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}

