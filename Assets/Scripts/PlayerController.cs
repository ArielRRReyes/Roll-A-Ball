﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;

    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);

	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pick Up")) {

            count++;
            other.gameObject.SetActive(false);
            SetCountText();
            if (count >= 10)
            {
                winText.text = "You Win!";
            }
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();

    }
}
