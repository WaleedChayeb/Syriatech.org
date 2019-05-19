using System;
using System.Collections.Generic;
using System.Text;

namespace Syriatech.Application.Majors
{
    public class GetMajors
    {
        public GetMajors()
        {
            Seed();
        }
        public List<Majors> resultList = new List<Majors>();
        public void Seed()
        {
            Majors n1 = new Majors
            {
                Id = 1,
                EPluralName = "Developers",
                ESingularName = "Developer",
                APluralName = "مطورين",
                ASingularName = "مطور"
            };
            resultList.Add(n1);

            Majors n2 = new Majors
            {
                Id = 2,
                EPluralName = "Designers",
                ESingularName = "Designer",
                APluralName = "مصممين",
                ASingularName = "مصمم"
            };
            resultList.Add(n2);

            Majors n3 = new Majors
            {
                Id = 3,
                EPluralName = "Digital Marketers",
                ESingularName = "Digital Marketer",
                APluralName = "مسوقين (تسويق إلكتروني)",
                ASingularName = "مسوق (تسويق إلكتروني)"
            };
            resultList.Add(n3);

            Majors n4 = new Majors
            {
                Id = 4,
                EPluralName = "Content Creators",
                ESingularName = "Content Creator",
                APluralName = "صانعي محتوى",
                ASingularName = "صانع محتوى"
            };
            resultList.Add(n4);

        }
         
        public List<Majors> All()
        {
            return resultList;
        }
    }

    public class Majors
    {
        public int Id { get; set; }
        public string EPluralName { get; set; }
        public string ESingularName { get; set; }
        public string APluralName { get; set; }
        public string ASingularName { get; set; }
    }
}
