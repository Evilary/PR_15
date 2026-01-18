using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Чернышков.Interfaces
{
    internal interface IDocument
    {

        void save(bool Update =  false);
        List<Documents.Classes.DocumentContext> AllDocuments();

        void Delete();
    }
}
