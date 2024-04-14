using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTrain : MonoBehaviour
{
    public int health = 25;
    public int currentHealth;

    public Transform[] respawnPositions;

    public int respawnLimit = 10;
    public int respawnCount = 0;

   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void getDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            StartCoroutine(RespawnDelay());
        }
    }

    void Respawn()
    {
        if (respawnCount < respawnLimit)
        {
            int randomIndex = Random.Range(0, respawnPositions.Length);
            transform.position = respawnPositions[randomIndex].position;
            gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Tutorial ended");
        }
    }

    IEnumerator RespawnDelay()
    {
    yield return new WaitForSeconds(0.25f);
    gameObject.SetActive (false);
    respawnCount++;
    Respawn();
    }

}