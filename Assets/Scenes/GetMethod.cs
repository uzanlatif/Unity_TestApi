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
        public string email;
        public string first_name;
        public string last_name;
        public string avatar;
    }

    [System.Serializable]

    public class IsiGet{
    public int page;
    public int per_page;
    public int total;
    public int total_pages;
    public Datum[] data;
    
    }

    public void GetData()=> StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine(){
        
        string uri = "https://reqres.in/api/users?page=2";

        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError || request.isHttpError){
                Debug.Log(request.error);
            }
                
            else{
                
                IsiGet asd = JsonUtility.FromJson<IsiGet>(request.downloadHandler.text);

                Debug.Log(request.downloadHandler.text);
                Debug.Log(asd.page);
                Debug.Log(asd.data.Length);

                for(int i = 0; i < asd.data.Length;i++){
                    Debug.Log("id :" + asd.data[i].id);
                    Debug.Log("id :" + asd.data[i].email);
                    Debug.Log("id :" + asd.data[i].first_name);
                    Debug.Log("id :" + asd.data[i].last_name);
                    Debug.Log("id :" + asd.data[i].avatar);
                }

                
            }   
                
        }
    }
}
