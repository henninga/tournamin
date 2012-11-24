using System.Collections.Generic;

namespace Tournamin.web.Models
{
    public class Group
    {
        public string GroupName { get; set; }
        public IList<GroupMatch> Matches { get; set; }

        public IList<Team> Teams { get; set; }

        public Group(string groupName)
        {
            GroupName = groupName;
        }
    }

    public class Team
    {
        public Team(string name)
        {
            Name = name;
        }

        public Team()
        {
            
        }

        public string Name { get; set; }
    }
}