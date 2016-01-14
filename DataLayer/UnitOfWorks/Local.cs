using System;
using System.Collections;

namespace DataLayer.UnitOfWorks
{
    public static class Local
    {
        static readonly ILocalData _data = new LocalData();

        public static ILocalData Data
        {
            get { return _data; }
        }

        private class LocalData : ILocalData
        {
            [ThreadStatic]
            private static Hashtable _localData;
            private static readonly object LocalDataHashtableKey = new object();

            private static Hashtable LocalHashtable
            {
                get
                {
                    if (!RunningInWeb)
                    {
                        if (_localData == null)
                            _localData = new Hashtable();
                        return _localData;
                    }
                    else {
                        var web_hashtable = new Hashtable();
                        return web_hashtable;
                    }
                    //else
                    //{
                    //    var web_hashtable = HttpContext.Current.Items[LocalDataHashtableKey] as Hashtable;
                    //    if (web_hashtable == null)
                    //    {
                    //        web_hashtable = new Hashtable();
                    //        HttpContext.Current.Items[LocalDataHashtableKey] = web_hashtable;
                    //    }
                    //    return web_hashtable;
                    //}
                }
            }

            public object this[object key]
            {
                get { return LocalHashtable[key]; }
                set { LocalHashtable[key] = value; }
            }

            public int Count
            {
                get { return LocalHashtable.Count; }
            }

            public void Clear()
            {
                LocalHashtable.Clear();
            }

            public static bool RunningInWeb
            {
                // get { return HttpContext.Current != null; }
                get { return false; }
            }
        }
    }
}