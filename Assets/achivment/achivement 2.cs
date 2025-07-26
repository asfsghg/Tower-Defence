using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achivement2 : MonoBehaviour
{
    public Image achievementButton;
    private void Start()
    {
        StartCoroutine(WaitAndDo());
    }

    private IEnumerator WaitAndDo()
    {
        
        yield return new WaitForSeconds(5f);
        achievementButton.GetComponent<Image>().color = Color.green;



    }
    

    
}

        
        
            
            

