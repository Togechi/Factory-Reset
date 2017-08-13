using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed = 8f;
    private float originalSpeed;
    private float doubleTapTimeShift;
    public float Xpadding = 1f;
    public float Ypadding = 1f;

    private float Timer;

    public GameObject hitboxSprite;


    float xmin;
    float xmax;
    float ymin;
    float ymax;

    private void Start()
    {
        originalSpeed = speed;

        hitboxSprite.SetActive(false);

        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + Xpadding;
        xmax = rightmost.x - Xpadding;

        Vector3 upmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        Vector3 botmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        ymax = upmost.y - Ypadding;
        ymin = botmost.y + Ypadding;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        bool doubleTapShift = false;

        #region MovementInput
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Time.time < doubleTapTimeShift + 0.3f)
            {
                doubleTapShift = true;
            }
            doubleTapTimeShift = Time.time;
            hitboxSprite.SetActive(true);
            speed = speed / 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = originalSpeed;
            hitboxSprite.SetActive(false);
        }

        if (doubleTapShift)
        {
            hitboxSprite.SetActive(true);
            speed = speed / 2;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }



}