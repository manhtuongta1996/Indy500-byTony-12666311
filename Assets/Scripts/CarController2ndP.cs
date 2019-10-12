using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController2ndP: MonoBehaviour
{
    public static float movespeed = 5;
    private Vector3 movement;
    private int lapCount = 0;
    private int checkpoints = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        CharacterRotation();
        MoveCar();
        Accelerate();
    }

    void GetMovementInput()
    {
        movement.z = -Input.GetAxis("Horizontal2");
        movement = Vector3.ClampMagnitude(movement, 1.0f);
    }
    void CharacterRotation()
    {
        if (movement != Vector3.zero)
        {
            transform.Rotate(movement * (75f * Time.deltaTime));
        }
    }

    void MoveCar()
    {
        transform.position += transform.right * Time.deltaTime * movespeed;
    }

    void Accelerate()
    {
        movespeed += 20f * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCar(collision);
        checkLap(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        StopCar(collision);
    }


    private void StopCar(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TileMapObs") || collision.gameObject.CompareTag("Player1"))
        {
            movespeed = 0;
        }
    }

    private void checkLap(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FinishLine") && checkpoints >= 2)
        {
            lapCount++;
            GameObject.FindGameObjectWithTag("ScoreP2").GetComponent<Text>().text = "Lap: " + lapCount;
            checkpoints = 0;
        }

        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            if (checkpoints < 2)
            {
                checkpoints++;
                Debug.Log(checkpoints);
            }
        }
    }
}
