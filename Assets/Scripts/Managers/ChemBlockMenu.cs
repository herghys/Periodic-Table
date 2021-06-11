using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChemBlockMenu : MonoBehaviour
{
    [SerializeField] ElementType type;
    [SerializeField] Button mButton;
    [SerializeField] Image mImage;
    [SerializeField] bool selected = true;

    private Color baseColor, unselectedColor;

    private void Awake()
    {
        mButton = GetComponent<Button>();
        mImage = GetComponent<Image>();
        baseColor = mImage.color;
        selected = true;
    }

    void Start()
    {
        ColorUtility.TryParseHtmlString("#5C001F", out unselectedColor);
        GameData.IsSelectedElement.Add(type, selected);
        SetButtonEvent();
    }

    private void SelectThis(bool state)
    {
        selected = state;
        int i = GameData.IsSelectedElement.Values.Where(x => x == true).Count();
        if (state)
        {
            mImage.color = baseColor;
            GameData.IsSelectedElement[type] = true;
        }
        else if (i > 1)
        { 
            mImage.color = unselectedColor;
            GameData.IsSelectedElement[type] = false;
        }
        GameData.UpdateUnselectedType?.Invoke();
    }

    private void SetButtonEvent()
    {
        mButton.onClick.AddListener(OnClickEvent);
    }

    private void OnClickEvent()
    {
        SelectThis(!selected);
    }
}
