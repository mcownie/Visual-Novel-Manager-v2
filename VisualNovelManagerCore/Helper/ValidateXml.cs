using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace VisualNovelManagerCore.Helper
{
    internal class ValidateXml
    {
        internal static bool IsValidXml(string input)
        {
            XmlReaderSettings settings = new XmlReaderSettings
            {
                CheckCharacters = true,
                ConformanceLevel = ConformanceLevel.Document,
                DtdProcessing = DtdProcessing.Ignore,
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
                IgnoreWhitespace = true,
                ValidationFlags = XmlSchemaValidationFlags.None,
                ValidationType = ValidationType.None,
            };

            using (XmlReader xmlReader = XmlReader.Create(input, settings))
            {
                try
                {
                    while (xmlReader.Read()) {} // Reader intentionally left empty
                    return true;
                }
                catch (XmlException)
                {
                    return false;
                }
            }
        }
    }
}
