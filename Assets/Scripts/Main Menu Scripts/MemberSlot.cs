using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemberSlot : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI CardInfoText;
    public Image CardImage;
    public Button FireButton;

    CrewMember _member;

    public void Initialize(CrewMember member)
    {
        _member = member;
        NameText.text = member.name;
        CardInfoText.text = member.cardInfo;
        CardImage.sprite = member.image;

        FireButton.onClick.RemoveAllListeners();
        FireButton.onClick.AddListener(delegate
        {
            PartyManager.Instance.RemoveCrewMember(_member);
            Destroy(gameObject);
        });
    }
}
