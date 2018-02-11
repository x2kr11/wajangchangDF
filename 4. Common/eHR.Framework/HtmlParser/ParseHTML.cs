using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Net;

namespace eHR.Framework.HtmlParser
{
    /// <summary>
    /// Summary description for ParseHTML.
    /// </summary>

    public class ParseHTML : Parse
    {
        public AttributeList GetTag()
        {
            AttributeList tag = new AttributeList();
            tag.Name = m_tag;

            foreach (Attribute x in List)
            {
                tag.Add((Attribute)x.Clone());
            }

            return tag;
        }

        public String BuildTag()
        {
            String buffer = "<";
            buffer += m_tag;
            int i = 0;
            while (this[i] != null)
            {// has attributes
                buffer += " ";
                if (this[i].Value == null)
                {
                    if (this[i].Delim != 0)
                        buffer += this[i].Delim;
                    buffer += this[i].Name;
                    if (this[i].Delim != 0)
                        buffer += this[i].Delim;
                }
                else
                {
                    buffer += this[i].Name;
                    if (this[i].Value != null)
                    {
                        buffer += "=";
                        if (this[i].Delim != 0)
                            buffer += this[i].Delim;
                        buffer += this[i].Value;
                        if (this[i].Delim != 0)
                            buffer += this[i].Delim;
                    }
                }
                i++;
            }
            buffer += ">";
            return buffer;
        }

        protected void ParseTag()
        {
            m_tag = "";
            Clear();

            // Is it a comment?
            if ((GetCurrentChar() == '!') &&
              (GetCurrentChar(1) == '-') &&
              (GetCurrentChar(2) == '-'))
            {
                while (!Eof())
                {
                    if ((GetCurrentChar() == '-') &&
                      (GetCurrentChar(1) == '-') &&
                      (GetCurrentChar(2) == '>'))
                        break;
                    if (GetCurrentChar() != '\r')
                        m_tag += GetCurrentChar();
                    Advance();
                }
                m_tag += "--";
                Advance();
                Advance();
                Advance();
                ParseDelim = (char)0;
                return;
            }

            // Find the tag name
            while (!Eof())
            {
                if (IsWhiteSpace(GetCurrentChar()) ||
                                 (GetCurrentChar() == '>'))
                    break;
                m_tag += GetCurrentChar();
                Advance();
            }

            EatWhiteSpace();

            // Get the attributes
            while (GetCurrentChar() != '>')
            {
                ParseName = "";
                ParseValue = "";
                ParseDelim = (char)0;

                ParseAttributeName();

                if (GetCurrentChar() == '>')
                {
                    AddAttribute();
                    break;
                }

                // Get the value(if any)
                ParseAttributeValue();
                AddAttribute();
            }
            Advance();
        }


        public char Parse()
        {
            if (GetCurrentChar() == '<')
            {
                Advance();

                char ch = char.ToUpper(GetCurrentChar());
                if ((ch >= 'A') && (ch <= 'Z') || (ch == '!') || (ch == '/'))
                {
                    ParseTag();
                    return (char)0;
                }

                else return (AdvanceCurrentChar());
            }
            else return (AdvanceCurrentChar());
        }

        public string GetHTMLByLocalFile(string fullName)
        {
            string buffer = string.Empty;
            string line = string.Empty;
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(fullName);

                while ((line = reader.ReadLine()) != null)
                {
                    buffer += line + "\r\n";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return buffer;
        }

        public string GetHTMLByURL(string url)
        {
            WebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                HttpWebRequest request =
                               (HttpWebRequest)WebRequest.Create(url);

                response = request.GetResponse();
                stream = response.GetResponseStream();

                if (!response.ContentType.ToLower().StartsWith("text/"))
                    return null;

                string buffer = "", line;

                reader = new StreamReader(stream);

                while ((line = reader.ReadLine()) != null)
                {
                    buffer += line + "\r\n";
                }

                return buffer;
            }
            catch (WebException e)
            {
                System.Console.WriteLine("Can't download:" + e);
                return null;
            }
            catch (IOException e)
            {
                System.Console.WriteLine("Can't download:" + e);
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (stream != null)
                    stream.Close();

                if (response != null)
                    response.Close();
            }
        }

        /// <summary>
        /// 요청한 HTML 태그의 속성값을 반환 합니다.
        /// </summary>
        /// <param name="tagName">HTML 태그 이름 입니다.</param>
        /// <param name="propertyName">태그의 속성 이름 입니다.</param>
        /// <returns>반환되는 DataTable컬럼에는 Value 컬럼과 ValueStartIndex 컬럼을 포함 합니다. <br/>
        /// Value : 요청한 Tag 속성의 Value값을 가지고 있습니다. <br />
        /// ValueStartIndex : HTML 문자열에서 Value값이 시작하는 Start Index 값을 가기고 있습니다.</returns>
        /// <example>
        /// 다음 예제는 요청한 html 문자열의 img 태그의 src 속성 값을 반환 합니다.
        /// <code>
        /// string url = @"d:\test.htm";
        /// KANT.Framework.Common.HTMLParser.ParseHTML parse = new KANT.Framework.Common.HTMLParser.ParseHTML();
        /// string htmlSource = KANT.Framework.Common.IO.ReadTextFileToString(url);
        /// parse.Source = htmlSource;
        /// DataTable dt = parse.GetPropertyValueByTagName("Img", "src");
        /// </code>
        /// </example>
        public DataTable GetPropertyValueByTagName(string tagName, string propertyName)
        {
            this.m_idx = 0;
            this.ParseDelim = '\0';
            this.ParseName = null;
            this.ParseValue = null;
            this.Value = "";

            DataTable dtPropValue = eHR.Framework.Common.Helper.CreateDataTable(new string[] { "Value", "ValueStartIndex" });
            while (!this.Eof())
            {
                char ch = this.Parse();
                if (ch == 0)
                {
                    AttributeList tag = this.GetTag();
                    if (tag[propertyName] != null)
                    {
                        if (tag.Name.ToLower() == tagName.ToLower())
                        {
                            DataRow dr = dtPropValue.NewRow();
                            dr["Value"] = tag[propertyName].Value;
                            dr["ValueStartIndex"] = tag[propertyName].ValueIndex;

                            dtPropValue.Rows.Add(dr);

                            //System.Diagnostics.Debug.WriteLine(tag.Name + " : " +
                            //                           tag[propertyName].Value);
                        }
                    }
                }
            }
            return dtPropValue;
        }

        /// <summary>
        /// 요청한 HTML 태그의 속성값을 반환 합니다.
        /// </summary>
        /// <param name="htmlSource">HTML 문자열 입니다.</param>
        /// <param name="tagName">HTML 태그 이름 입니다.</param>
        /// <param name="propertyName">태그의 속성 이름 입니다.</param>
        /// <returns></returns>
        /// <example>
        /// 다음 예제는 요청한 html 문자열의 img 태그의 src 속성 값을 반환 합니다.
        /// <code>
        /// string url = @"d:\test.htm";
        /// KANT.Framework.Common.HTMLParser.ParseHTML parse = new KANT.Framework.Common.HTMLParser.ParseHTML();
        /// string htmlSource = KANT.Framework.Common.IO.ReadTextFileToString(url);
        /// DataTable dt = parse.GetPropertyValueByTagName(htmlSource, "Img", "src");
        /// </code>
        /// </example>
        public DataTable GetPropertyValueByTagName(string htmlSource, string tagName, string propertyName)
        {
            this.Source = htmlSource;

            return this.GetPropertyValueByTagName(tagName, propertyName);
        }
    }

}
