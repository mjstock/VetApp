using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VetApp
{
    class FileManager
    {
        private string filePath;
        /// <summary>
        /// Constructor that sets the file path and creates a new file if one does not exist
        /// </summary>
        /// <param name="file">file string based on date provided by application selection</param>
        public FileManager(string file)
        {
            FilePath = file; ;

           if (!File.Exists(FilePath))
            {
                ObservableCollection<Customer> customer = new ObservableCollection<Customer>();
                for (int i = 0; i < 85; i++)
                {
                    customer.Add(new Customer());
                }
                Save(customer);
            }
        }
           
        /// <summary>
        /// Getter Setter of file path. 
        /// </summary>
        public string FilePath
        {
			get { return filePath; }
			set
			{
				string correctFile;
				string folderName = @"..\AppointmentData\";
				if (!Directory.Exists(folderName))
				{
					DirectoryInfo di = Directory.CreateDirectory(folderName);
				}
				int fileLength = value.Length;
				string fileName = value.Insert(fileLength, ".xml");
				correctFile = Path.Combine(folderName, fileName);
				filePath = correctFile;
			}
        }
        
         /// <summary>
         /// Saves collection of customers to xml file
         /// </summary>
         /// <param name="customers"> Observable Collection of Customers</param>
        public void Save(ObservableCollection<Customer> customers)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Customer>));
            using (FileStream writer = new FileStream(FilePath, FileMode.Create,FileAccess.Write))
            {
                serializer.Serialize(writer, customers);
            }
        }
        /// <summary>
        /// Read xml file collection of customers
        /// </summary>
        /// <returns> Observable Collection of Customers</returns>
        public ObservableCollection<Customer> Read()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection< Customer>));
            using (FileStream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
                customers = (ObservableCollection<Customer>)deserializer.Deserialize(stream);
                return customers;
            }
        }
       
       
    }
}
