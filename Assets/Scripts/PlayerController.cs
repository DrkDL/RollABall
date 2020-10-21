using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // namesapce for UI

// Difference bewteen awake and start funciton:
//-On a script that is disabled: Nothing is called(No Awake or Start functions called).
//-On a enabled script: Awake is called first when an object 'carrying' the script is first activated(enabled/initialized), 
// Start is then called when the game/application proceeds.

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;
    private int count; // number of pickups collected
    public Text countText;
    public Text winText;

    void Start() // is called when script
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }
    void Update() // is called before rendering a frame, where game code will go
    {
        
    }

    void FixedUpdate() // is called before performing any physics calculations, where physics code will go
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.AddForce(movement * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pick Up")
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
