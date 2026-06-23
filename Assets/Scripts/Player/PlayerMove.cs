using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    [SerializeField] private float PlayerSpeed;
    public SpriteRenderer backgroundSprite;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float x = 0f;
        float y = 0f;
        Keyboard currentKeyboard = Keyboard.current;
        if (currentKeyboard != null)
        {
            if (currentKeyboard.dKey.isPressed)
            {
                x = 1f;
            }
            else if (currentKeyboard.aKey.isPressed)
            {
                x = -1f;
            }
            if (currentKeyboard.wKey.isPressed)
            {
                y = 1f;
            }
            else if (currentKeyboard.sKey.isPressed)
            {
                y = -1f;
            }
        }
        transform.position += new Vector3(x * PlayerSpeed * Time.deltaTime, y * PlayerSpeed * Time.deltaTime, 0);
    }
    private void LateUpdate()
    {
        if (backgroundSprite == null) return;
        Bounds bgBounds = backgroundSprite.bounds;
        Vector3 playerExtents = GetComponent<SpriteRenderer>().bounds.extents;
        Vector3 correctPosition = transform.position;
        correctPosition.x = Mathf.Clamp(correctPosition.x, bgBounds.min.x + playerExtents.x, bgBounds.max.x - playerExtents.x);
        correctPosition.y = Mathf.Clamp(correctPosition.y, bgBounds.min.y + playerExtents.y, bgBounds.max.y - playerExtents.y);
        transform.position = correctPosition;
    }
}
