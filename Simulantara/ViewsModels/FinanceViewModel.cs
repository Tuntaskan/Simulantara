using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Simulantara.Models;

namespace Simulantara.ViewsModels;
    public class FinanceViewModel
    {
    public ObservableCollection<FinanceRecord> Records { get; set; } = new ObservableCollection<FinanceRecord>();

    public void AddRecord(string title, int amount, string type)
    {
        Records.Add(new FinanceRecord
        {
            Title = title,
            Amount = amount,
            Type = type
        });
    }
    }

