using System;

public class StoryNode
{
    public string History;
    public string[] Answers;
	public int MyIndex;
    public bool IsFinal;
    public StoryNode[] NextNode;
    public Action OnNodeVisited;
}
