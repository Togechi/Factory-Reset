using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundUp : MonoBehaviour
{

    public bool scrolling, parallax;

    public float backgroundSize;
    public int xPosition;
    public float parallaxSpeed;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.y;
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (parallax)
        {
            float deltaX = cameraTransform.position.y - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCameraX = cameraTransform.position.y;

        if (scrolling)
        {
            if (cameraTransform.position.y < (layers[leftIndex].transform.position.y + viewZone))
                ScrollLeft();
            if (cameraTransform.position.y > (layers[rightIndex].transform.position.y - viewZone))
                ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = new Vector3((1 * layers[leftIndex].position.y - backgroundSize), 0, xPosition);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;

    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = new Vector3((1 * layers[rightIndex].position.y + backgroundSize), 0, xPosition);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

}

//Vector3.right* (layers[rightIndex].position.y - backgroundSize);