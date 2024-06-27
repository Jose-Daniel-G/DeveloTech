using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;

public class UnityLoginLogutRegister : MonoBehaviour
{
    [Header("Crear Cuenta")][Space]
    public string baseUrl = "http://localhost/www/UnityLoginLogoutRegister/";
    public InputField username;
    public InputField password;
    public Text info;

    public void AccountRegister(){
        string user = username.text; 
        string pass = password.text; 
        StartCoroutine(RegisterNewAccount(user, pass)); 
    }

    public void AccountLogin(){
        string user = username.text; 
        string pass = password.text; 
        StartCoroutine(LoginAccount(user, pass)); 
    }

    IEnumerator RegisterNewAccount(string username, string password){
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        using(UnityWebRequest www = UnityWebRequest.Post(baseUrl, form)){
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }else{
                string responseText = www.downloadHandler.text;
                Debug.Log("Response = "+responseText);
                info.text = "Response = " +responseText;
            }
        }
    }
    
    IEnumerator LoginAccount(string username, string password){
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        using(UnityWebRequest www = UnityWebRequest.Post(baseUrl, form)){
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }else{
                string responseText = www.downloadHandler.text;
                Debug.Log("Response = "+responseText);
                info.text = "Response = " +responseText;
            }
        }
    }
}
