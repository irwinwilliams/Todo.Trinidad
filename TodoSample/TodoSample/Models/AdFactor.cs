using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoSample.Models
{
    public class AdFactor
    {
        public string Name { get; set; }
        public double FNF { get; set; }
        public double Leisure { get; set; }
        public double Business { get; set; }
        public double Wedding { get; set; }
        public double Study { get; set; }
        public double Other { get; set; }

        public AdFactor(string name, string csv)
        {
            Name = name;
            try
            {
                string[] vals = csv.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                char[] sep = new char[] { ':' };
                FNF = double.Parse(vals[0].Split(sep, StringSplitOptions.RemoveEmptyEntries)[1]);
                Leisure = double.Parse(vals[1].Split(sep, StringSplitOptions.RemoveEmptyEntries)[1]);
                Business = double.Parse(vals[2].Split(sep, StringSplitOptions.RemoveEmptyEntries)[1]);
                Wedding = double.Parse(vals[3].Split(sep, StringSplitOptions.RemoveEmptyEntries)[1]);
                Study = double.Parse(vals[4].Split(sep, StringSplitOptions.RemoveEmptyEntries)[1]);
                Other = double.Parse(vals[5].Split(sep, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            catch (Exception)
            {

            }
        }
    }
}