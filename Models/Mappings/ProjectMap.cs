using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class ProjectMap : SubclassMap<Project>
    {
        public ProjectMap() {
            Table("Projects");
            KeyColumn("Id");
        }
    }
}
