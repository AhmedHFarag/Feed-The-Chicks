using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class PlayersManager : MonoBehaviour
{
    public static PlayersManager current;

    [SerializeField]
    public GameObject[] playersHUD;

    public GameObject[] players;
    public Transform[] playerPositions;
    bool[] playersFlag;

    List<int> playersControlles;
    List<int> PlayersAvatar;
    //public playersList playersList;


    // Use this for initialization
    void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);
        current = this;
        playersList temp = FindObjectOfType<playersList>();
        playersControlles = temp.PlayerList;//playersAvatarsAndControllers.PlayerList;
        PlayersAvatar = temp.AvatarList; //playersAvatarsAndControllers.AvatarList;

        //players = GameObject.FindGameObjectsWithTag("Player");
        //bubbleSort(players);

        // playersFlag = new bool[players.Length];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> EnablePlayers()
    {
        List<GameObject> playingPlayers = new List<GameObject>();
        for (int i = 0; i < playersControlles.Count; i++)
        {
            GameObject p1 = Instantiate(players[PlayersAvatar[i]].gameObject);
            p1.SetActive(true);
            p1.transform.position = playerPositions[i].position;

            ChickenController p1ChickenController = p1.GetComponent<ChickenController>();
            Healthbar p1Healthbar = p1.GetComponent<Healthbar>();
            ExtentedFeatures p1ExtentedFeature = p1.GetComponent<ExtentedFeatures>();
            SpecialAbility p1SpecialAbility = p1.GetComponent<SpecialAbility>();

            p1ChickenController.id = playersControlles[i];

            //Attach player Hud 
            for (int j = 0; j < playersHUD.Length; j++)
            {
                Debug.Log(p1ChickenController.id +" - "+ playersHUD[j].transform.GetChild(0).GetComponent<Text>().text);
                if (p1ChickenController.id == int.Parse(playersHUD[j].transform.GetChild(0).GetComponent<Text>().text))
                {
                    p1Healthbar.healthBar = playersHUD[j].transform.GetChild(2).GetComponent<Slider>();

                    p1ExtentedFeature.bashCoolDownSlider = playersHUD[j].transform.GetChild(4).GetComponent<Slider>();

                    p1SpecialAbility.abilityCoolDown = playersHUD[j].transform.GetChild(5).GetComponent<Slider>();

                    p1SpecialAbility.imageHolder = playersHUD[j].transform.GetChild(5).transform.GetChild(0).GetComponent<Image>();

                    break;
                }
            }

            playingPlayers.Add(p1);

            //players[PlayersAvatar[i]].GetComponent<ChickenController>().id = playersControlles[i];
            //playersFlag[PlayersAvatar[i]] = true;
        }

        //for (int i = 0; i < playersFlag.Length; i++)
        //{
        //    if (playersFlag[i])
        //    {
        //        playingPlayers.Add(players[i]);
        //    }
        //    else
        //    {
        //        Destroy(players[i]);
        //    }
        //}

        return playingPlayers;
    }

    void bubbleSort(GameObject[] objects)
    {
        bool exchanges;
        GameObject temp;
        do
        {
            exchanges = false;
            for (int i = 0; i < objects.Length - 1; i++)
            {
                if (int.Parse(objects[i].name) > int.Parse(objects[i + 1].name))
                {
                    // Exchange elements
                    temp = objects[i];
                    objects[i] = objects[i + 1];
                    objects[i + 1] = temp;
                    exchanges = true;
                }
            }
        } while (exchanges);
    }
}
