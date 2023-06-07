using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorPlanilhaIFogSim2.Domain.Service
{
    public class SheetService
    {
        private static CultureInfo AmericanCulture => new("en-US");
        public static void GeranateSheet(string fileName, string text)
        {
            string[] lines = text.Split("\r\n");
            Dictionary<string, double> sheet = new Dictionary<string, double>();

            foreach (string line in lines)
            {
                if (line.Contains(':'))
                {
                    string columnName = line.Split(':')[0].Trim();

                    if (columnName.Contains('_'))
                    {
                        columnName = columnName.Split('_')[0].Trim();
                    }

                    string value = line.Split(':')[1].Trim();

                    if (value.Contains('='))
                    {
                        columnName = $"{columnName}[{value.Split('=')[0].Trim()}]";
                        WriteInDictionary(sheet, columnName, Convert.ToDouble(value.Split('=')[1].Trim(), AmericanCulture));
                    }
                    else
                    {
                        WriteInDictionary(sheet, columnName, Convert.ToDouble(value, AmericanCulture));
                    }


                }
                else if (line.Contains("--->"))
                {
                    string columnName = line.Split("--->")[0].Trim();

                    WriteInDictionary(sheet, columnName, Convert.ToDouble(line.Split("--->")[1], AmericanCulture));
                }
                else if (line.Contains('='))
                {
                    string columnName = line.Split('=')[0].Trim();

                    if (!string.IsNullOrEmpty(columnName))
                    {
                        WriteInDictionary(sheet, columnName, Convert.ToDouble(line.Split('=')[1], AmericanCulture));
                    }
                }
            }

            if(sheet.Count > 0)
            {
                FileService.WriteCSV(fileName, WriteLines(sheet));
            }


        }

        private static bool VerifyColumnName(Dictionary<string, double> sheet, string columnName)
        {
            if (sheet.Count > 0 && sheet.ContainsKey(columnName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void WriteInDictionary(Dictionary<string, double> sheet, string columnName, double newValue)
        {
            if (VerifyColumnName(sheet, columnName))
            {
                sheet[columnName] = (sheet[columnName] + newValue) / 2;
            }
            else
            {
                sheet.Add(columnName, newValue);
            }
        }

        private static string[] WriteLines(Dictionary<string, double> sheet)
        {
            string[] lines = new string[2];

            for (int k = 0; k < sheet.Keys.Count; k++)
            {
                if (k == sheet.Keys.Count - 1)
                {
                    lines[0] = lines[0] + sheet.Keys.ToList()[k];
                }
                else
                {
                    lines[0] = lines[0] + sheet.Keys.ToList()[k] + ";";
                }
            }

            for (int l = 0; l < sheet.Keys.Count; l++)
            {
                if (l == sheet.Values.Count - 1)
                {
                    lines[1] = lines[1] + sheet.Values.ToList()[l].ToString(AmericanCulture);
                }
                else
                {
                    lines[1] = lines[1] + sheet.Values.ToList()[l].ToString(AmericanCulture) + ";";
                }
            }

            return lines;
        }
    }
}
