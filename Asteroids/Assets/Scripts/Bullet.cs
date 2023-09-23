using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void IncreaseScore()
    {
        Player.PUNTUACION++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        GameObject gb = GameObject.FindGameObjectWithTag("UI");
        gb.GetComponent<Text>().text = "Puntos: " + Player.PUNTUACION;
    }
}
