﻿using Sirenix.OdinInspector;
using UnityEngine;

namespace Silicom.UI
{
    public class UITabMenu : MonoBehaviour
    {

        [SerializeField] private GameObject[] tabs;
        [SerializeField] private bool useDefaultTab;
        [ShowIf(nameof(useDefaultTab)), SerializeField] private int defaultTab;
        [SerializeField] private bool loop;
        [SerializeField] private bool useHeaders;
        [ShowIf(nameof(useHeaders)), SerializeField] private GameObject[] headersSelected;
        [ShowIf(nameof(useHeaders)), SerializeField] private GameObject[] headersUnselected;

        private int _currentIndex = -1;

        private void Awake()
        {
            if(useDefaultTab) SetTab(defaultTab);
        }

        public void NextTab()
        {
            if (!loop && _currentIndex == tabs.Length - 1) return;
            _currentIndex = ++_currentIndex % tabs.Length;
            SetVisibility();
        }

        public void PrevTab()
        {
            if (!loop && _currentIndex == 0) return;
            _currentIndex = (--_currentIndex + tabs.Length) % tabs.Length;
            SetVisibility();
        }

        public void SetTab(int index)
        {
            if (index == _currentIndex) return;
            
            if (index < 0 || index > tabs.Length - 1)
            {
                Debug.LogError($"Request tab is out of bound : {index}");
                return;
            }
            
            _currentIndex = index;
            SetVisibility();
        }

        public void CloseCurrentTab()
        {
            tabs[_currentIndex].SetActive(false);
            if(!useHeaders) return;
            headersSelected[_currentIndex].SetActive(false);
            headersUnselected[_currentIndex].SetActive(true);
        }

        private void SetVisibility()
        {
            for (int i = 0; i < tabs.Length; i++)
            {
                tabs[i].SetActive(i == _currentIndex);
            }
            
            if(!useHeaders) return;
            
            for (int i = 0; i < headersSelected.Length; i++)
            {
                headersSelected[i].SetActive(i == _currentIndex);
            }
            for (int i = 0; i < headersUnselected.Length; i++)
            {
                headersUnselected[i].SetActive(i != _currentIndex);
            }
        }
        
    }
}