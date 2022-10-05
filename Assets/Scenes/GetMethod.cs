using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetMethod : MonoBehaviour
{

    [System.Serializable]

    public class Datum{
        public string id;
        public string nama;
        public string email;
        public string username;
        public string password;
        public int skor;
        public int koin;

    }

    [System.Serializable]

    public class IsiGet{
    public int status;
    public int message;
    public Datum data;
    
    }

    public void GetData()=> StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine(){
        
        string uri = "https://penaksiran.digitalparamuda.com/api/members/16";

        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError){
                Debug.Log(request.error);
            }
                
            else{
                
                IsiGet asd = JsonUtility.FromJson<IsiGet>(request.downloadHandler.text);

                //Debug.Log(request.downloadHandler.text);;

                    Debug.Log("id :" + asd.data.id);
                    Debug.Log("nama :" + asd.data.nama);
                    Debug.Log("email :" + asd.data.email);
                    Debug.Log("username :" + asd.data.username);
                    Debug.Log("password :" + asd.data.password);
                    Debug.Log("skor :" + asd.data.skor);
                    Debug.Log("koin :" + asd.data.koin);

                    Debug.Log("koin :" + asd.data.koin);
                    Debug.Log("koin :" + asd.data.koin);

            }   
                
        }
    }
}
