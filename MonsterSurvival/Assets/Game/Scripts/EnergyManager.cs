using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] TMP_Text textEnergy, textTimer;
    public int
        maxEnergy,
        adsEnergy = 1,
        totalEnergy = 0,
        restoreDuration = 10;
    [SerializeField] DateTime nextEnergyTime, lastAddedTime;
    [SerializeField] Button button;
    public static EnergyManager sharedInstance;
    bool restoring = false;
    string value;
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        {
            if (!PlayerPrefs.HasKey("totalEnergy"))
            {
                totalEnergy = 3;  // or what do you want to your need value
                
                StartCoroutine(RestoreRoutine());
            }
            else
            {
                Load();
                StartCoroutine(RestoreRoutine());
            }
            Debug.Log("Energy Manager Initialized");
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            textEnergy = FindObjectOfType<TotalLifeTMP>().GetComponent<TMP_Text>();
            textTimer = FindObjectOfType<LifeTimerTMP>().GetComponent<TMP_Text>();
            textTimer.text = value;
            textEnergy.text = totalEnergy.ToString() + "/" + maxEnergy.ToString();
        }
    }

    private void Update()
    {
        var tryButton = GameObject.FindObjectOfType<TryAgainButton>();
        if (tryButton != null)
        {
            button = tryButton.GetComponent<Button>();
        }
        else
        {
            button = null;
        }

    }

    public void UseEnergy()
    {
        if (totalEnergy == 0)
            return;
        totalEnergy--;
        UpdateEnergy();
        if (!restoring)
        {
            if (totalEnergy + 1 == maxEnergy)
            {
                nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);
            }
            StartCoroutine(RestoreRoutine());
        }
    }

    public IEnumerator RestoreRoutine()
    {
        UpdateTimer();
        UpdateEnergy();
        restoring = true;

        while (totalEnergy < maxEnergy)
        {
            DateTime currentTime = DateTime.Now;
            DateTime counter = nextEnergyTime;
            bool isAdding = false;

            while (currentTime > counter)
            {
                if (totalEnergy < maxEnergy)
                {
                    isAdding = true;
                    totalEnergy++;
                    DateTime timeToAdd = lastAddedTime > counter ? lastAddedTime : counter;
                    counter = AddDuration(timeToAdd, restoreDuration);
                }
                else
                    break;
            }

            if (isAdding)
            {
                lastAddedTime = DateTime.Now;
                nextEnergyTime = counter;
            }
            UpdateTimer();
            UpdateEnergy();
            Save();
            yield return null;
        }
        restoring = false;
    }

    public void UpdateTimer()
    {
        if (totalEnergy >= maxEnergy)
        {
            textTimer.text = "Full";
            return;
        }
        TimeSpan t = nextEnergyTime - DateTime.Now;
        value = String.Format("{0:D2}:{1:D2}", (int)t.TotalMinutes, t.Seconds);

        textTimer.text = value;
    }

    public void UpdateEnergy()
    {
        if (totalEnergy == 0)
        {
            if (button != null)
            {
                button.interactable = false;
            }
        }
        else if (totalEnergy >= maxEnergy)
        {
            totalEnergy = maxEnergy;
            if (button != null)
            {
                button.interactable = true;
            }
        }

        textEnergy.text = totalEnergy.ToString() + "/" + maxEnergy.ToString();
    }

    private DateTime AddDuration(DateTime time, int duration)
    {
        return time.AddSeconds(duration);
    }
    private void Load()
    {
        totalEnergy = PlayerPrefs.GetInt("totalEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastAddedTime = StringToDate(PlayerPrefs.GetString("lastAddedTime"));
    }

    private void Save()
    {
        PlayerPrefs.SetInt("totalEnergy", totalEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastAddedTime", lastAddedTime.ToString());
    }

    private DateTime StringToDate(string date)
    {
        if (String.IsNullOrEmpty(date))
        {
            return DateTime.Now;
        }
        return DateTime.Parse(date);
    }

    public void ExtraLife()
    {
        totalEnergy += adsEnergy;
        UpdateEnergy();
        UpdateTimer();
    }
}
