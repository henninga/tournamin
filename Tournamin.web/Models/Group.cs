using System.Collections.Generic;

namespace Tournamin.web.Models
{
    public class Group
    {
        public string GroupName { get; set; }
        public IList<GroupMatch> Matches { get; set; }

        public Group(string groupName)
        {
            GroupName = groupName;
        }
    }
}