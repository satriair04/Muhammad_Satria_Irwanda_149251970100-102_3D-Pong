using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public string paddleName;
    public int paddleSpeed;
    public KeyCode axisNegative;
    public KeyCode axisPositive;
    private Vector3 localPaddlePosition;
    private Rigidbody rb3d;
    void Start()
    {
        rb3d = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Taro input disini biar AddForce di MovePaddle ndak laju + tembus collider
        localPaddlePosition = InputDetection();
    }

    void FixedUpdate()
    {
        MovePaddle(localPaddlePosition);
    }

    
    //Paddle bergerak berdasarkan sumbu x saja
    private Vector3 InputDetection()
    {
        if (Input.GetKey(axisPositive))
        {
            //Sumbu positif = kanan
            return Vector3.right;
        }
        if (Input.GetKey(axisNegative))
        {
            //Sumbu negatif = kiri
            return Vector3.left;
        }
        return Vector3.zero;
    }

    private void MovePaddle(Vector3 movement)
    {
        //rb3d.AddForce(movement * paddleSpeed);
        //rb3d.MovePosition(transform.position + (movement * paddleSpeed * Time.deltaTime));

        //Baris dibawah bergerak relatif terhadap koordinat pada scene/world
        //rb3d.velocity = movement * paddleSpeed;

        //Baris  dibawah bergerak relatif dari scene/world menjadi relatif terhadap Transform-nya si gameobject
        rb3d.velocity = transform.InverseTransformDirection(movement * paddleSpeed);

        //rb3d.AddForce(transform.InverseTransformDirection(movement * paddleSpeed));

        //transform.position = movement * paddleSpeed;
    }
}
