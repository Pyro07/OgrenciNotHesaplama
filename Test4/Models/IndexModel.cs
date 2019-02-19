using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test4.Models;

namespace Test4.Models
{
    public class IndexModel
    {
        public List<Ogrenci> _Ogrenciler { get; set; }
        public List<Ders> _Dersler { get; set; }
    }
}