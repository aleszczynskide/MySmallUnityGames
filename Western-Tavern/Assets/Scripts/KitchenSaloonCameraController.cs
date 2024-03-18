using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenSaloonCameraController : MonoBehaviour
{
    public Transform CameraTransform;
    public bool Saloon;
    public float TransitionSpeed = 5.0f;

    private Vector3 TargetPosition;

    private void Start()
    {
        TargetPosition = CameraTransform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Saloon)
            {
                Saloon = false;
                TargetPosition = new Vector3(7.5f, 11.67f,-2f);
            }
            else
            {
                Saloon = true;
                TargetPosition = new Vector3(17f, 11.67f, -2f);
            }
        }
    }

    private void Update()
    {
        if ((Vector3)CameraTransform.position != TargetPosition)

            CameraTransform.position = Vector3.Lerp(CameraTransform.position, TargetPosition, TransitionSpeed * Time.deltaTime);
    }
}

