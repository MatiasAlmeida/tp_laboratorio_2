using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor que llama a Exception con un mensaje de InnerException.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base(innerException.Message) { }
    }
}
