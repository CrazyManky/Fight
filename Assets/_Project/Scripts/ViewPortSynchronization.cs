using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class ViewPortSynchronization : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Scrollbar _scrollbarOne;
        [SerializeField] private Scrollbar _scrollbarTwo;


        private void OnEnable()
        {
            _scrollbarOne.onValueChanged.AddListener(value => OnScrollbarChanged(_scrollbarOne, _scrollbarTwo));
            _scrollbarTwo.onValueChanged.AddListener(value => OnScrollbarChanged(_scrollbarTwo, _scrollbarOne));
        }

        private void Awake()
        {
            _scrollbarOne.onValueChanged.AddListener(value => OnScrollbarChanged(_scrollbarOne, _scrollbarTwo));
            _scrollbarTwo.onValueChanged.AddListener(value => OnScrollbarChanged(_scrollbarTwo, _scrollbarOne));
        }

        private void OnScrollbarChanged(Scrollbar source, Scrollbar target)
        {
            target.value = source.value;
            target.size = source.size;
        }


        private void OnDisable()
        {
            _scrollbarOne.onValueChanged.AddListener(value => OnScrollbarChanged(_scrollbarOne, _scrollbarTwo));
            _scrollbarTwo.onValueChanged.AddListener(value => OnScrollbarChanged(_scrollbarTwo, _scrollbarOne));
        }
    }
}