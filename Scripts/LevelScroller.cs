using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelScroller : MonoBehaviour
{
    public ScrollRect scrollRect; // Присвойте этот объект через инспектор
    public RectTransform contentPanel; // Панель, содержащая кнопки уровней
    public Button[] levelButtons; // Массив всех кнопок уровней
    public float scrollSpeed = 10f; // Скорость прокрутки
    private float lastScrollPosition = 0f; // Переменная для сохранения последней позиции скролла

    private void Start()
    {
        // Восстанавливаем последнюю позицию скролла при старте
        scrollRect.verticalNormalizedPosition = PlayerPrefs.GetFloat("LastScrollPosition", 1f);
    }

    public void ScrollToLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelButtons.Length)
            return;

        float targetPosition = levelButtons[levelIndex].GetComponent<RectTransform>().anchoredPosition.y;
        StartCoroutine(SmoothScrollTo(targetPosition / contentPanel.sizeDelta.y));
    }

    private IEnumerator SmoothScrollTo(float targetPositionY)
    {
        while (Mathf.Abs(scrollRect.verticalNormalizedPosition - targetPositionY) > 0.001f)
        {
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, targetPositionY, Time.deltaTime * scrollSpeed);
            yield return new WaitForEndOfFrame();
        }
        lastScrollPosition = scrollRect.verticalNormalizedPosition;
        SaveScrollPosition();
    }

    private void SaveScrollPosition()
    {
        // Сохраняем последнюю позицию скролла
        PlayerPrefs.SetFloat("LastScrollPosition", lastScrollPosition);
        PlayerPrefs.Save();
    }
}
