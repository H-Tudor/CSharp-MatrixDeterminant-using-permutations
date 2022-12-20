namespace Algebra_PermutationsDeterminant {

	public class Determinant {
		private long determinant;

		private int[,] matrix;
		private int[] permutation;

		private readonly int order;
		private readonly bool validMatrix = false;

		public Determinant(int[,] Matrix) {
			if(Matrix.GetLength(0) == Matrix.GetLength(1)) {
				matrix = Matrix;
				validMatrix = true;
				order = Matrix.GetLength(0);
			} else {
				matrix = new int[1, 1] { { 0 } };
			}
		}

		private int Signature(int[] array) {
			int arrayLength = array.Length;
			int m = 0;

			if(array.Length == 0)
				return 0;

			for(int i = 0; i < arrayLength - 1; i++) {
				for(int j = i + 1; j < arrayLength; j++) {
					if(array[i] > array[j])
						m++;
				}
			}

			if(m % 2 != 0)
				return -1;

			return 1;
		}

		private void AddDeterminantTerm() {
			long p = 1;

			for(int i = 0; i < order; i++) {
				p *= matrix[i, permutation[i]];
			}

			determinant += Signature(permutation) * p;
		}

		private bool Greenlight(int k) {
			int i = 0;

			while(i < k && permutation[i] != permutation[k]) {
				i++;
			}

			if(i < k)
				return false;
			else
				return true;
		}

		private void GeneratePermutation() {
			int k = 0;
			permutation[k] = -1;

			while(k >= 0) {
				if(permutation[k] < order - 1) {
					permutation[k] = permutation[k] + 1;
					if(Greenlight(k)) {
						if(k == order - 1)
							AddDeterminantTerm();
						else {
							k++;
							permutation[k] = -1;
						}
					}
				} else
					k--;
			}
		}

		public long Calculate() {
			if(!validMatrix)
				return 0;

			determinant = 0;
			permutation = new int[order];
			GeneratePermutation();

			return determinant;
		}
	}
}
