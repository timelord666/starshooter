using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    private GameConroller gameConroller;

    private void Start()
    {
        GameObject gameControlerObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameControlerObj != null)
        {
            gameConroller = gameControlerObj.GetComponent<GameConroller>();
        }
        if (gameControlerObj == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameConroller.GameOver();
        }
        gameConroller.AddScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
