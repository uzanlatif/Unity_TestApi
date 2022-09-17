using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PostMethod : MonoBehaviour
{
    public void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine(){
    
    string uri = "https://reqres.in/api/users/";
    WWWForm form = new WWWForm();

    form.AddField("juminten", "marko");
    using (UnityWebRequest request = UnityWebRequest.Post(uri,form)){

        yield return request.SendWebRequest();
        if(request.isNetworkError || request.isHttpError){
            Debug.Log(request.error);
        }
        else{
            Debug.Log(request.downloadHandler.text);
        }
            
    }

    }

}
