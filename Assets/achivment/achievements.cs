using UnityEngine;
using UnityEngine.UI;
public class achievements : MonoBehaviour
{
    public Image achievementButton;

    void Start()
    {
        if (PlayerPrefs.GetInt("LoginAchievement", 0) == 1)
        {
            
            achievementButton.GetComponent<Image>().color = Color.green;
        }
        else
        {
            
            PlayerPrefs.SetInt("LoginAchievement", 1);
            PlayerPrefs.Save();

            achievementButton.GetComponent<Image>().color = Color.green;
            Debug.Log("Достижение получено: Вход в игру");
        }
    }
}


