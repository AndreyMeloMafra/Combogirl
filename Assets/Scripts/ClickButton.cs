using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour {

    [Header("Clicks Control")]
    public Infos i;
    private bool clickInfinity;

    [Header("Canvas Control")]
    public Canvas notGold;
    public Canvas donate;
    public Canvas notUpdate;

    [Header("Sound Control")]
    public AudioSource upgradeComplete;
    public AudioClip sound;

    //Controle de vendas
    private int cBg, cR;

    [Header("Game Objects")]
    public GameObject face;

    [Header("Images")]
    public Image bg, r;
    public Sprite bgSprite1, bgSprite2, bgSprite3, rSprite1, rSprite2, rSprite3;
        
    public void Start()
    {
        notGold.enabled = false;

        notUpdate.enabled = false;

        donate.enabled = false;

        bg = GameObject.Find("bg").GetComponent<Image>();
        r = GameObject.Find("girl").GetComponent<Image>();

        cBg = 1;
        cR = 1;
    }

    public void Click()
    {
        i.clicks += i.sumClick;

        i.positividade += 0.01f;

    }

    public void FixedUpdate()
    {

        if (clickInfinity)
        {
            i.clicks++;
        }
    }

    public void UpgradeClick()
    {
        if (i.moneyAmount >= i.price)
        {
            i.sumClick++;

            i.moneyAmount -= i.price;

            i.price *= 3;

            upgradeComplete.PlayOneShot(sound);
        }
        else
        {
            notGold.enabled = true;

        }

        if(i.sumClick == 10)
        {
            clickInfinity = true;
        }
    }

    public void UpgradeRoupa()
    {
        if(cR > 3)
        {
            notUpdate.enabled = true;
        }

        if (i.moneyAmount >= i.priceR)
        {
            switch (cR)
            {
                case 1:
                    r.sprite = rSprite2;

                    i.priceR *= 5;
                    Debug.Log("Entrou 1");
                    cR++;

                    face.GetComponent<Animator>().SetTrigger("Happy talk");
                    break;
                case 2:
                    r.sprite = rSprite2;

                    i.priceR *= 5;
                    Debug.Log("Entrou 2");
                    cR++;

                    face.GetComponent<Animator>().SetTrigger("Happy talk");
                    break;
                case 3:
                    r.sprite = rSprite3;
                    Debug.Log("Entrou 3 ");
                    cR++;

                    face.GetComponent<Animator>().SetTrigger("Happy talk");
                    break;
            }

            i.moneyAmount -= i.priceR;

            upgradeComplete.PlayOneShot(sound);
        }
    }

    public void UpgradeBackGround()
    {
        if (cBg > 3)
        {
            notUpdate.enabled = true;
        }

        if (i.moneyAmount >= i.priceR)
        {
            switch (cBg)
            {
                case 1:
                    bg.sprite = bgSprite2;

                    i.priceBg *= 5;
                    Debug.Log("Entrou 1");
                    cBg++;

                    face.GetComponent<Animator>().SetTrigger("Happy talk");
                    break;
                case 2:
                    bg.sprite = bgSprite2;

                    i.priceBg *= 5;
                    Debug.Log("Entrou 2");
                    cBg++;

                    face.GetComponent<Animator>().SetTrigger("Happy talk");
                    break;
                case 3:
                    bg.sprite = bgSprite3;

                    i.priceBg *= 5;
                    Debug.Log("Entrou 3");
                    cBg++;

                    face.GetComponent<Animator>().SetTrigger("Happy talk");
                    break;
            }

            i.moneyAmount -= i.priceBg;

            upgradeComplete.PlayOneShot(sound);
        }
    }

    public void CloseErr1()
    {
        notGold.enabled = false;
    }

    public void CloseErr2()
    {
        notUpdate.enabled = false;
    }

    public void DonateSection()
    {
        donate.enabled = true;
    }

    public void NormalSection()
    {
        donate.enabled = false;

    }
}
