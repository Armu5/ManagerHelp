using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HiringManager : MonoBehaviour
{
    public Transform[] hireSlots;
    public Button rerollButton;

    private List<CrewMember> availableCrewMembers = new List<CrewMember>();

    private void Start()
    {
        InitializeCrewMembers();
        rerollButton.onClick.AddListener(RerollCrewMembers);
        RerollCrewMembers();
    }

    private void InitializeCrewMembers()
    {
        availableCrewMembers.Add(new CrewMember("John", "Cards: Attack", 100, Resources.Load<Sprite>("CharacterArt/PORTRAITS TONED JPGs/Mothership Chars 07")));
        availableCrewMembers.Add(new CrewMember("Jane", "Cards: Defense", 120, Resources.Load<Sprite>("CharacterArt/PORTRAITS TONED JPGs/Mothership Chars 08")));
        availableCrewMembers.Add(new CrewMember("Doe", "Cards: Heal", 150, Resources.Load<Sprite>("CharacterArt/PORTRAITS TONED JPGs/Mothership Chars 09")));
        // Add more crew members as needed
    }

    private void RerollCrewMembers()
    {
        for (int i = 0; i < hireSlots.Length; i++)
        {
            int randomIndex = Random.Range(0, availableCrewMembers.Count);
            CrewMember crewMember = availableCrewMembers[randomIndex];
            UpdateHireSlot(hireSlots[i], crewMember);
        }
    }

    private void UpdateHireSlot(Transform slot, CrewMember crewMember)
    {
        Text nameText = slot.Find("NameText")?.GetComponent<Text>();
        Text cardInfoText = slot.Find("CardInfoText")?.GetComponent<Text>();
        Text costText = slot.Find("CostText")?.GetComponent<Text>();
        Image image = slot.Find("CrewImage")?.GetComponent<Image>();
        Button hireButton = slot.Find("HireButton")?.GetComponent<Button>();

        if (nameText == null)
        {
            Debug.LogError("NameText not found in slot: " + slot.name);
        }
        if (cardInfoText == null)
        {
            Debug.LogError("CardInfoText not found in slot: " + slot.name);
        }
        if (costText == null)
        {
            Debug.LogError("CostText not found in slot: " + slot.name);
        }
        if (image == null)
        {
            Debug.LogError("CrewImage not found in slot: " + slot.name);
        }
        if (hireButton == null)
        {
            Debug.LogError("HireButton not found in slot: " + slot.name);
        }

        if (nameText == null || cardInfoText == null || costText == null || image == null || hireButton == null)
        {
            Debug.LogError("One or more UI components are missing in the slot: " + slot.name);
            return;
        }

        nameText.text = crewMember.name;
        cardInfoText.text = crewMember.cardInfo;
        costText.text = "Cost: " + crewMember.cost;
        image.sprite = crewMember.image;

        hireButton.onClick.RemoveAllListeners();
        hireButton.onClick.AddListener(() => HireCrewMember(crewMember));
    }

    private void HireCrewMember(CrewMember crewMember)
    {
        if (PartyManager.Instance.CanHireMore())
        {
            PartyManager.Instance.AddCrewMember(crewMember);
            Debug.Log(crewMember.name + " hired!");
        }
        else
        {
            Debug.Log("Cannot hire more crew members.");
        }
    }
}
