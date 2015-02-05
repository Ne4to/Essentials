using System;
using System.Collections.Generic;

namespace Data
{
	public class BinaryTree<T>
	{
		private readonly IComparer<T> _comparer;

		public BinaryTreeNode<T> Root { get; private set; }
		public int Count { get; private set; }

		public BinaryTree()
			: this(Comparer<T>.Default)
		{
		}

		public BinaryTree(IComparer<T> comparer)
		{
			_comparer = comparer;
		}

		public void Add(T value)
		{
			if (Root == null)
			{
				Root = new BinaryTreeNode<T>(value);
			}
			else
			{
				AddTo(Root, value);
			}

			Count++;
		}

		private void AddTo(BinaryTreeNode<T> root, T value)
		{
			var currentNode = root;

			do
			{
				if (_comparer.Compare(value, currentNode.Value) < 0)
				{
					if (currentNode.LeftNode == null)
					{
						currentNode.LeftNode = new BinaryTreeNode<T>(value);

						return;
					}
					else
					{
						currentNode = currentNode.LeftNode;
					}
				}
				else
				{
					if (currentNode.RightNode == null)
					{
						currentNode.RightNode = new BinaryTreeNode<T>(value);

						return;
					}
					else
					{
						currentNode = currentNode.RightNode;
					}
				}
			} while (true);
		}

		public bool Contains(T value)
		{
			var currentNode = Root;

			while (currentNode != null)
			{
				var compareVal = _comparer.Compare(value, currentNode.Value);
				if (compareVal == 0)
					return true;

				currentNode = compareVal < 0 ? currentNode.LeftNode : currentNode.RightNode;
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <remarks>
		/// Case 1: If the node being deleted has no right child, then the node's left child can be used as the replacement. 
		/// The binary search tree property is maintained because we know that the deleted node's left subtree itself maintains the binary search tree property, 
		/// and that the values in the left subtree are all less than or all greater than the deleted node's parent, 
		/// depending on whether the deleted node is a left or right child. 
		/// Therefore, replacing the deleted node with its left subtree will maintain the binary search tree property.
		/// 
		/// Case 2: If the deleted node's right child has no left child, then the deleted node's right child can replace the deleted node. 
		/// The binary search tree property is maintained because the deleted node's right child is greater than all nodes in the deleted node's left subtree and is either greater than or less than the deleted node's parent, 
		/// depending on whether the deleted node was a right or left child. Therefore, replacing the deleted node with its right child will maintain the binary search tree property.
		/// 
		/// Case 3: Finally, if the deleted node's right child does have a left child, then the deleted node needs to be replaced by the deleted node's right child's left-most descendant. 
		/// That is, we replace the deleted node with the deleted node's right subtree's smallest value.
		/// </remarks>
		/// <returns></returns>
		public bool Delete(T value)
		{
			BinaryTreeNode<T> currentNodeParent = null;
			var currentNode = Root;
			bool found = false;
			
			while (currentNode != null)
			{
				var compareVal = _comparer.Compare(value, currentNode.Value);
				if (compareVal == 0)
				{
					found = true;
					break;
				}

				currentNodeParent = currentNode;
				currentNode = compareVal < 0 ? currentNode.LeftNode : currentNode.RightNode;
			}

			if (!found)
				return false;

			// Case 1
			if (currentNode.RightNode == null)
			{
				// TODO 
				if (currentNodeParent == null)
				{
					Root = currentNode.LeftNode;
				}
				else
				{
					currentNodeParent.LeftNode = currentNode.LeftNode;					
				}
				
				return true;
			}

			// Case 2
			if (currentNode.RightNode.LeftNode == null)
			{
				// TODO 
				if (currentNodeParent == null)
				{
					Root = currentNode.RightNode;
				}
				else
				{
					currentNodeParent.RightNode = currentNode.RightNode;	
				}
			}

			return true;
		}

		/// <summary>
		/// Current -> Left -> Right
		/// </summary>
		/// <returns></returns>
		public IEnumerable<T> TraversalPreOrder()
		{
			if (Root == null)
				yield break;

			var current = Root;
			var nextNodes = new Stack<BinaryTreeNode<T>>();

			while (current != null)
			{
				yield return current.Value;

				if (current.RightNode != null)
				{
					nextNodes.Push(current.RightNode);
				}

				if (current.LeftNode != null)
				{
					current = current.LeftNode;
				}
				else
				{
					if (nextNodes.Count != 0)
					{
						current = nextNodes.Pop();
					}
					else
					{
						yield break;
					}
				}
			}
		}

		/// <summary>
		/// Left -> Current -> Right
		/// </summary>
		/// <returns></returns>
		public IEnumerable<T> TraversalInOrder()
		{
			if (Root == null)
				yield break;

			var current = Root;
			var nextNodes = new Stack<BinaryTreeNode<T>>();
			bool isReturn = false;

			while (current != null)
			{
				if (isReturn)
				{
					isReturn = false;
					yield return current.Value;

					if (current.RightNode != null)
					{
						current = current.RightNode;
						continue;
					}
				}

				if (current.LeftNode == null)
				{
					yield return current.Value;

					if (current.RightNode != null)
					{
						current = current.RightNode;
					}
					else
					{
						if (nextNodes.Count != 0)
						{
							current = nextNodes.Pop();
							isReturn = true;
						}
						else
						{
							yield break;
						}
					}
				}
				else
				{
					nextNodes.Push(current);
					current = current.LeftNode;
				}
			}
		}

		/// <summary>
		/// Left -> Right -> Current
		/// </summary>
		/// <returns></returns>
		public IEnumerable<T> TraversalPostOrder()
		{
			if (Root == null)
				yield break;

			BinaryTreeNode<T> current = Root;
			BinaryTreeNode<T> lastVisited = null;
			var stack = new Stack<BinaryTreeNode<T>>();

			while (current != null)
			{
				if (lastVisited != null && current.LeftNode == lastVisited)
				{
					stack.Push(current);
					current = current.RightNode;
					continue;
				}

				if (lastVisited != null && current.RightNode == lastVisited)
				{
					yield return current.Value;

					if (stack.Count == 0)
					{
						yield break;
					}

					lastVisited = current;
					current = stack.Pop();
					continue;
				}

				if (current.LeftNode != null)
				{
					stack.Push(current);
					current = current.LeftNode;
				}
				else
				{
					if (current.RightNode != null)
					{
						stack.Push(current);
						current = current.RightNode;
					}
					else
					{
						yield return current.Value;

						if (stack.Count == 0)
						{
							yield break;
						}

						lastVisited = current;
						current = stack.Pop();
					}
				}

			}
		}

		public IEnumerable<T> BreadthFirstTraversal()
		{
			throw new NotImplementedException();
			yield break;
		}
	}

	public class BinaryTreeNode<T>
	{
		public T Value { get; set; }
		public BinaryTreeNode<T> LeftNode { get; set; }
		public BinaryTreeNode<T> RightNode { get; set; }

		public BinaryTreeNode()
		{
		}

		public BinaryTreeNode(T value)
		{
			Value = value;
		}
	}
}
