using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace JCS02_04;

public class FileOperations
{
    public void readStudentsWriteSecondyear(string xmlPath, string jsonPath)
    {
        XmlDocument studentsDocument = new XmlDocument();
        try
        {
            studentsDocument.Load(xmlPath);

            StreamWriter jsonFile = new StreamWriter(jsonPath);

            XmlNodeList students = studentsDocument.GetElementsByTagName("studentPredmetu");

            jsonFile.WriteLine("[");
            bool isFirst = false, write_p = false;
            foreach (XmlNode node in students)
            {
                StringBuilder str = new StringBuilder();

                if (isFirst) str.Append(",");
                str.Append("{");
                var count = node.ChildNodes.Count;
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "rocnik" && child.InnerText == "2")
                    {
                        write_p = true;
                    }

                    str.Append("\"" + child.Name + "\"" + ": " + "\"" + child.InnerText + "\""); // json format
                    count--;
                    if (count != 0)
                    {
                        str.Append(",");
                    }

                }

                if (write_p)
                {
                    str.Append("}");
                    jsonFile.WriteLine(str.ToString());
                    isFirst = true;
                    write_p = false;
                }
                else
                {
                    str.Clear();
                }
            }

            jsonFile.WriteLine("]");
            jsonFile.Flush();
            jsonFile.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void readCovidWriteAverages(string covidJsonPath, string averagesXmlPath)
    {
        var json = new Covid.Root();
        try
        {
            StreamReader covidFile = new StreamReader(covidJsonPath);
            json = JsonSerializer.Deserialize<Covid.Root>(covidFile.ReadToEnd());
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        Covid.DailyInformations[] dailyInformations = json.data;
        
        // check if there is enough data
        if (dailyInformations.Length < 7)
        {
            Console.WriteLine("No data or file not found or Wrong format");
            return;
        }
        
        double avg = 0;
        
        // first 7 days
        for (int i = 0; i < 7; i++)
        {
            avg += dailyInformations[i].prirustkovy_pocet_nakazenych;
        }

        avg = Math.Round(avg / 7.0, 2);
        
        XmlDocument averagesDocument = new XmlDocument();
        XmlDeclaration xmlDeclaration = averagesDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
        averagesDocument.AppendChild(xmlDeclaration);
        XmlElement root = averagesDocument.CreateElement("Covid");
        averagesDocument.AppendChild(root);
        XmlElement average;
        
        for (int i= 7; i < dailyInformations.Length; i++)
        {
           average = averagesDocument.CreateElement("Average");
           
           average.SetAttribute("from", dailyInformations[i - 7].datum);
           average.SetAttribute("to", dailyInformations[i - 1].datum);
           
           average.InnerText = avg.ToString();

           root.AppendChild(average);
              
           // update avg for next iteration, klouzavy average
           avg -= Math.Round(dailyInformations[i - 7].prirustkovy_pocet_nakazenych / 7.0, 2);
           avg += Math.Round(dailyInformations[i].prirustkovy_pocet_nakazenych / 7.0, 2);
           avg = Math.Round(avg, 2);
        }
        
        average = averagesDocument.CreateElement("Average");
        // last
        average.SetAttribute("from", dailyInformations[dailyInformations.Length - 7].datum);
        average.SetAttribute("to", dailyInformations[dailyInformations.Length - 1].datum);
        // text content
        average.InnerText = avg.ToString();
        
        root.AppendChild(average);

        try
        {
            XmlTextWriter writer = new XmlTextWriter(averagesXmlPath, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            averagesDocument.Save(writer);
            writer.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public void deserializeSubjectsWriteFirstN(string readerPath, string writerPath)
    {
        var predmetyKatedry = new predmetyKatedry();

       try
       {
           FileStream reader = new FileStream(readerPath, FileMode.Open);
           XmlSerializer serializer = new XmlSerializer(typeof(predmetyKatedry));
           predmetyKatedry = (predmetyKatedry) serializer.Deserialize(reader);
           reader.Close();
       }
       catch (Exception e)
       {
            Console.WriteLine(e.Message);
       }
       
       Console.WriteLine("Enter number of subjects to write: ");

    }
}