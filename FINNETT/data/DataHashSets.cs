using System.Collections.Generic;

namespace FINNETT.data
{
    public class DataHashSets
    {
        public static HashSet<string> accessRights = new HashSet<string>();

        public static void SaveRights(string rightName)
        {
            accessRights.Add(rightName);
        }

        public static void CheckRights(string rightName)
        {
        }
    }
}