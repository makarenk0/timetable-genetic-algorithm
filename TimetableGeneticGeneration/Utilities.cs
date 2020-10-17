using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace TimetableGeneticGeneration
{
    class Utilities
    {
        public enum LessonType { Lecture, Practice };
        public static int ChooseRandomly(int from, int to)
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);

                int n = from + (Math.Abs(BitConverter.ToInt32(rno, 0)) % to);
                return n;
            }
        }

        public static T GetAsObjectJSON<T>(JsonElement element, String property)
        {
            return JsonSerializer.Deserialize<T>(element.GetProperty(property).GetRawText());
        }

        public static Dictionary<String, String> GetAsObjectJSON(JsonElement element, String property, String ofProperties)
        {
            string[] props = GetAsObjectJSON<string[]>(element, ofProperties);
            JsonElement from = element.GetProperty(property);
            var result = new Dictionary<String, String>();

            foreach(var prop in props)
            {
                result[prop] = JsonSerializer.Deserialize<String>(from.GetProperty(prop).GetRawText());
            }

            return result;
        }

    }
}
