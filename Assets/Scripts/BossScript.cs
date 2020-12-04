using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int lives = 50;
    public Transform target;
    public GameObject bullet;
    public GameObject key;
    public GameObject position1;
    public GameObject position2;
    public double fireRate;
    public double nextFire;
    // Start is called before the first frame update
    void Update()
    {
        if (lives < 1)
        {
            Instantiate(key);
            Destroy(position1);
            Destroy(position2);
            Destroy(this.gameObject);
        }

        else if (lives < 11)
        {
            PhaseThree();
        }

        else if (lives < 31)
        {
            PhaseTwo();
        }

        else if (lives < 51)
        {
            PhaseOne();
        }
        Vector3 targ = target.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+270));
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

    void PhaseThree()
    {
        fireRate = 0.25;
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void PhaseTwo()
    {
        fireRate = 0.75;
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void PhaseOne()
    {
        fireRate = 1;
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
