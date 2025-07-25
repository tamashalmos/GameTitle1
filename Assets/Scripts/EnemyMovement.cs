using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private Transform player;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        PlayerMovement playerMovement = FindAnyObjectByType<PlayerMovement>();

        if (playerMovement != null)
        {
            player = playerMovement.transform;
        }
        else
        {
            Debug.LogError("PlayerMovement not found in scene.");
        }


    }

    void Update()
    {
        if (player != null)
        {
            // Egyszerű követés 2D-ben
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
            if (player.position.x >= transform.position.x)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
             }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(gameObject);
            Debug.Log("dmg");
        }
        

    }
}
