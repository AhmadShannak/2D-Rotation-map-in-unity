using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    
    // VARS SECTION
    /// <summary>
    /// The time of the roation in a spesific direction by a certain speed ( speed[0]=10, time[0]=10,direction[0]=0 means for 10 sec the rotation speed is 10 and the direction of the rotation is right).
    /// </summary>
    private static float[] time;
    /// <summary>
    /// The speed of the rotation related to the time array ( speed[0]=10, time[0]=10,direction[0]=0 means for 10 sec the rotation speed is 10 and the direction of the rotation is right).
    /// </summary>
    private static float[] speed;
    /// <summary>
    /// The direction to where the rotate will be (r means Right, l means Left)
    /// </summary>
    private static char[] direction;
    static int directionMultiplier = 0; // Do i rotate left or right at a spesific time (Right = -1, left = -1)
    static bool keepRotating = false; // Start rotating 
    public static int i = 0; // Index pointer to controll the index of the 3 arrays
 
    // FUNCTIONS SECTION

    // Start is called before the first frame update
    void Start()
    {  
        i = 0; // Always make sure the index refresh on start
    }

    // Update is called once per frame
    void Update()
    {
        if (keepRotating) // If i can rotate then call the rotate function (TO ONLY CALL THE FUNCTION WHEN TRUE)
           Rotate(speed[i]); // Rotate  to the direction set above by the spesific speed
        

    }

    /// <summary>
    /// Set the direction of the rotation to the right or the left by sending dir[i] to this function.
    /// </summary>
    static void SetDirection(char directionAtCertainTime)
    {
        // If the passed val is r or R then rotate the circle to the right
        if (directionAtCertainTime == 'r' || directionAtCertainTime == 'R')
        {
            directionMultiplier = -1; // Set the val to multiply the speed to -1, which mean rotate it to a negative axis
        }
        // If the passed val is l or L then rotate the circle to the left
        else if(directionAtCertainTime == 'l' || directionAtCertainTime == 'L')
        {
            directionMultiplier = 1; // Set the val to multiply the speed to 1, which mean rotate it to a positive axis 
        }
    }

    /// <summary>
    /// Rotate by the speed that is passed as a parameter 
    /// </summary>
    void Rotate(float speedAtCertainTime)
    {
          this.transform.Rotate(0, 0, speedAtCertainTime * directionMultiplier); // Rotate  by a spesific speed (if the speed is -x then rotate me to the right,else to the left)
    }

    /// <summary>
    /// Rotation manager is to called after setting all arrays, speed[],direction,time[]
    /// Make sure to set all arrays to be equal in size else error
    /// </summary>
    public static IEnumerator RotationManager()
    {
        // Check if all arrays are equal in size else error
        if (time.Length == direction.Length && direction.Length == speed.Length)
        {
             i = 0; // The index of the arrays 
            
            while (i < time.Length)
            {
                
                // Set the direction 
                SetDirection(direction[i]);
                // Start rotating
                keepRotating = true;
                
                // Wait t time before moving to the next index (next rotation step)
                while (true)
                {
                    yield return new WaitForSecondsRealtime(time[i]);
                    keepRotating = false;
                    break;
                }
                   
                i++; // Next index BABBY

            }
        }
        
        yield return new WaitForSecondsRealtime(0f); // Just to handel the length of the arrays = 0
    }

    /// <summary>
    /// This function set the size of all arrays (time,speed,direction) to the passed parameter
    /// </summary>
    /// <param name="size"> Referts to the size of all arrays.</param>
    public static void SetSizeForAllArrays(int size)
    {
        
        /// All arrays need to be set to the same size 
        time = new float[size]; // Setting time array size
        speed = new float[size]; // Setting speed array size
        direction = new char[size]; // Setting direction array size
    }

    ///<summary>
    /// Set the Speed ,time,direction at a specific index.
    /// </summary>
    /// <param name="index"> refers to the index to set (speed,time,direction) at.</param>
    /// <param name="rotationDirection"> Refers to where the rotation will be at that spesific index(r = right, l = left).</param>
    /// <param name="rotationSpeed">Referes to how fast will the rotation be at that specific index. </param>
    /// <param name="rotationTime"> Referes to how long the rotation will be at that specific index.</param>
    public static void SetRotationDetails(int index, float rotationSpeed,float rotationTime,char rotationDirection)
    {
        
        speed[index] = rotationSpeed; // Set speed[index] to the passed param
        time[index] = rotationTime; // Set time[index] to the passed param
        direction[index] = rotationDirection; // Set direction[index] to the passed param

    }

}
