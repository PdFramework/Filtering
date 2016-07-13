namespace PeinearyDevelopment.Framework.Filtering.Data.Entity
{
  using System.Text;

  internal static class StringBuilderExtensions
    {
        internal static StringBuilder SafeSqlAppend(this StringBuilder stringBuilder, string stringToAppend)
        {
            if (stringBuilder.Length > 0)
            {
                stringBuilder.Append(" ");
            }

            stringBuilder.Append(stringToAppend);

            return stringBuilder;
        }

        internal static StringBuilder SafeSqlAppend(this StringBuilder stringBuilder, StringBuilder stringBuilderToAppend)
        {
            if (stringBuilder.Length > 0)
            {
                stringBuilder.Append(" ");
            }

            stringBuilder.Append(stringBuilderToAppend);

            return stringBuilder;
        }
    }
}
