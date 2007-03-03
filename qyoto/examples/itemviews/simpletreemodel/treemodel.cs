/****************************************************************************
**
** Copyright (C) 2005-2006 Trolltech ASA. All rights reserved.
**
** This file is part of the example classes of the Qt Toolkit.
**
** This file may be used under the terms of the GNU General Public
** License version 2.0 as published by the Free Software Foundation
** and appearing in the file LICENSE.GPL included in the packaging of
** this file.  Please review the following information to ensure GNU
** General Public Licensing requirements will be met:
** http://www.trolltech.com/products/qt/opensource.html
**
** If you are unsure which license is appropriate for your use, please
** review the following information:
** http://www.trolltech.com/products/qt/licensing.html or contact the
** sales department at sales@trolltech.com.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
****************************************************************************/

using System;
using System.Collections.Generic;
using Qyoto;

class TreeModel : QAbstractItemModel {
	
	private TreeItem rootItem;
	
	public TreeModel(string data, QObject parent) : base(parent) {
		List<QVariant> rootData = new List<QVariant>();
		rootData.Add(new QVariant("Title"));
		rootData.Add(new QVariant("Summary"));
		rootItem = new TreeItem(rootData);
		SetupModelData(new List<string>(data.Split("\n".ToCharArray())), rootItem);
	}
	
	public TreeModel(string data) : this(data, null) {}
	
	public override QVariant Data(QModelIndex index, int role) {
		if (!index.IsValid())
			return new QVariant();
		
		if (role != (int) Qt.ItemDataRole.DisplayRole)
			return new QVariant();
		
		TreeItem item = (TreeItem) index.InternalPointer();
		
		return item.Data(index.Column());
	}
	
	public override int Flags(QModelIndex index) {
		if (!index.IsValid())
			return (int) Qt.ItemFlag.ItemIsEnabled;
		
		return (int) (Qt.ItemFlag.ItemIsEnabled | Qt.ItemFlag.ItemIsSelectable);
	}
	
	public override QVariant HeaderData(int section, Qt.Orientation orientation, int role) {
		if (orientation == Qt.Orientation.Horizontal && role == (int) Qt.ItemDataRole.DisplayRole)
			return rootItem.Data(section);
		
		return new QVariant();
	}
	
	public override QVariant HeaderData(int section, Qt.Orientation orientation) {
		return HeaderData(section, orientation, (int) Qt.ItemDataRole.DisplayRole);
	}
	
	public override QModelIndex Index(int row, int column, QModelIndex parent) {
		TreeItem parentItem;
		
		if (!parent.IsValid()) {
			parentItem = rootItem;
		} else {
			parentItem = (TreeItem) parent.InternalPointer();
		}
		
		TreeItem childItem = parentItem.Child(row);
		if (childItem != null)
			return CreateIndex(row, column, childItem);
		else
			return new QModelIndex();
	}
	
	public override QModelIndex Index(int row, int column) {
		return Index(row, column, new QModelIndex());
	}
	
	public override QModelIndex Parent(QModelIndex index) {
		if (!index.IsValid())
			return new QModelIndex();
		
		TreeItem childItem = (TreeItem) index.InternalPointer();
		TreeItem parentItem = childItem.Parent();
		
		if (parentItem == rootItem)
			return new QModelIndex();
		
		return CreateIndex(parentItem.Row(), 0, parentItem);
	}
	
	public override int RowCount(QModelIndex parent) {
		TreeItem parentItem;
		
		if (!parent.IsValid()) {
			parentItem = rootItem;
		} else {
			parentItem = (TreeItem) parent.InternalPointer();
		}
		
		return parentItem.ChildCount();
	}
	
	public override int RowCount() {
		return RowCount(new QModelIndex());
	}
	
	public override int ColumnCount(QModelIndex parent) {
		if (parent.IsValid()) {
			return ((TreeItem) parent.InternalPointer()).ColumnCount();
		} else {
			return rootItem.ColumnCount();
		}
	}
	
	public override int ColumnCount() {
		return ColumnCount(new QModelIndex());
	}
	
	private void SetupModelData(List<string> lines, TreeItem parent) {
		List<TreeItem> parents = new List<TreeItem>();
		List<int> indentations = new List<int>();
		parents.Add(parent);
		indentations.Add(0);
		
		int number = 0;
		
		while (number < lines.Count) {
			int position = 0;
			while (position < lines[number].Length) {
				if (lines[number].Substring(position, 1) != " ")
					break;
				position++;
			}
		
			string lineData = lines[number].Substring(position).Trim();
		
			if (lineData != "") {
				// Read the column data from the rest of the line.
				List<string> columnStrings = new List<string>(lineData.Split("\t".ToCharArray()));
				List<QVariant> columnData = new List<QVariant>();
				
				for (int column = 0; column < columnStrings.Count; ++column)
					columnData.Add(new QVariant(columnStrings[column]));
			
				if (position > indentations[indentations.Count - 1]) {
					// The last child of the current parent is now the new parent
					// unless the current parent has no children.
			
					if (parents[parents.Count - 1].ChildCount() > 0) {
						parents.Add(parents[parents.Count - 1].Child(parents[parents.Count - 1].ChildCount() - 1));
						indentations.Add(position);
					}
				} else {
					while (position < LastItem<int>(indentations) && parents.Count > 0) {
						parents.RemoveAt(parents.Count - 1);
						indentations.RemoveAt(indentations.Count - 1);
					}
				}
			
				// Append a new item to the current parent's list of children.
				LastItem<TreeItem>(parents).AppendChild(new TreeItem(columnData, LastItem<TreeItem>(parents)));
			}
			
			number++;
		}
	}
	
	private T LastItem<T>(List<T> list) {
		if (list.Count == 0)
			return default(T);
		return list[list.Count - 1];
	}
}
