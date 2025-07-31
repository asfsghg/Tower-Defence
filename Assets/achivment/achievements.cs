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
            Invoke(nameof(ChangeColor), 0f);
        }
    }
    void ChangeColor()
    {
        Color newColor = Color.green;
        achievementButton.color = newColor;
        PlayerPrefs.SetFloat("R", newColor.r);
        PlayerPrefs.SetFloat("G", newColor.g);
        PlayerPrefs.SetFloat("B", newColor.b);
        PlayerPrefs.Save();
    }

    void LoadColor()
    {
        float r = PlayerPrefs.GetFloat("R", 1f);
        float g = PlayerPrefs.GetFloat("G", 1f);
        float b = PlayerPrefs.GetFloat("B", 1f);
        achievementButton.color = new Color(r, g, b);
    }
}


