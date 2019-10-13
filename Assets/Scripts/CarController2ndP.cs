using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController2ndP: MonoBehaviour
{
    public static float movespeed = 7;
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

    //Getting steering input from player
    void GetMovementInput()
    {
        movement.z = -Input.GetAxis("Horizontal2");
        movement = Vector3.ClampMagnitude(movement, 1.0f);
    }

    //Rotate the car sprite
    void CharacterRotation()
    {
        if (movement != Vector3.zero)
        {
            transform.Rotate(movement * (200f * Time.deltaTime));
        }
    }

    //Automatically move the car forward according to vector right of the transform
    void MoveCar()
    {
        transform.position += transform.right * Time.deltaTime * movespeed;
    }

    //Increasing speed over time
    void Accelerate()
    {
        movespeed += 20f * Time.deltaTime;
    }

    //Check collision condition when encountering a collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCar(collision);
        checkLap(collision);
    }

    //Ensuring when staying in the collision the car does not move until exit
    private void OnCollisionStay2D(Collision2D collision)
    {
        StopCar(collision);
    }

    //"Physic" of the car when encountering different collision objects
    private void StopCar(Collision2D collision)
    {
        //When the car hit the wall or the other player, the car cannot move
        if (collision.gameObject.CompareTag("TileMapObs") || collision.gameObject.CompareTag("Player1"))
        {
            movespeed = 0;
        }

        //When the car hit the banana peel, the car will steering in a random direction
        if (collision.gameObject.CompareTag("BananaPeel"))
        {
            transform.Rotate(new Vector3(0, 0, -10) * (300f * Time.deltaTime));
        }

        //When the car hit the gas can, the car will gain double speed
        if (collision.gameObject.CompareTag("GasCan"))
        {
            movespeed *= 2;
        }
    }
    
    //This function check if the car has finished the lap or not
    private void checkLap(Collision2D collision)
    {
        //Check if the car has passed through all the check point, if yes then it is considered a complete lap
        if (collision.gameObject.CompareTag("FinishLine") && checkpoints >= 2)
        {
            lapCount++;
            GameObject.FindGameObjectWithTag("ScoreP2").GetComponent<Text>().text = "Lap: " + lapCount;
            checkpoints = 0;
        }

        //Each time the car pass a checkpoint, 1 point will be incremented
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            if (checkpoints < 2)
            {
                checkpoints++;
            }
        }
    }
}
