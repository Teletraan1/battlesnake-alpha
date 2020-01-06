namespace Alpha.API.Seedwork
{
    public static class ArrayExtensions
    {
        public static void SetAll<T>(this T[] array, T value)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = value;
            }
        }
    }
}
