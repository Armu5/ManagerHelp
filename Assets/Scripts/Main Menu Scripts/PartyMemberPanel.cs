using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberPanel : MonoBehaviour
{
    public MemberSlot MemberSLotPrefab;
    public RectTransform SlotsContainer;
    public Button BackBtn;
    public GameObject HiringPanel;

    private void OnEnable()
    {
        UpdateMembersView();

        BackBtn.onClick.RemoveAllListeners();
        BackBtn.onClick.AddListener(delegate
        {
            gameObject.SetActive(false);
            HiringPanel.SetActive(true);
        });
    }

    private void UpdateMembersView()
    {
        foreach(Transform item in SlotsContainer.transform)
        {
            Destroy(item.gameObject);
        }

        var allMember = PartyManager.Instance.GetPartyMembers();

        if(allMember.Count == 0)
            return;

        for(int i = 0; i < allMember.Count; i++)
        {
            var memberSlot = Instantiate(MemberSLotPrefab, SlotsContainer);
            memberSlot.Initialize(allMember[i]);
        }
    }
}
