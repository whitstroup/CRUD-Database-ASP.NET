using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace InClassAspNet.ViewModels
{
    public class ProductIndexViewModel
    {
        public List<Models.Product> Products { get; set; }
        public int IdForDeletion { get; set; }
    }
}
