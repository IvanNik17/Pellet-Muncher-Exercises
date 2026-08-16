using UnityEngine;

public class MoveCharacterNew : MonoBehaviour
{
    public GameObject pelletPrefab;
    public float speed = 0.1f;
    public float growAmount = 0.1f;
    private int pelletCount = 0;

    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0.0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.W))
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

            Vector3 newScale = growScale(currScale, growAmount);

            transform.localScale = newScale;

            Instantiate(pelletPrefab, new Vector3(Random.Range(-20, 20), 1.5f, Random.Range(-20, 20)), Quaternion.identity);
        }


    }

    Vector3 growScale(Vector3 scale, float amount)
    {
        scale += Vector3.one * amount;

        return scale;
    }
}
