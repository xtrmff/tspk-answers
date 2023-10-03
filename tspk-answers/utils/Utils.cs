using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace tspk_answers.utils
{
    public static class Utils
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        public static string DecodeUnicodeEscape(string input)
        {
            string decodedString = string.Empty;

            int currentIndex = 0;
            while (currentIndex < input.Length)
            {
                if (input[currentIndex] == '\\' && currentIndex < input.Length - 1 && input[currentIndex + 1] == 'u')
                {
                    // Found a Unicode escape sequence
                    int startIndex = currentIndex;
                    int endIndex = Math.Min(startIndex + 6, input.Length); // Assume Unicode escapes have fixed format \uXXXX
                    string unicodeEscape = input.Substring(startIndex, endIndex - startIndex);

                    // Decode Unicode escape sequence
                    string decodedEscape = DecodeSingleUnicodeEscape(unicodeEscape);
                    decodedString += decodedEscape;

                    currentIndex = endIndex;
                }
                else
                {
                    // Normal text, copy as is
                    decodedString += input[currentIndex];
                    currentIndex++;
                }
            }

            return decodedString;
        }

        
        private static string DecodeSingleUnicodeEscape(string unicodeEscape)
        {
            string[] escapeSegments = unicodeEscape.Split('\\', 'u');

            string decodedEscape = string.Empty;
            foreach (string segment in escapeSegments)
            {
                if (!string.IsNullOrEmpty(segment))
                {
                    int codePoint = int.Parse(segment, System.Globalization.NumberStyles.HexNumber);
                    decodedEscape += char.ConvertFromUtf32(codePoint);
                }
            }

            return decodedEscape;
        }

        public static string ConvertToPlainText(string html)
        {

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            StringWriter sw = new StringWriter();
            ConvertTo(doc.DocumentNode, sw);
            sw.Flush();
            return sw.ToString();
        }

        private static void ConvertContentTo(HtmlNode node, TextWriter outText)
        {
            foreach (HtmlNode subnode in node.ChildNodes)
            {
                ConvertTo(subnode, outText);
            }
        }

        private static void ConvertTo(HtmlNode node, TextWriter outText)
        {
            string html;
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:
                    // don't output comments
                    break;

                case HtmlNodeType.Document:
                    ConvertContentTo(node, outText);
                    break;

                case HtmlNodeType.Text:
                    // script and style must not be output
                    string parentName = node.ParentNode.Name;
                    if ((parentName == "script") || (parentName == "style"))
                        break;

                    // get text
                    html = ((HtmlTextNode)node).Text;

                    // is it in fact a special closing node output as text?
                    if (HtmlNode.IsOverlappedClosingElement(html))
                        break;

                    // check the text is meaningful and not a bunch of whitespaces
                    if (html.Trim().Length > 0)
                    {
                        outText.Write(HtmlEntity.DeEntitize(html));
                    }
                    break;

                case HtmlNodeType.Element:
                    switch (node.Name)
                    {
                        case "p":
                            // treat paragraphs as crlf
                            outText.Write("\r\n");
                            break;
                        case "br":
                            outText.Write("\r\n");
                            break;
                    }

                    if (node.HasChildNodes)
                    {
                        ConvertContentTo(node, outText);
                    }
                    break;
            }
        }
    }
}
