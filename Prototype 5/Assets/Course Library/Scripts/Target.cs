/*
 * (Luke Hensley)
 * (Prototype 5)
 * (Controls the objects in the game)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosion;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }



    private void OnMouseDown()
    {
        if (gameManager.isGameActive == true)
        {
            gameManager.updateScore(pointValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.gameOver();
        }
        Destroy(gameObject);
    }

   
}
