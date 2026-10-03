using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;

    [Header("Player Movement")]
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampedRange = 8f;
    [SerializeField] float yClampedRange = 6f; //range ayarlama ve kamera kısıtlama diyebiliriz 

    [Header("Player Rotation")]
    [SerializeField] float rollControl = 20f;
    [SerializeField] float pitchControl = 15f;
    void Start()
    {

    }
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float xPos = transform.localPosition.x + xOffset;
        float xClampedPos = Mathf.Clamp(xPos, -xClampedRange, xClampedRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float yPos = transform.localPosition.y + yOffset;
        float yClampedPos = Mathf.Clamp(yPos, -yClampedRange, xClampedRange);
        transform.localPosition = new Vector3(xClampedPos, yClampedPos, 0f);
    }

    private void ProcessRotation()
    {  //quaternion targetı belirlemek içindi, lerp de daha smooth olmasını sağlıyor
        Quaternion targetRotation = Quaternion.Euler(-pitchControl * movement.y, 0f, -rollControl * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * 5f);
    }
    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
}

