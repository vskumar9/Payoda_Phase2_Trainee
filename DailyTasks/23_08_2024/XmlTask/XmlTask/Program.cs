using System.Xml;

namespace XmlTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Course[] courses = new Course[3];
            courses[0] = new Course(11, "DotNetCore", 3);
            courses[1] = new Course(12, "Angular", 1);
            courses[2] = new Course(13, "Data Analytics", 2);
            using (XmlWriter writer = XmlWriter.Create("Courses.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Courses");
                foreach (Course course in courses)
                {
                    writer.WriteStartElement("Course");
                    writer.WriteElementString("CourseID", course.Cid.ToString());
                    writer.WriteElementString("CourseName", course.Cname.ToString());
                    writer.WriteElementString("DurationInMonths", course.Cduration.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }
    }

}