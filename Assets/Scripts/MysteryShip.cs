using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MysteryShip : MonoBehaviour
{
    public float speed = 5f;
    public int score = 300;

    private float leftBoundary = -14f;
    private float rightBoundary = 14f;
    private int direction = 1;

    private void Start()
    {
        // Ustawienie początkowej pozycji na środku ekranu
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);

        // Rozpoczęcie ruchu
        InvokeRepeating(nameof(ChangeDirection), 0f, 30f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.right * speed * direction * Time.deltaTime;

        // Sprawdzenie granic planszy
        if (transform.position.x > rightBoundary)
        {
            direction = -1;
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < leftBoundary)
        {
            direction = 1;
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
        }
    }

    private void ChangeDirection()
    {
        direction *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("MysteryShip collided with " + other.gameObject.name);

        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Debug.Log("MysteryShip destroyed by laser");
            gameObject.SetActive(false);  // Dezaktywacja statku po trafieniu
        }
    }
}
