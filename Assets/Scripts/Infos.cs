using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infos : MonoBehaviour {

    //Clicks
    public Text points;
    public int clicks;
    public int sumClick;

    //Views
    public int views;
    private int viewAmount;
    private int stage;

    //Dinheiro
    private float money;
    public float moneyAmount;
    public Text moneyT;

    //Time control
    private float currentTime;
    private float currentTimeBlink;
    private float rateTime;
    private float rateTimeBlink;

    //Positividade
    public float positividade;

    //Prices
    public int price, priceBg, priceR;
    public bool noGold = false;
    public Text buy1, buy2, buy3;

    void Start () {

        sumClick = 1;

        currentTime = 0;

        currentTimeBlink = 0;

        rateTime = 10;

        rateTimeBlink = 5;

        stage = 10;

        price = 100;
        priceBg = 5000;
        priceR = 700;

        positividade = 10;
	}
	
    float TransformViews(int views){

        money = views * 3;

        return money;
        }

	private void FixedUpdate () {

        currentTime += Time.deltaTime;

        if (currentTime > rateTime){

            TransformViews(views);

            currentTime = 0;

            moneyAmount += money;

            money = 0;
        }

        /*
        if(currentTime > rateTimeClick && clicks == 0)
        {
            positividade -= 0.05f;
        }
        */
        if(clicks >= stage)
        {
            Debug.Log("Entrou");
            views++;

            viewAmount++;

            clicks = 0;
        }

        buy1.text = "Upgrade cust: " + price.ToString();
        buy2.text = "Upgrade BackGround cust: " + priceBg.ToString();
        buy3.text = "Upgrade clothes cust: " + priceR.ToString();
        points.text = "Views " + viewAmount.ToString();
        moneyT.text = "Your money: " + moneyAmount.ToString();
    }
}
