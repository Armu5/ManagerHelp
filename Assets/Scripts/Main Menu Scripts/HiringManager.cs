using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using JetBrains.Annotations;

public class HiringManager : MonoBehaviour
{
    public TextMeshProUGUI FailText;
    [Space]
    public List<CrewMember> AvailableCrewMembers;
    [Space]
    public HireSlot[] HireSlots;
    [Header("Reroll Options")]
    public int RerollCost = 100;
    public Button RerollButton;
    [Header("Panels Options")]
    public Button ShowPartyMembersBtn;
    public GameObject PartyMembersPanel;
    public GameObject HiringPanel;

    private void Start()
    {
        // Give errors if the memebres list is not populated in inspector
        if(AvailableCrewMembers == null)
        {
            Debug.LogError("Please add some crew members in hiring manager inpector before playing!");
            return;
        }

        if(AvailableCrewMembers.Count == 0)
        {
            Debug.LogError("Please add some crew members in hiring manager inpector before playing!");
            return;
        }
        RerollCrewMembers(false);

        RerollButton.onClick.AddListener(delegate { RerollCrewMembers(); });
        FailText.text = string.Empty;

        HiringPanel.SetActive(true);
        PartyMembersPanel.SetActive(false);
        ShowPartyMembersBtn.onClick.RemoveAllListeners();
        ShowPartyMembersBtn.onClick.AddListener(delegate
        {
            PartyMembersPanel.SetActive(true);
            HiringPanel.SetActive(false);
        });
    }

    private void RerollCrewMembers(bool deductCost = true)
    {
        if(deductCost && PlayerProfile.Gold < RerollCost)
        {
            ShowFailText("NOT ENOUGH GOLD!");
            return;
        }

        if(deductCost)
            PlayerProfile.Gold -= RerollCost;

        List<int> selectedRandoms = new List<int>();

        for(int i = 0; i < HireSlots.Length; i++)
        {
            int randomIndex = Random.Range(0, AvailableCrewMembers.Count);
            while(selectedRandoms.Contains(randomIndex))
                randomIndex = Random.Range(0, AvailableCrewMembers.Count);

            selectedRandoms.Add(randomIndex);

            CrewMember crewMember = AvailableCrewMembers[randomIndex];

            UpdateHireSlot(HireSlots[i], crewMember);
        }
    }

    private void UpdateHireSlot(HireSlot slot, CrewMember crewMember)
    {
        slot.NameText.text = crewMember.name;
        slot.CardInfoText.text = crewMember.cardInfo;
        slot.CostText.text = crewMember.cost.ToString();
        slot.CardImage.sprite = crewMember.image;

        slot.HireButton.onClick.RemoveAllListeners();
        slot.HireButton.onClick.AddListener(delegate
        {
            bool hiredSuccess = HireCrewMember(crewMember);
            if(hiredSuccess) slot.HireButton.interactable = false;
        });
        slot.HireButton.interactable = true;
    }

    private bool HireCrewMember(CrewMember crewMember)
    {
        if(PartyManager.Instance.CanHireMore() == false)
        {
            ShowFailText("ALREADY HIRED " + PartyManager.Instance.MaxPartySize + " PARTY MEMBERS!");
            return false;
        }

        if(crewMember.cost > PlayerProfile.Gold)
        {
            ShowFailText("NOT ENOUGH GOLD!");
            return false;
        }

        // Deduct cost
        PlayerProfile.Gold -= crewMember.cost;

        // add to hired party members
        PartyManager.Instance.AddCrewMember(crewMember);
        Debug.Log(crewMember.name + " hired!");

        return true;
    }



    #region FAIL TEXT SHOWING

    Coroutine failTextCo;
    private void ShowFailText(string val)
    {
        if(failTextCo != null)
            StopCoroutine(failTextCo);

        failTextCo = StartCoroutine(ShowFailTextCo(val));
    }

    IEnumerator ShowFailTextCo(string val)
    {
        FailText.text = val;
        yield return new WaitForSecondsRealtime(1f);
        FailText.text = string.Empty;
    }

    #endregion
}
