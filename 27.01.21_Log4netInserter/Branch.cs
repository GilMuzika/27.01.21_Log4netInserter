using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._01._21_Log4netInserter
{
    /// <summary>
    /// Composite class
    /// </summary>
    public class Branch : Component
    {
        public FilterByExtensionHelper IsFilterByExpension { get; set; }
        private string _theExtension;

        //public event EventHandler<string> addPathEvent;

        public Branch(string directory)
        {
            FileOrDirectory = directory;            
        }

        private IList<Component> _children = new List<Component>();

        public override void AddChild(Component c)
        {
            _children.Add(c);
        }

        public override IList<Component> GetChildren()
        {
            return _children;
        }

        public override void RemoveChild(Component c)
        {
            _children.Remove(c);
        }

        public async override Task<List<string>> AllChildrenToString(string space)
        {
            _theExtension = this.IsFilterByExpension.TheExtension.Substring(this.IsFilterByExpension.TheExtension.IndexOf('.'), this.IsFilterByExpension.TheExtension.Length - this.IsFilterByExpension.TheExtension.IndexOf('.'));
            space += "";
            return await Task.Run(async() => 
            {

                List<string> toReturn = new List<string>();
                string tmpStr = string.Empty;
                
                foreach (Component s in _children)
                {
                    List<string> strLst = await s.AllChildrenToString(space);
                    foreach(string ss in strLst)
                    {
                        if (!string.IsNullOrWhiteSpace(ss) && !string.IsNullOrEmpty(ss) && ss != Environment.NewLine && ss != "\n" && ss != "\r")
                        {
                            if (this.IsFilterByExpension.IsToFilter == false)
                            {
                                toReturn.Add(ss);
                            }
                            else
                            {                                
                                if(ss.Contains(_theExtension))
                                    toReturn.Add(ss);
                            }
                            //addPathEvent?.Invoke(this, ss);
                        }
                    }
                }

                if(this.IsFilterByExpension.IsToFilter == false)
                    toReturn.Add(FileOrDirectory);
                else
                {
                    if (FileOrDirectory.Contains(_theExtension))
                        toReturn.Add(FileOrDirectory);
                }
                //addPathEvent?.Invoke(this, FileOrDirectory);

                return toReturn;
            });
        }

        public override long GetSize()
        {
            long rez = default(long);
            foreach(var s in _children)
            {
                rez += s.GetSize();
            }
            return rez;
        }
    }
}
