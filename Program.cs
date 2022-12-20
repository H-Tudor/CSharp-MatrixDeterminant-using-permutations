using System;

namespace Algebra_PermutationsDeterminant {
	internal class Program {
		static void Main(string[] args) {

			int[,] matrix3_1 = new int[3, 3] {
				{ 6,  1, 1 },
				{ 4, -2, 5 },
				{ 2,  8, 7 }
			};

			int[,] matrix2_1 = new int[2, 2] {
				{ 1, 2 },
				{ 3, 4 }
			};

			Console.WriteLine(new Determinant(matrix2_1).Calculate());
			Console.ReadKey();
		}
	}
}
