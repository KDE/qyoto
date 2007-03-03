using System;
using System.Collections.Generic;
using Qyoto;

class TreeItem : object {
	
	private List<TreeItem> childItems = new List<TreeItem>();
	private List<QVariant> itemData;
	private TreeItem parentItem;
	
	public TreeItem(List<QVariant> data, TreeItem parent) {
		parentItem = parent;
		itemData = data;
	}
	
	public TreeItem(List<QVariant> data) : this(data, null) {}
	
	public void AppendChild(TreeItem child) {
		childItems.Add(child);
	}
	
	public TreeItem Child(int row) {
		return childItems[row];
	}
	
	public int ChildCount() {
// 		if (childItems != null)
			return childItems.Count;
// 		return 0;
	}
	
	public int ColumnCount() {
// 		if (itemData != null)
			return itemData.Count;
// 		return 0;
	}
	
	public QVariant Data(int column) {
		return itemData[column];
	}
	
	public int Row() {
		if (parentItem != null)
			return parentItem.childItems.IndexOf(this);
		
		return 0;
	}
	
	public TreeItem Parent() {
		return parentItem;
	}
}
