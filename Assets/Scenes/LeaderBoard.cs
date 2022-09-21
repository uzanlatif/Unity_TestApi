using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LeaderBoard : MonoBehaviour
{
    [System.Serializable]

    public class Datum{
        public Self[] self;
        public Lb[] lb;

    }

    [System.Serializable]

    public class Self{
        public int id;
        public int id_member;
        public string user;
        public int skor;
        public string created_at;
        public string updated_at;
        public string game;
        public int level;
        public string nama;
        public string email;
        public int nik;

    }

    [System.Serializable]

    public class Lb{

        public int id;
        public int id_member;
        public string user;
        public int skor;
        public string created_at;
        public string updated_at;
        public string game;
        public int level;
        public string nama;
        public string email;
        public int nik;

    }

    [System.Serializable]

    public class Root{

    public int status;
    public string message;
    public Datum data;
    
    
    }


    public void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine(){
    
    string uri = "https://penaksiran.digitalparamuda.com/api/leaderboard/query";
    WWWForm form = new WWWForm();

    form.AddField("id_member", "16");
    
    using (UnityWebRequest request = UnityWebRequest.Post(uri,form)){

        yield return request.SendWebRequest();
        if(request.isNetworkError || request.isHttpError){
            Debug.Log(request.error);
        }
        else{
            Debug.Log(request.downloadHandler.text);
            Root asd = JsonUtility.FromJson<Root>(request.downloadHandler.text);

            //self
            Debug.Log("self");
            
            Debug.Log("id :" + asd.data.self[0].id);
            Debug.Log("id member :" + asd.data.self[0].id_member);
            Debug.Log("user:" + asd.data.self[0].user);
            Debug.Log("skor :" + asd.data.self[0].skor);

            //lb
            Debug.Log("Leaderboards");

            for(int i = 0; i < asd.data.lb.Length; i++){
                Debug.Log("id :" + asd.data.lb[i].id);
                Debug.Log("id member :" + asd.data.lb[i].id_member);
                Debug.Log("user:" + asd.data.lb[i].user);
                Debug.Log("skor :" + asd.data.lb[i].skor);
            }

        }
            
    }

    }
}
