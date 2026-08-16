using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCharacterBasic : MonoBehaviour
{

    public GameObject pelletPrefab;
    public float speed = 0.1f;
    public float growAmount = 0.1f;
    private int pelletCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(-speed, 0f, 0f);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(speed, 0f, 0f);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.Translate(0.0f, 0f, -speed);
        }

        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(0.0f, 0f, speed);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pellet"))
        {
            Destroy(collision.gameObject);

            pelletCount = pelletCount + 1;

            string textToSay = "I have eaten " + pelletCount.ToString() + " pellets";

            Debug.Log(textToSay);

            Vector3 currScale = transform.localScale;

            currScale += Vector3.one * growAmount;

            transform.localScale = currScale;

            Instantiate(pelletPrefab, new Vector3(Random.Range(-20, 20), 1.5f, Random.Range(-20, 20)), Quaternion.identity);
        }
        

    }
}
