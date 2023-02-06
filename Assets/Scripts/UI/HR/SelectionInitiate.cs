using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionInitiate : MonoBehaviour
{
    public List<string> WeaponSet = new List<string> { };
    public bool FullSet = false;

    WeaponArrow Arrow;
    WeaponBat Bat;
    WeaponBomb Bomb;
    WeaponAura Aura;
    WeaponDart Dart;

    WeaphoneHammer Hammer;
    WeaphoneMace Mace;
    WeaphoneCannon Cannon;
    WeaphoneLazer Lazer;
    WeaphoneDagger Dagger;

    WeaponCrossBow CrossBow;
    WeaponFireBall FireBall;
    WeaponSword Sword;
    WeaponTornado Tornado;
    WeaponLightning Lightning;
    WeaponShield Shield;

    ACC_OldBook     OldBook;
    ACC_Shoes       Shoes;
    ACC_Scroll      Scroll;
    ACC_Laurel      Laurel;
    ACC_Chalice     Chalice;
    ACC_Ring        Ring;
    ACC_MoneyPocket MoneyPocket;
    ACC_Book        Book;
    Bipod           Bipod;

    //갑옷, 프리즘, 망원경은 악세서리로 묶는다.
    Accessory[] accessory;

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

        Hammer = GameObject.Find("Weaphone").transform.Find("WeaponHammer").GetComponent<WeaphoneHammer>();
        Mace = GameObject.Find("Weaphone").transform.Find("WeaponMace").GetComponent<WeaphoneMace>();
        Cannon = GameObject.Find("Weaphone").transform.Find("WeaponCannon").GetComponent<WeaphoneCannon>();
        Lazer = GameObject.Find("Weaphone").transform.Find("WeaponLazer").GetComponent<WeaphoneLazer>();
        Dagger = GameObject.Find("Weaphone").transform.Find("WeaponDagger").GetComponent<WeaphoneDagger>();

        CrossBow = GameObject.Find("Weaphone").transform.Find("WeaponCrossBow").GetComponent<WeaponCrossBow>();
        FireBall = GameObject.Find("Weaphone").transform.Find("WeaponFireBall").GetComponent<WeaponFireBall>();
        Sword   = GameObject.Find("Weaphone").transform.Find("WeaponSword").GetComponent<WeaponSword>();
        Tornado = GameObject.Find("Weaphone").transform.Find("WeaponTornado").GetComponent<WeaponTornado>();
        Lightning = GameObject.Find("Weaphone").transform.Find("WeaponLightning").GetComponent<WeaponLightning>();
        Shield = GameObject.Find("Weaphone").transform.Find("WeaponShield").GetComponent<WeaponShield>();

        OldBook = GameObject.Find("Accessory").transform.Find("OldBook").GetComponent<ACC_OldBook>();
        Shoes = GameObject.Find("Accessory").transform.Find("Shoes").GetComponent<ACC_Shoes>();
        Scroll = GameObject.Find("Accessory").transform.Find("Scroll").GetComponent<ACC_Scroll>();
        Laurel = GameObject.Find("Accessory").transform.Find("Laurel").GetComponent<ACC_Laurel>();
        Chalice = GameObject.Find("Accessory").transform.Find("Chalice").GetComponent<ACC_Chalice>();
        Ring = GameObject.Find("Accessory").transform.Find("Ring").GetComponent<ACC_Ring>();
        MoneyPocket = GameObject.Find("Accessory").transform.Find("MoneyPocket").GetComponent<ACC_MoneyPocket>();
        Book = GameObject.Find("Accessory").transform.Find("Book").GetComponent<ACC_Book>();
        Bipod = GameObject.Find("Accessory").transform.Find("Bipod").GetComponent<Bipod>();

        accessory = GameObject.Find("Accessory").transform.GetComponentsInChildren<Accessory>();

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
        switch (gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text)
        { 
            case "Arrow":
                Arrow.gameObject.SetActive(true);
                Arrow.LevelUp();
                break;
            case "Bat":
                Bat.gameObject.SetActive(true);
                Bat.LevelUp();
                break;
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
                Aura.LevelUp();
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

            case "CrossBow":
                CrossBow.gameObject.SetActive(true);
                CrossBow.LevelUp();
                break;
            case "FireBall":
                FireBall.gameObject.SetActive(true);
                FireBall.LevelUp();
                break;
            case "Sword":
                Sword.gameObject.SetActive(true);
                Sword.LevelUp();
                break;
            case "Tornado":
                Tornado.gameObject.SetActive(true);
                Tornado.LevelUp();
                break;
            case "Lightning":
                Lightning.gameObject.SetActive(true);
                Lightning.LevelUp();
                break;
            case "Shield":
                Shield.gameObject.SetActive(true);
                Shield.LevelUp();
                break;

            case "OldBook":
                OldBook.gameObject.SetActive(true);
                OldBook.LevelUp();
                break;
            case "Shoes":
                Shoes.gameObject.SetActive(true);
                Shoes.LevelUp();
                break;
            case "Scroll":
                Scroll.gameObject.SetActive(true);
                Scroll.LevelUp();
                break;
            case "Laurel":
                Laurel.gameObject.SetActive(true);
                Laurel.LevelUp();
                break;
            case "Chalice":
                Chalice.gameObject.SetActive(true);
                Chalice.LevelUp();
                break;
            case "Ring":
                Ring.gameObject.SetActive(true);
                Ring.LevelUp();
                break;
            case "MoneyPocket":
                MoneyPocket.gameObject.SetActive(true);
                MoneyPocket.LevelUp();
                break;
            case "Book":
                Book.gameObject.SetActive(true);
                Book.LevelUp();
                break;
            case "Armor":
                accessory[0].gameObject.SetActive(true);
                break;
            case "Prism":
                accessory[1].gameObject.SetActive(true);
                break;
            case "TeleScope":
                accessory[2].gameObject.SetActive(true);
                break;
            case "Bipod":
                Bipod.gameObject.SetActive(true);
                break;
        }
        WeaponSet.Add(gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text);
    }
}
