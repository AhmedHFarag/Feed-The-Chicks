using UnityEngine;
using System.Collections;

public class NewTuorialManger : MonoBehaviour
{

    public float loseTime = 2f; //time between every lose
    public float amountOfLoose = 10f;//amount of loaseing energy
    public Healthbar playersHealth;

    public GameObject Crumb;
    public GameObject SpecialCrumb;

    public GenerateCramb CrumbPool;

    //for animations
    public Animator playerUI;
    public Animator decHealthPanel;
    public Animator IncHealthPanel;
    public Animator bashCoolDown;
    public Animator specialAbilityCoolDown;
    public Animator useSpecialAbility;
    public Animator ShowAI;
    public Animator Jumb;
    public Animator Bash;
    public Animator Finish;

    void Awake()
    {
        playerUI.enabled = true;
        decHealthPanel.enabled = true;
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoseEnergy());
        StartCoroutine(ShowCrumb());
        // StartCoroutine(ShowSpecialCrumb());

        IntroCrumbBehavoiur.onPlayerEatOrdenaryCrumb += increaseHealthAnimation;
        IntroCrumbBehavoiur.onPlayerEatCrumbWithAbility += ShowAbilityPanel;
        IntroChicksController.onUseSpecialAbility += useSpecialAbilityevent;
        IntroSpecialAbility.OnSpecialAbilityTimeEnded += SpecialAbilityTimeEnded;
        EndJump.OnEndJumb += Endjumb;
        IntroExtendedFeature.OnBashing += Bashing;
        //IntroExtendedFeature.OnBashingEnd += BashingEnd;
    }
    void increaseHealthAnimation()
    {
        decHealthPanel.SetTrigger("RemoveDecreaseHelthPanel");
        IncHealthPanel.enabled = true;
        ShowSpecialCrumb();
        IntroCrumbBehavoiur.onPlayerEatOrdenaryCrumb -= increaseHealthAnimation;
    }
    void ShowAbilityPanel()
    {
        IncHealthPanel.SetTrigger("IncHealthDeath");
        useSpecialAbility.enabled = true;
        IntroCrumbBehavoiur.onPlayerEatCrumbWithAbility -= ShowAbilityPanel;
    }
    void useSpecialAbilityevent()
    {
        useSpecialAbility.SetTrigger("useSpecialAbilityDeath");
        specialAbilityCoolDown.enabled = true;
        IntroChicksController.onUseSpecialAbility -= useSpecialAbilityevent;
    }
    void SpecialAbilityTimeEnded()
    {
        specialAbilityCoolDown.SetTrigger("SpecialAbilityCoolDownDeath");
        ShowAI.enabled = true;
        Jumb.enabled = true;
        IntroSpecialAbility.OnSpecialAbilityTimeEnded -= SpecialAbilityTimeEnded;
    }
    void Endjumb()
    {
        Jumb.SetTrigger("JumpAbilityDeath");
        Bash.enabled = true;
        EndJump.OnEndJumb -= Endjumb;
    }
    void Bashing()
    {
        Bash.SetTrigger("BashAbilityDeath");
        bashCoolDown.enabled = true;
        StartCoroutine(BashingEnd());
        IntroExtendedFeature.OnBashing -= Bashing;
    }
    IEnumerator BashingEnd()
    {
        //event manf3etsh 3lshan b3ml chargeBash bytnada 3leha lama ysheel sba3o mn 3ala el bas f bt7sal m3 el bash pressing
        yield return new WaitForSeconds(3.5f);
        bashCoolDown.SetTrigger("bashCoolDownDeath");
        Finish.enabled = true;
        //CrumbPool.enabled = true;
        //IntroExtendedFeature.OnBashingEnd -= BashingEnd;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LoseEnergy()
    {
        while (true)
        {
            playersHealth.Damage(amountOfLoose);

            yield return new WaitForSeconds(loseTime);
        }
    }

    IEnumerator ShowCrumb()
    {
        yield return new WaitForSeconds(5);
        Crumb.SetActive(true);
        yield return null;
    }

    void ShowSpecialCrumb()
    {
        //yield return new WaitForSeconds(15);
        SpecialCrumb.SetActive(true);
        //yield return null;
    }
}
