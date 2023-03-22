using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour
{

    float fallSpeed;
    float rotSpeed;
    bool isGameOver;
    void Start()
    {
        this.fallSpeed = (2f * Time.deltaTime) + ((3f * Time.deltaTime) * Random.value);
        this.rotSpeed = (120f * Time.deltaTime) + ((300f * Time.deltaTime) * Random.value);
    }

    void Update()
    {
        transform.Translate(0, -fallSpeed, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed);

        if (transform.position.y < -5.5f)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            isGameOver = true;
            Destroy(gameObject);
        }
    }
}