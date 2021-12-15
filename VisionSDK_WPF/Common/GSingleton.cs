namespace VisionSDK_WPF.Common
{
    public class GSingleton<T> where T : new() 
    {
        private static T _instance;

        public static T Instance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }
    }
}