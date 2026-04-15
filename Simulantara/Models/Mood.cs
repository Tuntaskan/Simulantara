using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulantara.Models;

public class Mood
{
    public string Feeling { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}