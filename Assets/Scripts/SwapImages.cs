using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwapImages : MonoBehaviour
{
    public Image imageHolder;
    public Sprite[] images;
    public float speedOfSwapping = 0.1f;

    int imageIndex = 0;
    SpecialAbility specialAbilityScript;

    [HideInInspector]
    public bool callAbility = false; //when to update cooldown for special ability.

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SwapPictures(int imageID)
    {
        for (int i = 0; i < 20; i++)
        {
            if (imageIndex < images.Length)
            {
                imageHolder.sprite = images[imageIndex];
                imageIndex++;
            }
            else
            {
                imageIndex = 0;
            }
            yield return new WaitForSeconds(speedOfSwapping);
        }
        imageHolder.sprite = images[imageID];
        callAbility = true;

        Debug.Log("Inside coorutine" + callAbility);

    }
}
