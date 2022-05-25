using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : MonoBehaviour
{
    public GameObject levelUpScreen;
    public PlayerStats playerStats;
    public PowerUpsPool powerUpsPoolManager;
    public TMP_Text power1Name, power1Description, power2Name, power2Description, power3Name, power3Description, power1Level, power2Level,power3Level;
    public GameObject power1New, power2New, power3New;
    public GameObject power1Icon, power2Icon, power3Icon;
    public PowersManager powersManager;
    int randomPower1, randomPower2, randomPower3;
    PowerInfo power1Info, power2Info, power3Info;

    public void ShowLevelUpScreen()
    {
        levelUpScreen.SetActive(true);
        Time.timeScale = 0;
        ShowPower1();
        ShowPower2();
        ShowPower3();



    }
    public void HideLevelupScreen()
    {
        levelUpScreen.SetActive(false);
        Time.timeScale = 1;
    }


    public void ShowPower1()
    {
        randomPower1 = Random.Range(0, powerUpsPoolManager.powerUps.Count);
       // Debug.Log(randomPower1);
        power1Info = powerUpsPoolManager.powerUps[randomPower1].GetComponent<PowerInfo>();

        if (GameObject.FindGameObjectWithTag(power1Info.powerName) == null)
        {
          //  Debug.Log("No existe 1");
            power1Name.text = power1Info.powerName.ToString();
            power1Description.text = powerUpsPoolManager.powerUps[randomPower1].GetComponent<PowerInfo>().powerDescription.ToString();
            power1Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower1].GetComponent<PowerInfo>().powerIcon;
            power1Level.text = "New";
            power1New.SetActive(true);
        }
        else
        {
            // Debug.Log("poder 1 existe");
            power1Name.text = GameObject.FindGameObjectWithTag(power1Info.powerName).GetComponent<PowerInfo>().powerName.ToString();
            power1Description.text = GameObject.FindGameObjectWithTag(power1Info.powerName).GetComponent<PowerInfo>().powerDescription.ToString();
            power1Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower1].GetComponent<PowerInfo>().powerIcon;
            power1Level.text = " Level:" + (GameObject.FindGameObjectWithTag(power1Info.powerName).GetComponent<PowerInfo>().currentLevel + 1).ToString();
            power1New.SetActive(false);
        }
          // powerUpsPoolManager.powerUps.RemoveAt(randomPower1);
    }

    public void ShowPower2()
    {
        randomPower2 = Random.Range(0, powerUpsPoolManager.powerUps.Count);
       // Debug.Log(randomPower2);
        power2Info = powerUpsPoolManager.powerUps[randomPower2].GetComponent<PowerInfo>();

        while(randomPower2==randomPower1)
        {
            ShowPower2();
         //   Debug.Log("Poder 2 = 1");
        }

        if (GameObject.FindGameObjectWithTag(power2Info.powerName) == null)
        {
           // Debug.Log("No existe 2");
            power2Name.text = power2Info.powerName.ToString();
            power2Description.text = powerUpsPoolManager.powerUps[randomPower2].GetComponent<PowerInfo>().powerDescription.ToString();
            power2Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower2].GetComponent<PowerInfo>().powerIcon;
            power2Level.text = "New";
            power2New.SetActive(true);
        }
        else
        {
          //  Debug.Log("poder 2 existe");
            power2Name.text = GameObject.FindGameObjectWithTag(power2Info.powerName).GetComponent<PowerInfo>().powerName.ToString();
            power2Description.text = GameObject.FindGameObjectWithTag(power2Info.powerName).GetComponent<PowerInfo>().powerDescription.ToString() ;
            power2Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower2].GetComponent<PowerInfo>().powerIcon;
            power2Level.text = " Level:" + (GameObject.FindGameObjectWithTag(power2Info.powerName).GetComponent<PowerInfo>().currentLevel + 1).ToString();
            power2New.SetActive(false);


        }
        //powerUpsPoolManager.powerUps.RemoveAt(randomPower2);
    }

    public void ShowPower3()
    {
        randomPower3 = Random.Range(0, powerUpsPoolManager.powerUps.Count);
        //Debug.Log(randomPower3);
        power3Info = powerUpsPoolManager.powerUps[randomPower3].GetComponent<PowerInfo>();

        while (randomPower3 == randomPower1 || randomPower3 == randomPower2)
        {
            ShowPower3();
           // Debug.Log("Poder 3 = 1 || poder 3 = 1");
        }

        if (GameObject.FindGameObjectWithTag(power3Info.powerName) == null)
        {
            //Debug.Log("No existe 3");
            power3Name.text = power3Info.powerName.ToString();
            power3Description.text = powerUpsPoolManager.powerUps[randomPower3].GetComponent<PowerInfo>().powerDescription.ToString();
            power3Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower3].GetComponent<PowerInfo>().powerIcon;
            power3Level.text = "New";
            power3New.SetActive(true);

        }
        else
        {
          //  Debug.Log("poder 3 existe");
            power3Name.text = GameObject.FindGameObjectWithTag(power3Info.powerName).GetComponent<PowerInfo>().powerName.ToString();
            power3Description.text = GameObject.FindGameObjectWithTag(power3Info.powerName).GetComponent<PowerInfo>().powerDescription.ToString();
            power3Icon.GetComponent<Image>().sprite = powerUpsPoolManager.powerUps[randomPower3].GetComponent<PowerInfo>().powerIcon;
            power3Level.text = " Level:" + (GameObject.FindGameObjectWithTag(power3Info.powerName).GetComponent<PowerInfo>().currentLevel + 1).ToString();
            power3New.SetActive(false);

        }
        //powerUpsPoolManager.powerUps.RemoveAt(randomPower3);

    }

    public void ChoosePower1()
    {
        powersManager.CheckRandomPower(randomPower1);
        AudioManager.sharedInstance.ChoosePowerSound();
        HideLevelupScreen();


    }

    public void ChoosePower2()
    {
        powersManager.CheckRandomPower(randomPower2);
        AudioManager.sharedInstance.ChoosePowerSound();
        HideLevelupScreen();

    }
    public void ChoosePower3()
    {
        powersManager.CheckRandomPower(randomPower3);
        AudioManager.sharedInstance.ChoosePowerSound();
        HideLevelupScreen();

    }
}
