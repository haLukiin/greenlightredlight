using Unity.VisualScripting;
using UnityEngine;

public class dollScript : MonoBehaviour
{
    private bool hasLineOfSight = false;
    public float turnInterval = 10f;
    private GameObject player;
    private bool playerInside = false;
    private squidScript playerMovement;
 

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TurnRoutine());
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<squidScript>();

    }
    System.Collections.IEnumerator TurnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(turnInterval);
            Flip();
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }



    // Update is called once per frame
    void Update()
    {      
      
        
    }
    bool CanSeePlayer()
    {
        return true;
    }
    void KillPlayer()
    {
        Debug.Log("Player DIED!");
        Destroy(player.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.CompareTag("Player"))
            playerInside = true;
     
    }   

       
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInside = false;   
    }

    private void FixedUpdate()
    {
        if (playerInside)
        {
            if (player != null && CanSeePlayer())
            {
                if (playerMovement.IsMoving())
                {
                    KillPlayer();
                    
                }

            }

            Vector2 toPlayer = (player.transform.position - transform.position).normalized;
            Vector2 forward = -transform.right;

            float dot = Vector2.Dot(forward, toPlayer);
            if (dot < 0)
            {
                hasLineOfSight = false;
                return;
            }
            RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
            if (ray.collider != null)
            {
                hasLineOfSight = ray.collider.CompareTag("Player");
                if (hasLineOfSight)
                {
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                }
                else
                {
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                }
            }
        }
    }
   
}
