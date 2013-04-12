using GART.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Todo.TnT
{
    public class InterestingPlace: ARItem
    {
    private string description;
 
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
           if (description != value)
        {
           description = value;
           NotifyPropertyChanged(() => Description);
        }
    }
    }
}
}
