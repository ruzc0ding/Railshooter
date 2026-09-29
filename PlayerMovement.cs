using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;
    [SerializeField] float controlSpeed = 10f;
    void Start()
    {

    }
    void Update()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float xPos = transform.localPosition.x + xOffset;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float yPos = transform.localPosition.y + yOffset;
        transform.localPosition = new Vector2(xPos, yPos);
    }

    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
}

