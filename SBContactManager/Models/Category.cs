using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBContactManager.Models
{
    /// <summary>
    /// Custom class to relate one entity to another.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category Property to read and write the Catefory IDs
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// Category property to set and get values using the category IDs.
        /// </summary>
        public string Name { get; set; }
    }
}
