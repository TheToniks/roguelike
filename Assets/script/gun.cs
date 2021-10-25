using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Joystick joystick;
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    private player player;
    private float rotZ;
    private Vector3 difference;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    private void Update()
    {
        //difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       if (Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
        {
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
            

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                if(joystick.Horizontal !=0 || joystick.Vertical != 0)
                {
                    Shoot();
                }
                
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}
