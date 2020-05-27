using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.UI;

public class PHP : MonoBehaviour
{
    //Setting database links to callable funcitons
    private string secretKey = "mySecretKey";
    public string AddUserURL = "https://curicol.000webhostapp.com/AddUser.php?";
    public string selectAllUsersURL = "https://curicol.000webhostapp.com/selectAIIUsers.php?";


    public int Stars;
    public float Timer;
    public int Success;

    public GameObject SaveButton;
    public GameObject UserInput;

    //Button that allowed user to upload there score to the database
    public void OnButtonClick()
    {
        //Locate the local inputfield
        InputField inputField = GameObject.Find("InputField").GetComponent<InputField>();

        //Setting statment to limit user to only  up to three charecter username
        // If no username will remind user to insert one before the score can be uploaded
        if (inputField.text.Length >= 3)
        {
            SaveButton.SetActive(false);


            Text textLabel = GameObject.Find("dataText").GetComponent<Text>();

            //Setting any lower case username input by user to be changed to a upper case username 
            inputField.text = inputField.text.ToUpper();


            textLabel.text = ("Score Saved! To View Go To Your Level Select Menu");

            AddUser(inputField.text, Stars, Timer, Success);

            UserInput.SetActive(false);
        }
        else 
        {
            inputField.text = "Type 3 characters";
        }
    }


 
    public string getAllUsers()
    {   
        //Requesting the infromation from the previous set database link  to be drawn from the database server 
         WWW GetUsers = new WWW(selectAllUsersURL);
        
        while (!GetUsers.isDone)
        {
             if (GetUsers.error != null)
          {
            Debug.Log("There was an error getting the high score:" + GetUsers.error);
          }

        }

      return GetUsers.text;
    }

    //Setting the unformation that will be uploaded to the datbase server once user presses the set button save after typing their usename
    public void AddUser(string Username, int Stars, float Timer, int Success)
    {
        //Calling my information from my manager script to collect all the data  
        Stars = GameObject.FindGameObjectWithTag("Manager").GetComponent<manager>().stars;
        Timer = GameObject.FindGameObjectWithTag("Manager").GetComponent<manager>().timer;
        Success = GameObject.FindGameObjectWithTag("Manager").GetComponent<manager>().success;

        string hash = CreateMD5(Username + Stars + Timer + Success + secretKey);
        //Settig my data to what information will be uploaded to the datbase server
        string post_url = AddUserURL + "Username=" + WWW.EscapeURL(Username) + "&StarsData=" + Stars + "&TimerData=" + Timer + "&SuccessData=" + Success + "&hash=" + hash;

        //Sending a URL with the infroamtion collected and set to be then added to the database server
        WWW post = new WWW(post_url);

        while (!post.isDone)
        {
            if (post.error != null)
            {
                print("There was and error posting the user data:" + post.error);
            }
        }


    }

    public static string CreateMD5(string input)
    {
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
       
}
