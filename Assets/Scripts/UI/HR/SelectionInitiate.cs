using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionInitiate : MonoBehaviour
{
    /*
    List<string> A = new List<string> { "Arrow",
                                        "Bat",
                                        "Bomb",
                                        //"Aura",
                                        "Dart",
                                        "Hammer",
                                        "Mace",
                                        "Cannon",
                                        "Lazer",
                                        "Dagger",
                                        "CrossBow",
                                        "FireBall",
                                        "Bullet",
                                        "Tornado",
                                        "Lightning",
                                        "Shield",};

    List<Weaphone> B = new List<Weaphone> { Arrow,
                                            Bat,
                                            Bomb,
                                            //Aura,
                                            Dart,
                                            Hammer,
                                            Mace,
                                            Cannon,
                                            Lazer,
                                            Dagger,
                                            CrossBow,
                                            FireBall,
                                            Bullet,
                                            Tornado,
                                            Lightning,
                                            Shield,};
    */

    static WeaponArrow Arrow;
    static WeaponBat Bat;
    static WeaponBomb Bomb;
    static WeaponAura Aura;
    static WeaponDart Dart;

    static WeaphoneHammer Hammer;
    static WeaphoneMace Mace;
    static WeaphoneCannon Cannon;
    static WeaphoneLazer Lazer;
    static WeaphoneDagger Dagger;

    static WeaponCrossBow CrossBow;
    static WeaponFireBall FireBall;
    static WeaponBullet Bullet;
    static WeaponTornado Tornado;
    static WeaponLightning Lightning;
    static WeaponShield Shield;

    ShowRandomItem showItem;
    // Start is called before the first frame update
    void Start()
    {
        //비활성화 오브젝트기 때문에 부모 오브젝트를 먼저 찾는다.
        Arrow = GameObject.Find("Weaphone").transform.Find("WeaponArrow").GetComponent<WeaponArrow>();
        Bat = GameObject.Find("Weaphone").transform.Find("WeaponBat").GetComponent<WeaponBat>();
        Bomb = GameObject.Find("Weaphone").transform.Find("WeaponBomb").GetComponent<WeaponBomb>();
        Aura = GameObject.Find("Weaphone").transform.Find("WeaponAura").GetComponent<WeaponAura>();
        Dart = GameObject.Find("Weaphone").transform.Find("WeaponDart").GetComponent<WeaponDart>();

        Hammer = GameObject.Find("Weaphone").transform.Find("WeaphoneHammer").GetComponent<WeaphoneHammer>();
        Mace = GameObject.Find("Weaphone").transform.Find("WeaphoneMace").GetComponent<WeaphoneMace>();
        Cannon = GameObject.Find("Weaphone").transform.Find("WeaphoneCannon").GetComponent<WeaphoneCannon>();
        Lazer = GameObject.Find("Weaphone").transform.Find("WeaphoneLazer").GetComponent<WeaphoneLazer>();
        Dagger = GameObject.Find("Weaphone").transform.Find("WeaphoneTraceDagger").GetComponent<WeaphoneDagger>();

        //CrossBow = GameObject.Find("Weaphone").transform.Find("WeaponDart").GetComponent<WeaponDart>();
        //FireBall = GameObject.Find("Weaphone").transform.Find("WeaponDart").GetComponent<WeaponDart>();
        //Bullet = GameObject.Find("Weaphone").transform.Find("WeaponDart").GetComponent<WeaponDart>();
        Tornado = GameObject.Find("Weaphone").transform.Find("WeaponTor").GetComponent<WeaponTornado>();
        //Lightning = GameObject.Find("Weaphone").transform.Find("WeaponDart").GetComponent<WeaponDart>();
        //Shield = GameObject.Find("Weaphone").transform.Find("WeaponDart").GetComponent<WeaponDart>();

        showItem = gameObject.GetComponentInParent<ShowRandomItem>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameObject.name)
        {
            case "FirstSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.FirstItem;
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.FirstItemExplain;
                break;
            case "SecondSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.SecondItem;
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.SecondItemExplain;
                break;
            case "ThirdSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.ThirdItem;
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.ThirdItemExplain;
                break;

        }
    }

    public void Selected()
    {
        /*
        for (int i = 0; i < 27; i++)
        {
            if(gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text == A[i])
            {
                B[i].gameObject.SetActive(true);
                B[i].
            }
        }*/
        switch (gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text)
        {
            /*
            case "Arrow":
                Arrow.gameObject.SetActive(true);
                Arrow.GetComponent<WeaponArrow>().LevelUp();
                break;
            case "Bat":
                Bat.gameObject.SetActive(true);
                Bat.GetComponent<WeaponBat>().LevelUp();
                break;*/
            case "Bomb":
                Bomb.gameObject.SetActive(true);
                Bomb.LevelUp();
                break;
            case "Aura":
                Aura.gameObject.SetActive(true);
                Aura.LevelUp();
                break;
            case "Dart":
                Dart.gameObject.SetActive(true);
                Dart.LevelUp();
                break;

            case "Hammer":
                Hammer.gameObject.SetActive(true);
                Hammer.LevelUp();
                break;
            case "Mace":
                Mace.gameObject.SetActive(true);
                Mace.LevelUp();
                break;
            case "Cannon":
                Cannon.gameObject.SetActive(true);
                Cannon.LevelUp();
                break;
            case "Lazer":
                Lazer.gameObject.SetActive(true);
                Lazer.LevelUp();
                break;
            case "Dagger":
                Dagger.gameObject.SetActive(true);
                Dagger.LevelUp();
                break;
        }
    }
}
