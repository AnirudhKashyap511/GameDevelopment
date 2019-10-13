using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text win;
    void Start()
    {
        speed = 15.0f;
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop) 
        {
            float moveHorizontal = Input.GetAxis("Horizontal")*speed;
            float moveVertical = Input.GetAxis("Vertical")*speed;
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement);
        }
        else
        {
            Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
            GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
            rb.AddForce(movement*speed);
    }
        }
     
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            if(count!=15)
            SetCountText();
            else
            {
                win.text="WINNER!!!";
            }
        }
    }
    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
    }
}
