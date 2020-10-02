using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    [SerializeField]
    public float armor;
    private bool hit = true;
<<<<<<< HEAD
    private Animator animator;
=======
>>>>>>> master
    public GameObject armorRectangle;

    void Awake()
    {
    }

    void Update()
    {
        updateArmorBoxes();
    }

    void updateArmorBoxes()
    {
        int tempArmorBoxes = (int)(armor / 10);
        int actualArmorBoxes = GameObject.Find("Armor-Box").transform.childCount;

        while (tempArmorBoxes != actualArmorBoxes)
        {
            if (tempArmorBoxes < actualArmorBoxes)
            {
                for (int i = 0; i <= actualArmorBoxes - tempArmorBoxes; i++)
                {
                    Destroy(GameObject.Find("Armor-Box").transform.GetChild(i).gameObject);
                    actualArmorBoxes--;
                }
            }
            else if (tempArmorBoxes > actualArmorBoxes)
            {
                for (int i = 0; i < tempArmorBoxes - actualArmorBoxes; i++)
                {
                    GameObject go = Instantiate(armorRectangle, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    go.transform.SetParent(GameObject.Find("Armor-Box").transform);
                    actualArmorBoxes++;
                }
            }
        }
    }

<<<<<<< HEAD
    public void armorDecrease()
    {
        armor -= 5;
=======
    public void ArmorReduction(int reduction)
    {
        armor -= reduction;
>>>>>>> master
    }
}