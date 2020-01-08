namespace Alpha.API.Seedwork
{
    public static class ArrayExtensions
    {
        public static void SetAll<T>(this T[] array, T value)
        {
            if (array == null) return;
            for (var i = 0; i < array.Length; ++i)
            {
                array[i] = value;
            }
        }

        public static void SetAll<T>(this T[,] array, T value)
        {
            if (array == null) return;

            for (var y = 0; y < array.GetLength(0); y++)
            {
                for (var x = 0; x < array.GetLength(1); x++)
                {
                    array[y, x] = value;
                }
            }
        }
    }
}