﻿using System.Net;
using System.Text;
using static QuickInfo.HtmlFactory;

namespace QuickInfo
{
    public class UrlDecode : IProcessor
    {
        public string GetResult(Query query)
        {
            if (query.IsHelp)
            {
                return HelpTable(
                    ("3%2B2%2F(2%2B3)", "Decode an url"));
            }

            var input = query.OriginalInput;
            var percent = input.IndexOf('%');
            while (percent != -1)
            {
                if (percent < input.Length - 2 && input[percent + 1].IsHexOrDecimalChar() && input[percent + 2].IsHexOrDecimalChar())
                {
                    return GetResult(input);
                }

                percent = input.IndexOf('%', percent + 1);
            }

            return null;
        }

        private string GetResult(string input)
        {
            var sb = new StringBuilder();
            sb.AppendLine(Div("URL decoded: " + WebUtility.UrlDecode(input)));
            return sb.ToString();
        }
    }
}
