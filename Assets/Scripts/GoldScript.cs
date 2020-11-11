using UnityEngine;
using UnityEngine.UI;


public class GoldScript : MonoBehaviour
{
    public Text showGold;
    public int produceTouch;


    public int GoldAmount
    {
        get => PlayerPrefs.GetInt("AmountGold", 0);
        set => PlayerPrefs.SetInt("AmountGold", value);
    }


    void Start()
    {
        GoldAmount = PlayerPrefs.GetInt("Gold Amount");
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Gold Amount", this.GoldAmount);
    }

    void Update()
    {
        this.showGold.text = GoldAmount.ToString("0 gold");

        if (Input.GetMouseButtonDown(0))
        {
            ProduceGold();
        }
    }

    private void ProduceGold()
    {
        // skickar ett värde till GoldAmount som sedan sparar värdet i playerprefs
        this.GoldAmount += this.produceTouch;
    }
}
