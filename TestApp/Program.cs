using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Data;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var tree = new BinaryTree<int>();
			tree.Add(100);
			tree.Add(50);
			tree.Add(25);
			tree.Add(30);
			tree.Add(70);
			tree.Add(65);
			tree.Add(75);

			tree.Add(150);
			tree.Add(125);
			tree.Add(175);

			foreach (var value in tree.TraversalPostOrder())
			{
				Console.Write("{0} ", value);
			}

			//var tree = new BinaryTree<int>();

			//var rand = new Random();
			//for (int i = 0; i < 500; i++)
			//{
			//	tree.Add(rand.Next(1000));
			//}
			
			//var c = tree.Contains(500);
		}
	}
}
