using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class SelectionInitiate : MonoBehaviour
{
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
    WeaphoneDaggerUpgrade Dagger;

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
    Accessory       Armor;
    Accessory       Prism;
    Accessory       TeleScope;

    Player_Status playerStatus;
    ShowRandomItem showItem;
    // Start is called before the first frame update
    void Start()
    {
        //비활성화 오브젝트기 때문에 부모 오브젝트를 먼저 찾는다.
        Arrow = GameObject.Find("Weapon").transform.Find("WeaponArrow").GetComponent<WeaponArrow>();
        Bat = GameObject.Find("Weapon").transform.Find("WeaponBat").GetComponent<WeaponBat>();
        Bomb = GameObject.Find("Weapon").transform.Find("WeaponBomb").GetComponent<WeaponBomb>();
        Aura = GameObject.Find("Weapon").transform.Find("WeaponAura").GetComponent<WeaponAura>();
        Dart = GameObject.Find("Weapon").transform.Find("WeaponDart").GetComponent<WeaponDart>();

        Hammer = GameObject.Find("Weapon").transform.Find("WeaponHammer").GetComponent<WeaphoneHammer>();
        Mace = GameObject.Find("Weapon").transform.Find("WeaponMace").GetComponent<WeaphoneMace>();
        Cannon = GameObject.Find("Weapon").transform.Find("WeaponCannon").GetComponent<WeaphoneCannon>();
        Lazer = GameObject.Find("Weapon").transform.Find("WeaponLazer").GetComponent<WeaphoneLazer>();
        Dagger = GameObject.Find("Weapon").transform.Find("WeaponDagger").GetComponent<WeaphoneDaggerUpgrade>();

        CrossBow = GameObject.Find("Weapon").transform.Find("WeaponCrossBow").GetComponent<WeaponCrossBow>();
        FireBall = GameObject.Find("Weapon").transform.Find("WeaponFireBall").GetComponent<WeaponFireBall>();
        Sword   = GameObject.Find("Weapon").transform.Find("WeaponSword").GetComponent<WeaponSword>();
        Tornado = GameObject.Find("Weapon").transform.Find("WeaponTornado").GetComponent<WeaponTornado>();
        Lightning = GameObject.Find("Weapon").transform.Find("WeaponLightning").GetComponent<WeaponLightning>();
        Shield = GameObject.Find("Weapon").transform.Find("WeaponShield").GetComponent<WeaponShield>();

        OldBook = GameObject.Find("Accessory").transform.Find("OldBook").GetComponent<ACC_OldBook>();
        Shoes = GameObject.Find("Accessory").transform.Find("Shoes").GetComponent<ACC_Shoes>();
        Scroll = GameObject.Find("Accessory").transform.Find("Scroll").GetComponent<ACC_Scroll>();
        Laurel = GameObject.Find("Accessory").transform.Find("Laurel").GetComponent<ACC_Laurel>();
        Chalice = GameObject.Find("Accessory").transform.Find("Chalice").GetComponent<ACC_Chalice>();
        Ring = GameObject.Find("Accessory").transform.Find("Ring").GetComponent<ACC_Ring>();
        MoneyPocket = GameObject.Find("Accessory").transform.Find("MoneyPocket").GetComponent<ACC_MoneyPocket>();
        Book = GameObject.Find("Accessory").transform.Find("Book").GetComponent<ACC_Book>();
        Bipod = GameObject.Find("Accessory").transform.Find("Bipod").GetComponent<Bipod>();

        Armor = GameObject.Find("Accessory").transform.Find("Armor").GetComponent<Accessory>();
        Prism = GameObject.Find("Accessory").transform.Find("Prism").GetComponent<Accessory>();
        TeleScope = GameObject.Find("Accessory").transform.Find("TeleScope").GetComponent<Accessory>();

        playerStatus = GameObject.Find("Player").GetComponent<Player_Status>();
        showItem = gameObject.GetComponentInParent<ShowRandomItem>();
    }

    bool Fflag = true;
    bool Sflag = true;
    bool Tflag = true;

    // Update is called once per frame
    void Update()
    {
        switch (gameObject.name)
        {
            case "FirstSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.FirstItem;
                foreach (var item in showItem.Data)
                {
                    try
                    {
                        if (showItem.FirstItem == item[1] && Fflag &&
                        int.Parse(transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text.Substring(5, 6)) > int.Parse(item[2]))
                        {
                            Fflag = false;
                            transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = "LV : " + item[2];
                        }
                    }
                    catch (System.Exception)
                    {
                        Fflag = false;
                        transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = "LV : " + item[2];
                    }
                }
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.FirstItemExplain;
                break;
            case "SecondSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.SecondItem;
                foreach (var item in showItem.Data)
                {
                    try
                    {
                        if (showItem.SecondItem == item[1] && Sflag &&
                        int.Parse(transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text.Substring(5, 6)) > int.Parse(item[2]))
                        {
                            Sflag = false;
                            transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = "LV : " + item[2];
                        }
                    }
                    catch (System.Exception)
                    {
                        Sflag = false;
                        transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = "LV : " + item[2];
                    }
                } 
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.SecondItemExplain;
                break;
            case "ThirdSelection":
                transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = showItem.ThirdItem;
                foreach (var item in showItem.Data)
                {
                    try
                    {
                        if (showItem.ThirdItem == item[1] && Tflag &&
                        int.Parse(transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text.Substring(5, 6)) > int.Parse(item[2]))
                        {
                            Tflag = false;
                            transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = "LV : " + item[2];
                        }
                    }
                    catch (System.Exception)
                    {
                        Tflag = false;
                        transform.Find("ItemLevel").GetComponent<TextMeshProUGUI>().text = "LV : " + item[2];
                    }
                }
                transform.Find("ItemExplain").GetComponent<TextMeshProUGUI>().text = showItem.ThirdItemExplain;
                break;

        }
    }

    bool weaponFlag = true;
    bool accFlag = true;

    //csv 파일 : 숫자, 이름, 레벨, 설명
    public void Selected()
    {
        switch (gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text)
        { 
            case "Arrow":
                if(Arrow.level == 1 && !Arrow.gameObject.activeSelf)
                {
                    Arrow.gameObject.SetActive(true);
                    break;
                }
                Arrow.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if(showItem.Data[i][1] == Arrow.name)
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if(Arrow.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[0]);
                }
                break;
            case "Bat":
                if (Bat.level == 1 && !Bat.gameObject.activeSelf)
                {
                    Bat.gameObject.SetActive(true);
                    break;
                }
                Bat.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Bat")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Bat.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[1]);
                }
                break;
            case "Bomb":
                if (Bomb.level == 1 && !Bomb.gameObject.activeSelf)
                {
                    Bomb.gameObject.SetActive(true);
                    break;
                }
                Bomb.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Bomb")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Bomb.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[2]);
                }
                break;
            case "Aura":
                if (Aura.level == 1 && !Aura.gameObject.activeSelf)
                {
                    Aura.gameObject.SetActive(true);
                    break;
                }
                Aura.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Aura")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Aura.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[3]);
                }
                break;
            case "Dart":
                if (Dart.level == 1 && !Dart.gameObject.activeSelf)
                {
                    Dart.gameObject.SetActive(true);
                    break;
                }
                Dart.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Dart")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Dart.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[4]);
                }
                break;

            case "Hammer":
                if (Hammer.level == 1 && !Hammer.gameObject.activeSelf)
                {
                    Hammer.gameObject.SetActive(true);
                    break;
                }
                Hammer.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Hammer")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Hammer.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[5]);
                }
                break;
            case "Mace":
                if (Mace.level == 1 && !Mace.gameObject.activeSelf)
                {
                    Mace.gameObject.SetActive(true);
                    break;
                }
                Mace.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Mace")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Mace.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[6]);
                }
                break;
            case "Cannon":
                if (Cannon.level == 1 && !Cannon.gameObject.activeSelf)
                {
                    Cannon.gameObject.SetActive(true);
                    break;
                }
                Cannon.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Cannon")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Cannon.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[7]);
                }
                break;
            case "Lazer":
                if (Lazer.level == 1 && !Lazer.gameObject.activeSelf)
                {
                    Lazer.gameObject.SetActive(true);
                    break;
                }
                Lazer.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Lazer")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Lazer.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[8]);
                }
                break;
            case "Dagger":
                if (Dagger.level == 1 && !Dagger.gameObject.activeSelf)
                {
                    Dagger.gameObject.SetActive(true);
                    break;
                }
                Dagger.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Dagger")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Dagger.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[9]);
                }
                break;

            case "CrossBow":
                if (CrossBow.level == 1 && !CrossBow.gameObject.activeSelf)
                {
                    CrossBow.gameObject.SetActive(true);
                    break;
                }
                CrossBow.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "CrossBow")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (CrossBow.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[10]);
                }
                break;
            case "FireBall":
                if (FireBall.level == 1 && !FireBall.gameObject.activeSelf)
                {
                    FireBall.gameObject.SetActive(true);
                    break;
                }
                FireBall.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "FireBall")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (FireBall.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[11]);
                }
                break;
            case "Sword":
                if (Sword.level == 1 && !Sword.gameObject.activeSelf)
                {
                    Sword.gameObject.SetActive(true);
                    break;
                }
                Sword.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Sword")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Sword.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[12]);
                }
                break;
            case "Tornado":
                if (Tornado.level == 1 && !Tornado.gameObject.activeSelf)
                {
                    Tornado.gameObject.SetActive(true);
                    break;
                }
                Tornado.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Tornado")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Tornado.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[13]);
                }
                break;
            case "Lightning":
                if (Lightning.level == 1 && !Lightning.gameObject.activeSelf)
                {
                    Lightning.gameObject.SetActive(true);
                    break;
                }
                Lightning.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Lightning")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Lightning.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[14]);
                }
                break;
            case "Shield":
                if (Shield.level == 1 && !Shield.gameObject.activeSelf)
                {
                    Shield.gameObject.SetActive(true);
                    break;
                }
                Shield.LevelUp();
                //csv 파일 : 숫자, 이름, 레벨, 설명
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Shield")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Shield.level == 5)
                {
                    showItem.Data.Remove(showItem.Data[15]);
                }
                break;

            case "OldBook":
                if (OldBook.GetLevel() == 1 && !OldBook.gameObject.activeSelf)
                {
                    OldBook.gameObject.SetActive(true);
                    break;
                }
                OldBook.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if(showItem.Data[i][1] == "OldBook")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (OldBook.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[16]);
                }
                break;
            case "Shoes":
                if (Shoes.GetLevel() == 1 && !Shoes.gameObject.activeSelf)
                {
                    Shoes.gameObject.SetActive(true);
                    break;
                }
                Shoes.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Shoes")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Shoes.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[17]);
                }
                break;
            case "Scroll":
                if (Scroll.GetLevel() == 1 && !Scroll.gameObject.activeSelf)
                {
                    Scroll.gameObject.SetActive(true);
                    break;
                }
                Scroll.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Scroll")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Scroll.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[18]);
                }
                break;
            case "Laurel":
                if (Laurel.GetLevel() == 1 && !Laurel.gameObject.activeSelf)
                {
                    Laurel.gameObject.SetActive(true);
                    break;
                }
                Laurel.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Laurel")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Laurel.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[19]);
                }
                break;
            case "Chalice":
                if (Chalice.GetLevel() == 1 && !Chalice.gameObject.activeSelf)
                {
                    Chalice.gameObject.SetActive(true);
                    break;
                }
                Chalice.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Chalice")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Chalice.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[20]);
                }
                break;
            case "Ring":
                if (Ring.GetLevel() == 1 && !Ring.gameObject.activeSelf)
                {
                    Ring.gameObject.SetActive(true);
                    break;
                }
                Ring.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Ring")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Ring.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[21]);
                }
                break;
            case "MoneyPocket":
                if (MoneyPocket.GetLevel() == 1 && !MoneyPocket.gameObject.activeSelf)
                {
                    MoneyPocket.gameObject.SetActive(true);
                    break;
                }
                MoneyPocket.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "MoneyPocket")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (MoneyPocket.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[22]);
                }
                break;
            case "Book":
                if (Book.GetLevel() == 1 && !Book.gameObject.activeSelf)
                {
                    Book.gameObject.SetActive(true);
                    break;
                }
                Book.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Book")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Book.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[23]);
                }
                break;
            case "Armor":
                if (Armor.GetLevel() == 1 && !Armor.gameObject.activeSelf)
                {
                    Armor.gameObject.SetActive(true);
                    break;
                }
                Armor.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Armor")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Armor.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[24]);
                }
                break;
            case "Prism":
                if (Prism.GetLevel() == 1 && !Prism.gameObject.activeSelf)
                {
                    Prism.gameObject.SetActive(true);
                    break;
                }
                Prism.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Prism")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Prism.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[25]);
                }
                break;
            case "TeleScope":
                if (TeleScope.GetLevel() == 1 && !TeleScope.gameObject.activeSelf)
                {
                    TeleScope.gameObject.SetActive(true);
                    break;
                }
                TeleScope.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "TeleScope")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (TeleScope.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[26]);
                }
                break;
            case "Bipod":
                if (Bipod.GetLevel() == 1 && !Bipod.gameObject.activeSelf)
                {
                    Bipod.gameObject.SetActive(true);
                    break;
                }
                Bipod.LevelUp();
                for (int i = 0; i < showItem.Data.Count; i++)
                {
                    if (showItem.Data[i][1] == "Bipod")
                    {
                        showItem.Data[i][2] = (int.Parse(showItem.Data[i][2]) + 1).ToString();
                    }
                }
                if (Bipod.GetLevel() == 5)
                {
                    showItem.Data.Remove(showItem.Data[27]);
                }
                break;
        }

        Tflag = true;
        Fflag = true;
        Sflag = true;

        for(var item = 0; item < showItem.Data.Count; item ++)
        {
            //만약 선택된 아이템의 인덱스가 16 미만이면 무기로 세팅
            if (showItem.Data[item][1] == gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text && 
                !playerStatus.weaponSet.Contains(gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text) &&
                item < 16)
            {
                playerStatus.weaponSet.Add(gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text);
            }

            if (showItem.Data[item][1] == gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text &&
                !playerStatus.accSet.Contains(gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text) &&
                item >= 16)
            {
                Debug.Log("악세서리 추가");
                playerStatus.accSet.Add(gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text);
            }
        }

        //장착한 장비의 개수가 5개면 더 이상은 장비는 추가 불가
        if(playerStatus.weaponSet.Count == 5 && weaponFlag)
        {
            for (int i = 0; i < showItem.Data.Count;)
            {
                if (showItem.Data[i][1] == "OldBook")
                    break;
                //Debug.Log(showItem.Data[i][1] + "를 확인합니다.");
                bool flag = false;

                for (int j = 0; j < playerStatus.weaponSet.Count; j++)
                {
                    //Debug.Log(weaponSet[j] + "," + showItem.Data[i][1]);
                    if (showItem.Data[i][1] == playerStatus.weaponSet[j])
                    {
                        //Debug.Log(playerStatus.weaponSet[j] + "," + showItem.Data[i][1]);
                        flag = true;
                        i++;
                    }
                }

                if(!flag)
                {
                    //Debug.Log(showItem.Data[i][1]+"를 삭제합니다." );
                    showItem.Data.Remove(showItem.Data[i]);
                }
            }
            /*
            foreach (var item in showItem.Data)
            {
                Debug.Log(item[1]);
            }
            */
            weaponFlag = false;
        }

        if (playerStatus.accSet.Count == 5 && accFlag)
        {
            for (int i = 0; i < showItem.Data.Count;)
            {
                bool flag = false;

                for (int j = 0; j < playerStatus.accSet.Count; j++)
                {
                    if (showItem.Data[i][1] == playerStatus.accSet[j])
                    {
                        flag = true;
                        i++;
                    }
                }

                if (!flag)
                {
                    showItem.Data.RemoveAt(i);
                }
            }
            accFlag = false;
        }
        /*
        foreach (var item in showItem.Data)
        {
            Debug.Log(item[1]);
        }
        */
        showItem.itemFlag = true;
        //WeaponSet.Add(gameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text);
    }
}
