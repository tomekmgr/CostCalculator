using CostCalc.DataClass;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CostCalc.DataHandlers
{
    public class MaterialHandler
    {
        private static string MaterialProjectFile = "material.cc";

        public MaterialHandler()
        {
            this.Materials = new List<Material>();
        }

        [XmlIgnore]
        public string FilePath { get; private set; }

        public List<Material> Materials { get; set; }

        public static MaterialHandler Initialize(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string filePath = Path.Combine(directory, MaterialHandler.MaterialProjectFile);
            if (File.Exists(filePath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(MaterialHandler));
                using (FileStream fs = File.OpenRead(filePath))
                {
                    MaterialHandler handler = (MaterialHandler)ser.Deserialize(fs);
                    handler.FilePath = directory;

                    return handler;
                }
            }

            return new MaterialHandler() { FilePath = directory};
        }

        public void Save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(MaterialHandler));
            using (FileStream fs = File.OpenWrite(Path.Combine(this.FilePath, MaterialProjectFile)))
            {
                ser.Serialize(fs, this);
            }
        }

        public uint GetNextMaterialId()
        {
            if (this.Materials.Count == 0)
            {
                return 1;
            }

            return this.Materials.Max(item => item.Id);
        }
    }
}
