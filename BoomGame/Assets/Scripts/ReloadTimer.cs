using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadTimer : MonoBehaviour
{
    Image reloadBar;
    float maxTime = 2.5f;
    public static float timeLeft;
    public GameObject reloadingText;
    public static bool isReloading;

    // Start is called before the first frame update
    void Start()
    {
        reloadingText.SetActive(false);
        reloadBar = GetComponent<Image>();
        reloadBar.fillAmount = 0;
        timeLeft = 0;
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            reloadingText.SetActive(true);
            timeLeft -= Time.deltaTime;
            reloadBar.fillAmount = timeLeft / maxTime;
        }

        else
        {
            reloadingText.SetActive(false);
            if (isReloading == true)
            {
                Shooting.ammo = 30;
            }
            isReloading = false;
        }
    }
}
