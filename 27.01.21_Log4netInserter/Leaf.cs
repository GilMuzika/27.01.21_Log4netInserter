using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._01._21_Log4netInserter
{
    /// <summary>
    /// leaf class
    /// </summary>
    public class Leaf : Component
    {
        private string _exceptionMessage;

        public Leaf(string file)
        {
            FileOrDirectory = file;
            LengthOfFileOrDirectory = GetSize();
        }

        public override void AddChild(Component c)
        {
            throw new NotSupportedException("Leaf element cannot add child!");
        }

        public override IList<Component> GetChildren()
        {
            return null;
        }

        public override void RemoveChild(Component c)
        {
            throw new NotSupportedException("Leaf element cannot remove child!");
        }

        public async override Task<List<string>> AllChildrenToString(string space)
        {            
            return await Task.Run(() => { return new List<string> { FileOrDirectory }; }); 
        }

        public override long GetSize()
        {
            try
            {
                return new System.IO.FileInfo(FileOrDirectory).Length;
            }
            catch(Exception ex)
            {
                _exceptionMessage = ex.Message;
                return 0;
            }
        }
    }
}
