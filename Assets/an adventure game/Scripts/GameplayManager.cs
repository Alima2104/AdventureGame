using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public Text HistoryText;
    public Transform AnswersParent;
    public GameObject ButtonAnswerPrefab;
	
	[SerializeField] Image Chair;
	[SerializeField] Image Table;
	[SerializeField] Image Plant;
	[SerializeField] Image Bookshelves;
	[SerializeField] Image Boxes;
	[SerializeField] Image Book;
	[SerializeField] Image Drawers;
	[SerializeField] Image Window;
	[SerializeField] Image Key;
	[SerializeField] Image Door;
	

    private StoryNode currentNode;

    private void Start()
    {
        currentNode = StoryFiller.FillStory();
        HistoryText.text = string.Empty;
        FillUi();
		Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
    }

    void FillUi()
    {
        HistoryText.text += "\n\n" + currentNode.History;

        foreach (Transform child in AnswersParent.transform)
        {
            Destroy(child.gameObject);
        }

        var isLeft = true;
        var height = 50.0f;
        var index = 0;
        foreach (var answer in currentNode.Answers)
        {
            var buttonAnswerCopy = Instantiate(ButtonAnswerPrefab, AnswersParent, true);

            var x = buttonAnswerCopy.GetComponent<RectTransform>().rect.x * 1.3f;
            buttonAnswerCopy.GetComponent<RectTransform>().localPosition = new Vector3(isLeft ? x : -x, height, 0);

            if (!isLeft)
                height += buttonAnswerCopy.GetComponent<RectTransform>().rect.y * 3.0f;
            isLeft = !isLeft;

            FillListener(buttonAnswerCopy.GetComponent<Button>(), index);

            buttonAnswerCopy.GetComponentInChildren<Text>().text = answer;

            index++;
        }
    }

    private void FillListener(Button button, int index)
    {
        button.onClick.AddListener(() => { AnswerSelected(index); });
    }

    private void AnswerSelected(int index)
    {
        HistoryText.text += "\n" + currentNode.Answers[index];
		
		if (currentNode.MyIndex == 1){
		   Chair.enabled = true;
		   Plant.enabled = true;
		   Bookshelves.enabled = true;
		   
		   
		Table.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 2){
		   Book.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 3){
		   Book.enabled = true;
		   Plant.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		
		if (currentNode.MyIndex == 4 ){
		   Boxes.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 5){
		   Chair.enabled = true;
		   
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 6){
		   Table.enabled = true;
		   
		   Chair.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 7){
		   Drawers.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 8){
		   Key.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Door.enabled = false;
		}
		
		if (currentNode.MyIndex == 9 ){
		   Window.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 10){
		   Window.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Key.enabled = false;
		Door.enabled = false;
		}
		if (currentNode.MyIndex == 11){
		   Door.enabled = true;
		   
		   Chair.enabled = false;
		Table.enabled = false;
		Plant.enabled = false;
		Bookshelves.enabled = false;
		Boxes.enabled = false;
		Book.enabled = false;
		Drawers.enabled = false;
		Window.enabled = false;
		Key.enabled = false;
		}

        if (!currentNode.IsFinal)
        {
            currentNode = currentNode.NextNode[index];

            currentNode.OnNodeVisited?.Invoke();

            FillUi();
        }
        else
        {
            HistoryText.text += "\n" + "PRESS ESC TO CONTINUE";
        }
    }
}
