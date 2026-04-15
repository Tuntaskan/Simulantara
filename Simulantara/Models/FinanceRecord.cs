using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulantara.Models;

public class FinanceRecord
{
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}