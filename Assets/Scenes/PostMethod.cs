using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PostMethod : MonoBehaviour
{
    public void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine(){
    
    string uri = "https://penaksiran.digitalparamuda.com/api/members/edit";
    WWWForm form = new WWWForm();

    form.AddField("id", "15");
    form.AddField("skor", "0");
    
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
