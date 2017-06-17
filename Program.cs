using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NHibernateToEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.hbm.xml", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                ProcessFile(file);
            }
        }

        private static void ProcessFile(string file)
        {
            var document = XDocument.Load(file);
            if(document.Root.Name.LocalName != "nhibernate-mapping")
            {
                throw new InvalidOperationException("Can't find NHibernate mapping root element.");
            }

            var classes = document.Root.Elements().Where(x => x.Name.LocalName == "class");
            foreach (var @class in classes)
            {
                ProcessClass(@class);
            }
        }

        private static void ProcessClass(XElement @class)
        {
            var elements = @class.Elements();
            foreach(var element in elements)
            {
                ProcessClassElement(element);
            }
        }

        private static void ProcessClassElement(XElement element)
        {

        }
    }
}
