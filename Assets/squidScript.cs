using UnityEngine;

public class squidScript : MonoBehaviour
{
    Rigidbody2D rb;   
    public int thrust;
    public float max_velo = 50;
    public float moveTreshold = 0.01f;
    public bool safe = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && rb.linearVelocity.magnitude < max_velo)
        {
            rb.AddForce(new Vector2(0, 1) * thrust);

        }
        if (Input.GetKey(KeyCode.S) && rb.linearVelocity.magnitude < max_velo)
        {
            rb.AddForce(new Vector2(0, -1) * thrust);
        }
        if (Input.GetKey(KeyCode.D) && rb.linearVelocity.magnitude < max_velo)
        {
            rb.AddForce(new Vector2(1, 0) * thrust);
        }
        if (Input.GetKey(KeyCode.A) && rb.linearVelocity.magnitude < max_velo)
        {
            rb.AddForce(new Vector2(-1, 0) * thrust);
        }
      

    }
    public bool IsMoving()
    {
        return rb.linearVelocity.magnitude > moveTreshold;
    }


}
