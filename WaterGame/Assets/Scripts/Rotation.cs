using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : Singleton<Rotation>
{
    [SerializeField] private GameObject[] rotatable;
    [SerializeField] private Rigidbody2D[] rigidbodies;
    [SerializeField] private float currentX;
    [SerializeField] private float startX = .1f;
    [SerializeField] private float ratioX;
    [SerializeField] private float deltaRotation;
    [SerializeField] private Quaternion finalRotation;
    [SerializeField] private float differenceX;

    [System.Obsolete]
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {

        rotatable = GameObject.FindGameObjectsWithTag("Rotatable");
        if (Input.GetMouseButtonDown(0))
        {
            startX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        }
        else if (Input.GetMouseButton(0))
        {
            currentX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            differenceX = currentX - startX;
            if (differenceX != 0)
            {
                if (differenceX > 0)
                {
                    ratioX = Mathf.Lerp(0.5f, 1.0f, differenceX);
                }
                else
                {
                    ratioX = Mathf.Lerp(0.5f, 0.0f, Mathf.Abs(differenceX));
                }

                deltaRotation = Mathf.Lerp(-180, 180, ratioX);

                for (int i = 0; i < rotatable.Length; i++)
                {
                    finalRotation = rotatable[i].GetComponent<Rigidbody2D>().transform.rotation * Quaternion.Euler(0, 0, deltaRotation);
                    rotatable[i].GetComponent<Rigidbody2D>().MoveRotation(finalRotation);
                }
                startX = currentX;
            }
        }



    }
}
