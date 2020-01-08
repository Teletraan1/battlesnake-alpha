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

        public static void SetAll<T>(this T[][] array, T[] value)
        {
            if (array == null) return;

            for (var i = 0; i < array.Length; ++i)
            {
                if (value == null) continue;

                for (var j = 0; j < value.Length; ++j)
                {
                    array[i] = value;
                }
            }
        }
    }
}