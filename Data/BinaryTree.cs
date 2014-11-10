using System;
using System.Collections.Generic;

namespace Data
{
	public class BinaryTree<T>
	{
		private readonly IComparer<T> _comparer;

		public BinaryTreeNode<T> Root { get; private set; }
		public int MaxDepth { get; private set; }
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
				MaxDepth = 1;
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
			var currentDepth = 1;

			do
			{
				if (_comparer.Compare(value, currentNode.Value) < 0)
				{
					if (currentNode.LeftNode == null)
					{
						currentNode.LeftNode = new BinaryTreeNode<T>(value);

						if (currentDepth > MaxDepth)
							MaxDepth = currentDepth;

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

						if (currentDepth > MaxDepth)
							MaxDepth = currentDepth;

						return;
					}
					else
					{
						currentNode = currentNode.RightNode;
					}
				}

				currentDepth++;
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

		public bool Delete(T value)
		{
			throw new NotImplementedException();
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
