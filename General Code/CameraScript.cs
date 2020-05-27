using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform StartPos, EndPos, Target;
    public Transform Pos1, Pos2, Pos3, Pos4;
  
    public Vector3 temp, temp2, end, start;
    public float ZoomSpeed;
    public float DpadHorizX, DpadHorizY;
    private float _LastX, _LastY;
    public static bool IsLeft, IsRight, IsUp, IsDown;
    [SerializeField]
    private int change, previous;

 

  
    void Update()
    {
        DpadHorizX = Input.GetAxis("DPadHorizontal");
        DpadHorizY = Input.GetAxis("DPadVertical");

        IsLeft = false;
        IsRight = false;
        IsUp = false;
        IsDown = false;

        if (_LastX != DpadHorizX)
        {
            if (DpadHorizX == -1)
            {
                IsLeft = true;
                Debug.Log("Left");
          
                    change += 1;
                
            }
            else if (DpadHorizX == 1)
            {
                IsRight = true;
                Debug.Log("Right");
                if (change != 3)
                {
                    change -= 1;
                }
                else
                {
                    change = 6;
                }
            }
        }

        if (_LastY != DpadHorizY)
        {
            if (DpadHorizY == -1)
            {
                IsDown = true;
                Debug.Log("Down");
            }
            else if (DpadHorizY == 1)
            {
                IsUp = true;
                Debug.Log("Up");
            }
        }

        _LastX = DpadHorizX;
        _LastY = DpadHorizY;


        if (Input.GetKey("joystick button 0"))
        {
            change = 1;
        }
        if (Input.GetKeyUp("joystick button 0"))
        {
            
            change = 2;
        }
        

        switch (change)
        {
            case 1:
                //Change camera height to up
                end = Vector3.Lerp(transform.position, EndPos.position, ZoomSpeed);        
                transform.position = end;

                break;


            case 2:
                //Change camera height to down
                start = Vector3.Lerp(transform.position, StartPos.position, ZoomSpeed);
                transform.position = start;
                change = previous;          
           
                break;

            case 3:

          

                //Change Rotation & Position
                temp2 = Vector3.Lerp(transform.position, Pos4.position, ZoomSpeed);
                transform.position = temp2;
                transform.rotation = Quaternion.Lerp(transform.rotation, Pos4.rotation, ZoomSpeed);


                //Update the cords for Start pos and end pos
                end = new Vector3(transform.position.x, EndPos.position.y, transform.position.z);
                start = new Vector3(transform.position.x, StartPos.position.y, transform.position.z);
                EndPos.transform.position = end;
                StartPos.transform.position = start;

                previous = change;



                break;

            case 4:
                
                //Change Rotation & Position
                temp2 = Vector3.Lerp(transform.position, Pos1.position, ZoomSpeed);
                transform.position = temp2;
                transform.rotation = Quaternion.Lerp(transform.rotation, Pos1.rotation, ZoomSpeed);


                //Update the cords for Start pos and end pos 
                end = new Vector3(transform.position.x, EndPos.position.y, transform.position.z);
                start = new Vector3(transform.position.x, StartPos.position.y, transform.position.z);
                EndPos.transform.position = end;
                StartPos.transform.position = start;

                previous = change;

                break;

            case 5:
               
                //Change Rotation & Position
                temp2 = Vector3.Lerp(transform.position, Pos2.position, ZoomSpeed);
                transform.position = temp2;
                transform.rotation = Quaternion.Lerp(transform.rotation, Pos2.rotation, ZoomSpeed);


                //Update the cords for Start pos and end pos
                end = new Vector3(transform.position.x, EndPos.position.y, transform.position.z);
                start = new Vector3(transform.position.x, StartPos.position.y, transform.position.z);
                EndPos.transform.position = end;
                StartPos.transform.position = start;

                previous = change;

                break;

            case 6:
             
                //Change Rotation & Position
                temp2 = Vector3.Lerp(transform.position, Pos3.position, ZoomSpeed);
                transform.position = temp2;
                transform.rotation = Quaternion.Lerp(transform.rotation, Pos3.rotation, ZoomSpeed);

                //Update the cords for Start pos and end pos
                end = new Vector3(transform.position.x, EndPos.position.y, transform.position.z);
                start = new Vector3(transform.position.x, StartPos.position.y, transform.position.z);
                EndPos.transform.position = end;
                StartPos.transform.position = start;

                previous = change;

                break;

            default:
                change = 3;
        break;
        }


        




    }
}
