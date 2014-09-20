using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS.Interfaces
{
    /// <summary>
    /// This interface holds all relevant information about an endpoint
    /// </summary>
    public interface IEndpoint
    {
        /// <summary>
        /// User friendly name of the endpoint
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Connection string to the endpoint
        /// </summary>
        string ConnectionString { get; set; }
    }
}
