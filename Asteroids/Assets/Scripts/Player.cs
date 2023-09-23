using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 200f;
    public float rotationSpeed = 30000f;

    public GameObject gun, bulletPrefab;

    public static int PUNTUACION = 0;
    public static float xLimit, yLimit;


    private Rigidbody _rigid;

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        yLimit = Camera.main.orthographicSize + 1;
        xLimit = yLimit * Screen.width / Screen.height;
    }

    void Update()
    {

        MakeInfiniteSpace();
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;

        float thrust = Input.GetAxis("Thrust") * Time.deltaTime * thrustForce;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

            Bullet balaScript = bullet.GetComponent<Bullet>();

            balaScript.targetVector = transform.right;
        }
    }

    private void MakeInfiniteSpace()
    {
        var newPosition = transform.position;
        if (newPosition.x > xLimit)
        {
            newPosition.x = -xLimit + 1;
        }
        else if (newPosition.x < -xLimit)
        {
            newPosition.x = xLimit - 1;
        }
        else if (newPosition.y > yLimit)
        {
            newPosition.y = -yLimit + 1;
        }
        else if (newPosition.y < -yLimit)
        {
            newPosition.y = yLimit - 1;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PUNTUACION = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


}
