using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCharacterNew : MonoBehaviour
{
    public GameObject pelletPrefab;
    public float speed = 0.1f;
    public float growAmount = 0.1f;
    private int pelletCount = 0;

    public int health = 10;

    MuncherAttributes myMuncher;
    // Start is called before the first frame update
    void Start()
    {
        myMuncher = new MuncherAttributes(10, 10, 0);
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

            myMuncher.setScore(pelletCount);

            string textToSay = "I have eaten " + myMuncher.getScore().ToString() + " pellets";

            Debug.Log(textToSay);

            Vector3 currScale = transform.localScale;

            Vector3 newScale = growScale(currScale, growAmount);

            transform.localScale = newScale;

            Instantiate(pelletPrefab, new Vector3(Random.Range(-20, 20), 1.5f, Random.Range(-20, 20)), Quaternion.identity);
        }

        if (collision.transform.CompareTag("Bullet"))
        {
            int currHealth = myMuncher.getHealth();

            myMuncher.setHealth(currHealth-1);

            Debug.Log($"Ouch! My current health is {currHealth - 1}");
        }
    }

    Vector3 growScale(Vector3 scale, float amount)
    {
        scale += Vector3.one * amount;

        return scale;
    }
}
