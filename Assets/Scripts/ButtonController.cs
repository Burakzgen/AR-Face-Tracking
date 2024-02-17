using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class ButtonController : MonoBehaviour
{
    [SerializeField] ARFaceManager m_ARFaceManager;
    [SerializeField] ARSession m_ARSession;
    [SerializeField] GameObject[] m_Faces;
    [SerializeField] Material[] m_FacesMaterial;
    [SerializeField] Button _prevFace, _nextFace;
    [SerializeField] Image _faceImage;
    [SerializeField] Sprite[] m_FaceSprites;
    int currentID = 0;
    private void Start()
    {
        currentID = 0;
        _prevFace.onClick.AddListener(PreviousFace);
        _nextFace.onClick.AddListener(NextFace);
    }
    void PreviousFace()
    {
        if (currentID == 0)
            currentID = m_FaceSprites.Length;
        currentID--;
        _faceImage.sprite = m_FaceSprites[currentID];
        m_ARSession.enabled = false;
        m_ARFaceManager.facePrefab = m_Faces[currentID];
        m_ARSession.enabled = true;
    }
    void NextFace()
    {
        if (currentID == m_FaceSprites.Length)
            currentID = -1;
        currentID++;
        _faceImage.sprite = m_FaceSprites[currentID];
        m_ARSession.enabled = false;
        m_ARFaceManager.facePrefab = m_Faces[currentID];
        m_ARSession.enabled = true;
    }
    public void ChangeAlphaValues(float value)
    {
        Color albedoColor = m_FacesMaterial[0].color;
        albedoColor.a = value;
        for (int i = 0; i < m_FacesMaterial.Length; i++)
        {
            m_FacesMaterial[i].SetColor("_Color", albedoColor);
        }
    }
}
