using UnityEngine;

public enum Speeds { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 ,Static=5};
public enum Gamemodes { Cube = 0, Ship = 1, Ball = 2, UFO = 3, Wave = 4, Spider = 5 };

public class Movement : MonoBehaviour
{
    public Speeds CurrentSpeed;
    public Gamemodes CurrentGamemode;
    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Transform Sprite;
    public int gravityShape = 0;

    Rigidbody2D rb;

    private float[] speedValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f, 0f };
    private int Gravity = 1;
    internal bool clickProcessed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        UpdateGamemode();
    }

    void Move()
    {
        transform.position += Vector3.right * speedValues[(int)CurrentSpeed] * Time.deltaTime;
        switch (CurrentGamemode)
        {
            case Gamemodes.Cube:
                MoveCube();
                break;
            case Gamemodes.Ship:
                MoveShip();
                break;
                // Add cases for other gamemodes if needed
        }
    }

    void MoveCube()
    {
        if (OnGround())
        {
            Vector3 rotation = Sprite.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 90) * 90;
            Sprite.rotation = Quaternion.Euler(rotation);

            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 26.6581f * Gravity, ForceMode2D.Impulse);
            }
        }
        else
        {
            Sprite.Rotate(Vector3.back, 452.4152186f * Time.deltaTime * Gravity);
        }
    }

    void MoveShip()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 2);

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            rb.gravityScale = -4.314969f;
        else
            rb.gravityScale = 4.314969f;

        rb.gravityScale = rb.gravityScale * Gravity;
    }

    void UpdateGamemode()
    {
        // Implement any logic related to changing gamemodes here
    }

    bool OnGround()
    {
        return Physics2D.OverlapBox(GroundCheckTransform.position + Vector3.up - Vector3.up * (Gravity - 1 / -2), Vector2.right * 1.1f + Vector2.up * GroundCheckRadius, 0, GroundMask);
    }

    public void ChangeThroughPortal(Gamemodes gamemode, Speeds speed, int gravity, int state)
    {
        switch (state)
        {
            case 0:
                CurrentSpeed = speed;
                break;
            case 1:
                CurrentGamemode = gamemode;
                break;
            case 2:
                Gravity = gravity;
                if (CurrentGamemode == Gamemodes.Ship) // Check if the current gamemode is Ship
                {
                    if (gravityShape == 0)
                    {
                        // Rotate around the X-axis only
                        Sprite.rotation = Quaternion.Euler(180, 0, 0);
                        gravityShape = 1;
                    }
                    else
                    {
                        // Rotate around the X-axis only
                        Sprite.rotation = Quaternion.Euler(0, 0, 0);
                        gravityShape = 0;
                    }
                }
                rb.gravityScale = Mathf.Abs(rb.gravityScale) * (int)gravity;
                break;
        }
    }

}
