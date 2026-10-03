using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject[] Lasers;
    [SerializeField] RectTransform cross;
    [SerializeField] Transform targetPoint;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFire();
        MoveCross();
        MoveTargetPoint();
        FollowTarget();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFire()
    {
        if (isFiring)
        {
            Debug.Log("Firing");
        }

        foreach (GameObject laser in Lasers)
        {
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isFiring;
        }
        //fire sisteminin emission'a erişmesi gerek, var "variable" kısaltması
    }

    void MoveCross()
    {
        cross.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 500f))
            {
                targetPoint.position = hit.point;
            }
            else
            {
                targetPoint.position = ray.GetPoint(200f);
            }
        //raycast mantığı mouse konumunu dünyaya hizalamak oldu için kullanılır, raycast ile mouse konumunu alıp targetpoint'e atıyoruz
    }

    void FollowTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint.position - transform.position);
        foreach (GameObject laser in Lasers)
        {
            laser.transform.rotation = targetRotation;
        }
    }
}
