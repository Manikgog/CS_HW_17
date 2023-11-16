using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CS_HW_17
{
    public class Garden
    {
       

        List<Flower> Flowers { get; set; }

        public Garden()
        {
            Flowers = new List<Flower>();
        }

        public void Add(Flower f)
        {
            Flowers.Add(f);
        }

        public void Remove(Flower f)
        {
            Flowers.Remove(f);
        }

        public int Count()
        {
            return Flowers.Count;
        }

        public Flower this[int index]
        {
            get
            {
                return Flowers[index];
            }

            set
            {
                Flowers[index] = value;
            }
        }

        public void PrintFlowerByHeight(int h)
        {
            var listOfFlowersWithHeightMoreH = Flowers.Where(f => f.Height >= h)
                                                     .Select(f => f).ToList();
            foreach(var f in listOfFlowersWithHeightMoreH)
            {
                Console.WriteLine(f.ToString());
            }
        }

       

        public void SortByHealthLevel()
        {
            Flowers.Sort();
        }

        public void WriteToJsonFile(string path)
        {
            string outputJson = JsonConvert.SerializeObject(Flowers);
            
            
            
            System.IO.File.WriteAllText(path, outputJson);
        }

        public void ReadJsonFile(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            Flowers = JsonConvert.DeserializeObject<List<Flower>>(json);
        }
        
        public void WriteToXMLFile(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Flower>));
            using (FileStream fstream = new FileStream(path, FileMode.Truncate))
            {
                xml.Serialize(fstream, Flowers);
            }
        }

        public void ReadXMLFile(string path)
        {
            
            XDocument xdoc = XDocument.Load(path);
            XElement flowers = xdoc.Element("ArrayOfFlower");
            

            if (flowers != null)
            {

                foreach (XElement element in flowers.Elements("Flower"))
                {

                    string name = element.Element("Name")?.Value;
                    int height = Convert.ToInt32(element.Element("Height")?.Value);
                    int healthLevel = Convert.ToInt32(element.Element("HealthLevel")?.Value);

                    Flowers.Add(new Flower(name, height, healthLevel));

                }

            }
        }

    }
}
